using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CustomControls.HelperFunctions;

using Forms;

using iTunesLib;

namespace CustomControls.UserControls
{
    public sealed partial class ConsolidationControl : UserControl
    {
        private readonly iTunesAppClass _itunes = new iTunesAppClass();
        private ItunesCache.Models.SearchTrack _consolidatedTrack;
        private List<ItunesCache.Models.SearchTrack> _searchTracks;
        private ItunesCache.Models.SearchTrack _trackToKeep;

        public ConsolidationControl()
        {
            InitializeComponent();
        }

        public event ParentFormWindowStateChangedDelegate ParentFormWindowStateChanged;

        /// <summary>Initialises the application.</summary>
        public void InitialiseControl()
        {
            DataGridViewHelper.SetupDataGridView(tracksGridView);
            DataGridViewHelper.SetupDataGridView(consolidatedTrackGridView);

            //_selectedTracks = null;
            _trackToKeep = null;
            _searchTracks = null;
        }

        private void RaiseParentFormWindowStateChangedEvent(FormWindowState state)
        {
            ParentFormWindowStateChangedDelegate handler = ParentFormWindowStateChanged;
            if (handler != null)
            {
                handler(this, new ParentFormWindowStateChangedEventArgs(state));
            }
        }

        private void AutoSelectBestTrack()
        {
            KeepThisTrack((from selectedTrack in _searchTracks orderby selectedTrack.BitRate descending, selectedTrack.Size descending, selectedTrack.Duration descending select selectedTrack).First().TrackId);
        }

        private void AutoSelectButton_Click(object sender, EventArgs e)
        {
            AutoSelectBestTrack();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            ClearAndMinimiseApp();
        }

        private void ClearAndMinimiseApp()
        {
            RaiseParentFormWindowStateChangedEvent(FormWindowState.Minimized);

            _searchTracks = new List<ItunesCache.Models.SearchTrack>();
            _consolidatedTrack = null;
            _trackToKeep = null;

            autoSelectButton.Enabled = false;
            consolidateButton.Enabled = false;

            tracksGridView.DataBindings.Clear();
            tracksGridView.Rows.Clear();

            consolidatedTrackGridView.DataBindings.Clear();
            consolidatedTrackGridView.Rows.Clear();
        }

