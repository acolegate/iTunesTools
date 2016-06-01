using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using CustomControls.Forms;
using CustomControls.HelperFunctions;
using CustomControls.StringComparison;

using Forms;

using ItunesCache;
using ItunesCache.Models;

using iTunesLib;

namespace CustomControls.UserControls
{
    public partial class CompilationBuilderControl : UserControl
    {
        private List<IITTrack> _identifiedTracks;
        private Dictionary<string, List<string>> _textLineWordMetaphones;

        public CompilationBuilderControl()
        {
            InitializeComponent();

            DataGridViewHelper.SetupDataGridView(compilationTracksDataGridView);
        }

        public void KeyPressed(KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBox.Focus();
                textBox.SelectAll();
            }
        }

        private static IEnumerable<IITTrack> GetPossibleTracks(IEnumerable<string> metaphones)
        {
            List<string> possibleArtists = new List<string>();
            List<string> possibleTracknames = new List<string>();

            // identify possible track and artist names
            foreach (string metaphone in metaphones)
            {
                if (Data.Instance.MetaPhoneArtists.ContainsKey(metaphone))
                {
                    possibleArtists.AddRange(Data.Instance.MetaPhoneArtists[metaphone]);
                }

                if (Data.Instance.MetaphoneTrackNames.ContainsKey(metaphone))
                {
                    possibleTracknames.AddRange(Data.Instance.MetaphoneTrackNames[metaphone]);
                }
            }

            return (from searchTrack in Data.Instance.SearchTracks where possibleArtists.Contains(searchTrack.Artist) && possibleTracknames.Contains(searchTrack.Name) select searchTrack.TrackObject).ToList();
        }

        /// <summary>
        /// Calculates the Nth Triangle of a number
        /// i.e. For 5 : 5+4+3+2+1 = 21
        /// For 3 :     3+2+1 = 6
        /// For 1 :         1 = 1
        /// </summary>
        /// <param name="i">The number</param>
        /// <returns>The Nth triangle</returns>
        private static int NthTriangle(int i)
        {
            return i <= 1 ? 1 : i + NthTriangle(i - 1);
        }

        private void IdentifyTracks()
        {
            List<SearchTrack> displayTracks = new List<SearchTrack>();

            _identifiedTracks = new List<IITTrack>();

            int missingTracks = 0;
            int matches = 0;
            int duplicateMatches = 0;

            using (ProgressForm progressForm = new ProgressForm("Finding tracks...", _textLineWordMetaphones.Count))
            {
                progressForm.CenterForm(ParentForm).Show(ParentForm);

                foreach (KeyValuePair<string, List<string>> line in _textLineWordMetaphones)
                {
                    IEnumerable<string> metaphones = line.Value.Distinct();

                    IEnumerable<IITTrack> possibleTracks = GetPossibleTracks(metaphones).ToList();

                    if (possibleTracks.Any() == false)
                    {
                        WriteLineToReport("No matches for '" + line.Key + "'", Color.Red);
                        missingTracks++;
                    }
                    else
                    {
                        matches++;
                        if (possibleTracks.Count() == 1)
                        {
                            WriteLineToReport("Matched '" + line.Key + "'", Color.Green);
                        }
                        else
                        {
                            WriteLineToReport("Multiple matches for '" + line.Key + "'", Color.Orange);
                            duplicateMatches++;
                        }

                        foreach (IITTrack track in possibleTracks)
                        {
                            WriteLineToReport(track.Artist + " - " + track.Name, Color.Green);

                            SearchTrack searchTrack = new SearchTrack(track);

                            if (displayTracks.Exists(x => x.TrackId == searchTrack.TrackId) == false)
                            {
                                displayTracks.Add(searchTrack);

                                _identifiedTracks.Add(track);
                            }
                        }
                    }

                    WriteLineToReport(String.Empty);

                    progressForm.IncrementProgressBar();
                }

                compilationTracksDataGridView.DataSource = displayTracks;

                progressForm.Close();

                WriteLineToReport("Total lines: " + _textLineWordMetaphones.Count);
                WriteLineToReport("Total matches: " + matches, Color.Green);
                WriteLineToReport("Duplicates: " + duplicateMatches, Color.Orange);
                WriteLineToReport("Failed matches: " + missingTracks, Color.Red);
            }
        }

