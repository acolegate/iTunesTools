using System.Windows.Forms;

namespace Forms
{
    public partial class ProgressForm : Form
    {
        public ProgressForm(string title, int maximum, string activity = "")
        {
            InitializeComponent();

            Title = title;
            SetProgress(0, maximum);
            Activity = activity;
        }

        public string Activity
        {
            set
            {
                activityLabel.Text = value;
                Application.DoEvents();
            }
        }

        public string Title
        {
            set
            {
                label1.Text = value;
                Application.DoEvents();
            }
        }

        public void IncrementProgressBar()
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Increment(1);
                Application.DoEvents();
            }
        }

        public void SetProgress(int value, int maximum, string activity = null)
        {
            progressBar.Maximum = maximum;
            progressBar.Value = value;
            if (activity != null)
            {
                Activity = activity;
            }
        }
    }
}