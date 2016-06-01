using System;
using System.Windows.Forms;

namespace CustomControls.Forms
{
    public partial class PlaylistDetailsForm : Form
    {
        public PlaylistDetailsForm()
        {
            InitializeComponent();
        }

        public string PlaylistName { get; private set; }
        public bool ShowInItunes { get; private set; }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            PlaylistName = null;
            ShowInItunes = true;
            
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != string.Empty)
            {
                PlaylistName = textBox1.Text.Trim();
                ShowInItunes = checkBox.Checked;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(this, "Please enter a playlist name");
            }
        }

        private void PlaylistDetailsForm_Load(object sender, EventArgs e)
        {
            ShowInItunes = true;
            checkBox.Checked = true;
        }
    }
}