        private void CommitChangesToItunes()
        {
            // display the progress form
            ProgressForm progressForm = new ProgressForm("Consolidating tracks...", _itunes.SelectedTracks.Count);

            progressForm.CenterForm(ParentForm).Show(ParentForm);

            // does the track to keep already have artwork?
            bool trackToKeepHasArtwork = _itunes.SelectedTracks.Cast<IITTrack>().Where(selectedTrack => selectedTrack.trackID == _trackToKeep.TrackId).Any(selectedTrack => selectedTrack.Artwork.Count > 0);

            bool haveConsolidatedArtwork = false;
            string consolidatedArtworkPathAndFilename = null;

            List<IITTrack> tracksToDelete = new List<IITTrack>();

            if (trackToKeepHasArtwork == false)
            {
                progressForm.Activity = "Finding artwork...";

                // the track to keep has no artowrk.
                // find some from the other selected tracks and and store it in a temp file
                foreach (IITTrack selectedTrack in _itunes.SelectedTracks)
                {
                    if (selectedTrack.Artwork.Count > 0)
                    {
                        consolidatedArtworkPathAndFilename = Path.GetTempPath() + Guid.NewGuid().ToString("D") + ".jpg";
                        selectedTrack.Artwork[1].SaveArtworkToFile(consolidatedArtworkPathAndFilename);
                        haveConsolidatedArtwork = true;

                        break;
                    }
                }

                progressForm.Activity = string.Empty;
            }

            foreach (IITTrack selectedTrack in _itunes.SelectedTracks)
            {
                if (selectedTrack.trackID == _trackToKeep.TrackId)
                {
                    // this is the one to keep
                    progressForm.Activity = "Updating track to keep...";

                    selectedTrack.Name = _trackToKeep.Name;
                    selectedTrack.Artist = _trackToKeep.Artist;
                    selectedTrack.Comment = _trackToKeep.Comments;
                    selectedTrack.Album = _trackToKeep.Album;
                    selectedTrack.Year = _trackToKeep.Year;
                    selectedTrack.Genre = _trackToKeep.Genre;
                    selectedTrack.TrackNumber = _trackToKeep.TrackNumber;
                    selectedTrack.TrackCount = _trackToKeep.TrackCount;

                    if (trackToKeepHasArtwork == false && haveConsolidatedArtwork)
                    {
                        progressForm.Activity = "Writing artwork...";
                        selectedTrack.AddArtworkFromFile(consolidatedArtworkPathAndFilename);
                    }
                }
                else
                {
                    // delete this one
                    tracksToDelete.Add(selectedTrack);
                }

                progressForm.IncrementProgressBar();
            }

            // delete any tracks necessary
            progressForm.Activity = "Removing duplicate tracks...";
            List<string> errors = new List<string>();

            foreach (IITTrack track in tracksToDelete)
            {
                try
                {
                    track.Delete();
                }
                catch (Exception ex)
                {
                    errors.Add("Unable to delete iTunes track '" + track.Name + "'" + "error: " + ex.Message);
                }
            }

            progressForm.Activity = "Cleaning up...";
            if (consolidatedArtworkPathAndFilename != null)
            {
                if (File.Exists(consolidatedArtworkPathAndFilename))
                {
                    try
                    {
                        File.Delete(consolidatedArtworkPathAndFilename);
                    }
                    catch
                    {
                        errors.Add("Unable to delete temp artwork file '" + consolidatedArtworkPathAndFilename + "'");
                    }
                }
            }

            if (errors.Any())
            {
                MessageBox.Show(this, "The following errors occured:\r\n\r\n" + string.Join("\r\n", errors), "iTunes Tools", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            progressForm.Activity = "Complete";

            // keep the progress form open for 1 second
            // Thread.Sleep(1000);

            progressForm.Close();
            progressForm.Dispose();
        }

        private void ConsolidateButton_Click(object sender, EventArgs e)
        {
            ConsolidateTracks();
        }

        private void ConsolidateTrackData()
        {
            _consolidatedTrack = _trackToKeep;

            _consolidatedTrack.Name = _trackToKeep.Name;
            _consolidatedTrack.Artist = _trackToKeep.Artist;
            _consolidatedTrack.Comments = ConsolidateDataHelper.ConsolidateCommentsData(_searchTracks);
            _consolidatedTrack.Album = ConsolidateDataHelper.ConsolidateAlbumData(_trackToKeep, _searchTracks);
            _consolidatedTrack.Year = ConsolidateDataHelper.ConsolidateYearData(_searchTracks);
            _consolidatedTrack.Genre = ConsolidateDataHelper.ConsolidateGenreData(_trackToKeep, _searchTracks);
            _consolidatedTrack.TrackNumber = ConsolidateDataHelper.ConsolidateTrackNumberData(_trackToKeep, _searchTracks);
            _consolidatedTrack.TrackCount = ConsolidateDataHelper.ConsolidateTrackCountData(_trackToKeep, _searchTracks);

            DataGridViewHelper.PopulateGridView(consolidatedTrackGridView, _consolidatedTrack);
        }

        private void ConsolidateTracks()
        {
            CommitChangesToItunes();

            ClearAndMinimiseApp();
        }

        public void KeyPressed(Keys keyCode)
        {
            switch (keyCode)
            {
                case Keys.Enter:
                {
                    ConsolidateTracks();

                    break;
                }
                case Keys.Escape:
                {
                    RaiseParentFormWindowStateChangedEvent(FormWindowState.Minimized);

                    break;
                }
            }
        }

        private void HighlightTrackToKeep()
        {
            for (int index = 0; index < tracksGridView.Rows.Count; index++)
            {
                tracksGridView.Rows[index].DefaultCellStyle.BackColor = ((int) tracksGridView.Rows[index].Cells[0].Value == _trackToKeep.TrackId) ? Color.LightPink : Color.White;
            }
        }

        private void KeepThisTrack(int trackId)
        {
            _trackToKeep = (ItunesCache.Models.SearchTrack)_searchTracks.First(x => x.TrackId == trackId).Clone();

            HighlightTrackToKeep();

            ConsolidateTrackData();

            consolidateButton.Focus();
        }

        private void KeepThisTrackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int trackId = (int) tracksGridView.Rows[tracksGridView.CurrentCell.RowIndex].Cells[0].Value;

            KeepThisTrack(trackId);
        }

        public void PopulateWithSelectedTracks()
        {
            IITTrackCollection selectedTracks = null;
            try
            {
                selectedTracks = _itunes.SelectedTracks;
            }
            catch
            {
                Console.WriteLine("No tracks selected");
            }

            if (selectedTracks != null && selectedTracks.Count > 1)
            {
                // check the iTunes selection first

                _searchTracks = new List<ItunesCache.Models.SearchTrack>();

                for (int i = 1; i <= selectedTracks.Count; i++)
                {
                    _searchTracks.Add(new ItunesCache.Models.SearchTrack(selectedTracks[i]));
                }

                DataGridViewHelper.PopulateGridView(tracksGridView, _searchTracks);

                RaiseParentFormWindowStateChangedEvent(FormWindowState.Normal);

                AutoSelectBestTrack();

                autoSelectButton.Enabled = true;
                consolidateButton.Enabled = true;
            }
            else
            {
                MessageBox.Show(this, "Make sure 2 or more tracks are selected in iTunes", "iTunes Tools", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            if (_itunes.SelectedTracks != null && _itunes.SelectedTracks.Count > 1)
            {
                PopulateWithSelectedTracks();
            }
        }

        private void TracksGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.CellStyle.FormatProvider is ICustomFormatter)
            {
                e.Value = ((ICustomFormatter) e.CellStyle.FormatProvider.GetFormat(typeof (ICustomFormatter))).Format(e.CellStyle.Format, e.Value, e.CellStyle.FormatProvider);
                e.FormattingApplied = true;
            }
        }

        private void TracksGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                tracksGridView.CurrentCell = tracksGridView[e.ColumnIndex, e.RowIndex];
            }
        }

        private void TracksGridView_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1 && ((e.ColumnIndex >= 0 && e.ColumnIndex <= 4) || e.ColumnIndex == 6))
            {
                Cursor = Cursors.Hand;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void TracksGridView_Sorted(object sender, EventArgs e)
        {
            HighlightTrackToKeep();
        }
    }

    public delegate void ParentFormWindowStateChangedDelegate(object sender, ParentFormWindowStateChangedEventArgs args);

    public class ParentFormWindowStateChangedEventArgs : EventArgs
    {
        public ParentFormWindowStateChangedEventArgs(FormWindowState state)
        {
            State = state;
        }

        public FormWindowState State { get; private set; }
    }
}