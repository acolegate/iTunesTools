using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using CustomControls.ExtensionMethods;
using CustomControls.HelperFunctions;

using Forms;

using ItunesCache;

namespace CustomControls.UserControls
{
    public partial class OrphanedMediaFilesControl : UserControl
    {
        private HashSet<string> _musicMediaFiles;
        private long _occupiedSpace;

        public OrphanedMediaFilesControl()
        {
            InitializeComponent();
            InitialiseStorage();
            InitialiseControls();
        }

        private static string MusicMediaPath
        {
            get
            {
                return Path.GetDirectoryName(Data.Instance.LibraryXmlPath) + @"\iTunes Media\Music";
            }
        }

        private static void MoveFile(string source, string destination)
        {
            string destinationDirectory = Path.GetDirectoryName(destination);

            if (destinationDirectory != null)
            {
                if (Directory.Exists(destinationDirectory) == false)
                {
                    Directory.CreateDirectory(destinationDirectory);
                }

                File.Move(source, destination);
            }
        }

        private void ClearList()
        {
            orphanedFilesListBox.Items.Clear();
        }

        private void DeleteOrphanedFilesButton_Click(object sender, EventArgs e)
        {
            if (_musicMediaFiles.Any())
            {
                if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} file{1} occupying {2}?", _musicMediaFiles.Count, (_musicMediaFiles.Count > 1 ? "s" : string.Empty), _occupiedSpace.ToFileSize()), "iTunes Tools", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (string file in _musicMediaFiles)
                    {
                        File.Delete(file);
                    }

                    MessageBox.Show(this, string.Format("Deleted {0} file{1} occupying {2}", _musicMediaFiles.Count, (_musicMediaFiles.Count > 1 ? "s" : string.Empty), _occupiedSpace.ToFileSize()), "iTunes Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _occupiedSpace = 0;
                    _musicMediaFiles.Clear();
                    orphanedFilesListBox.Items.Clear();

                    SetButtonState();
                }
            }
        }

        private void GetAllMusicMediaFiles()
        {
            string[] files = Directory.GetFiles(MusicMediaPath, "*.*", SearchOption.AllDirectories);

            _musicMediaFiles = new HashSet<string>(files, StringComparer.OrdinalIgnoreCase);
        }

        private void InitialiseControls()
        {
            SetButtonState();
            SetLabel();
        }

        private void InitialiseStorage()
        {
            _musicMediaFiles = new HashSet<string>();
        }

        private void MoveOrphanedFilesButton_Click(object sender, EventArgs e)
        {
            if (_musicMediaFiles.Any())
            {
                if (folderBrowserDialog.ShowDialog(ParentForm) == DialogResult.OK)
                {
                    int pathLength = Data.Instance.LibraryXmlPath.Length;
                    string selectedPath = folderBrowserDialog.SelectedPath;

                    if (MessageBox.Show(ParentForm, string.Format("Are you sure you want to move {0} music file{1} to\r\n{2}", _musicMediaFiles.Count, _musicMediaFiles.Count > 1 ? "s" : string.Empty, selectedPath), "iTunes Tools", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        using (ProgressForm progressForm = new ProgressForm("Moving orphaned files...", _musicMediaFiles.Count))
                        {
                            progressForm.CenterForm(ParentForm).Show(this);

                            foreach (string mediaFile in _musicMediaFiles)
                            {
                                MoveFile(mediaFile, selectedPath + mediaFile.Substring(pathLength));

                                progressForm.IncrementProgressBar();
                            }

                            FileSystemHelper.DeleteEmptyDirs(MusicMediaPath);

                            MessageBox.Show(ParentForm, string.Format("Moved {0} music file{1} to\r\n{2}", _musicMediaFiles.Count, _musicMediaFiles.Count > 1 ? "s" : string.Empty, selectedPath), "iTunes Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            progressForm.Close();
                        }
                    }
                }
            }
        }

        private void ScanLibrary()
        {
            _occupiedSpace = 0;
            orphanedFilesListBox.Items.Clear();

            GetAllMusicMediaFiles();

            foreach (string location in Data.Instance.SearchTracks.Select(track => track.Location).Where(location => _musicMediaFiles.Contains(location)))
            {
                _musicMediaFiles.Remove(location);
            }

            if (_musicMediaFiles.Any())
            {
                orphanedFilesListBox.Items.AddRange(_musicMediaFiles.ToArray<object>());

                _occupiedSpace += _musicMediaFiles.Sum(mediaFile => new FileInfo(mediaFile).Length);
            }

            MessageBox.Show(ParentForm, _musicMediaFiles.Any() ? string.Format("{0} orphaned media file{1} occupying {2}", _musicMediaFiles.Count, _musicMediaFiles.Count > 1 ? "s" : string.Empty, _occupiedSpace.ToFileSize()) : "No orphaned media files found", "iTunes Tools", MessageBoxButtons.OK, MessageBoxIcon.Information);

            SetButtonState();
        }

        private void ScanLibraryButton_Click(object sender, EventArgs e)
        {
            ClearList();
            ScanLibrary();
        }

        private void SetButtonState()
        {
            moveOrphanedFilesButton.Enabled = _musicMediaFiles.Any();
            deleteOrphanedFilesButton.Enabled = _musicMediaFiles.Any();
        }

        private void SetLabel()
        {
            if (_musicMediaFiles.Any())
            {
                label1.Text = string.Format("{0} orphan music file{1} found in {2}", _musicMediaFiles.Count, _musicMediaFiles.Count > 1 ? "s" : string.Empty, Data.Instance.LibraryXmlPath);
            }
            else
            {
                label1.Text = "Library path: " + Data.Instance.LibraryXmlPath;
            }
        }
    }
}