        private void ParseTextButton_Click(object sender, EventArgs e)
        {
            // show the processing report
            richTextBox.Clear();
            tabControl.SelectedIndex = 1;

            if (textBox.Text.Trim() != string.Empty)
            {
                PopulateTextLineMetaphones();

                IdentifyTracks();
            }
            else
            {
                MessageBox.Show(this, "Please enter or copy text into the raw text box pefore parsing");
            }
        }

        private void PopulateTextLineMetaphones()
        {
            string text = textBox.Text;
            MatchCollection lineMatches = Regex.Matches(text, "^(.*?)$", RegexOptions.Multiline);

            _textLineWordMetaphones = new Dictionary<string, List<string>>(lineMatches.Count);

            using (ProgressForm progressForm = new ProgressForm("Analysing text...", lineMatches.Count))
            {
                progressForm.CenterForm(ParentForm).Show(ParentForm);

                string line;
                string[] words;
                List<string> lineWordMetaphones;
                int wordCount;
                string metaphone;

                foreach (Match lineMatch in lineMatches)
                {
                    line = lineMatch.Groups[1].Value.Trim();

                    if (line != string.Empty)
                    {
                        // Expand ampersands
                        line = line.Replace("&", "And");

                        words = Regex.Split(line, @"\s+");

                        wordCount = words.Length;

                        lineWordMetaphones = new List<string>(NthTriangle(wordCount));

                        for (int i = 0; i < wordCount; i++)
                        {
                            for (int j = i; j < wordCount; j++)
                            {
                                metaphone = Metaphone.Encode(string.Join(" ", words, i, j - i + 1));

                                if (metaphone != string.Empty)
                                {
                                    lineWordMetaphones.Add(metaphone);
                                }
                            }
                        }

                        _textLineWordMetaphones.Add(line, lineWordMetaphones);
                    }

                    progressForm.IncrementProgressBar();
                }

                progressForm.Close();
            }
        }

        private void SavePlaylistButton_Click(object sender, EventArgs e)
        {
            if (_identifiedTracks != null && _identifiedTracks.Any())
            {
                using (PlaylistDetailsForm playlistDetailsForm = new PlaylistDetailsForm())
                {
                    if (playlistDetailsForm.ShowDialog(this) == DialogResult.OK)
                    {
                        // save the playlist
                        iTunesApp iTunesApp = new iTunesApp();

                        IITUserPlaylist playlist = iTunesApp.CreatePlaylist(playlistDetailsForm.PlaylistName) as IITUserPlaylist;

                        if (playlist != null)
                        {
                            foreach (IITTrack track in _identifiedTracks)
                            {
                                playlist.AddTrack(track);
                            }

                            if (playlistDetailsForm.ShowInItunes)
                            {
                                if (playlist.Tracks.Count > 0)
                                {
                                    IITFileOrCDTrack track = playlist.Tracks[1] as IITFileOrCDTrack;
                                    if (track != null)
                                    {
                                        track.Reveal();
                                    }
                                }

                                WindowHelper.BringToFront("iTunes");
                            }
                            else
                            {
                                MessageBox.Show(ParentForm, "Playlist '" + playlistDetailsForm.PlaylistName + "' created");
                            }
                        }
                        else
                        {
                            MessageBox.Show(ParentForm, "Failed to create playlist", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(ParentForm, "No tracks to save as a playlist", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void WriteLineToReport(string text, Color color = default(Color))
        {
            richTextBox.SelectionStart = richTextBox.TextLength;
            richTextBox.SelectionLength = 0;

            richTextBox.SelectionColor = color;
            richTextBox.AppendText(text);
            richTextBox.SelectionColor = richTextBox.ForeColor;

            richTextBox.AppendText(Environment.NewLine);
        }
    }
}
