using System;
using System.Drawing;
using System.Windows.Forms;
using CustomControls.UserControls;
using Forms;
using ItunesCache;
using iTunesTools.HelperFunctions;
using iTunesTools.NativeMethods;

namespace iTunesTools
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            InitialiseApp();
        }

        private void ConsolidationControl_ParentFormWindowStateChanged(object sender, ParentFormWindowStateChangedEventArgs args)
        {
            switch (args.State)
            {
                case FormWindowState.Minimized:
                {
                    WindowState = FormWindowState.Minimized;
                    break;
                }
                default:
                {
                    DisplayForm();
                    break;
                }
            }
        }

        private void DisplayForm()
        {
            // find iTunes window
            WindowHelper.Rect iTunesWindow = WindowHelper.WindowLocation("iTunes");

            if (iTunesWindow.Width != 0)
            {
                // calculate centre of the iTunes Window
                int iTunesCentreX = iTunesWindow.Left + (iTunesWindow.Width/2);
                int iTunesCentreY = iTunesWindow.Top + (iTunesWindow.Height/2);

                // calculate the new location of the app window
                int x = iTunesCentreX - (RestoreBounds.Width/2);
                int y = iTunesCentreY - (RestoreBounds.Height/2);

                // set the app window location
                Location = new Point(x, y);
            }

            // show the app in front of iTunes
            WindowState = FormWindowState.Normal;
            BringToFront();
            TopMost = true;
            Focus();
        }

        private void GlobalKeyboardHook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            if (e.Modifier == (NativeMethods.ModifierKeys.Control | NativeMethods.ModifierKeys.Alt) && e.Key == Keys.F12)
            {
                // CTRL + ALT + F12

                // make the consolidation tab visible
                tabControl.SelectedIndex = 0;

                consolidationControl.PopulateWithSelectedTracks();
            }
        }

        private void InitialiseApp()
        {
            consolidationControl.InitialiseControl();

            consolidationControl.ParentFormWindowStateChanged += ConsolidationControl_ParentFormWindowStateChanged;

            Program.Hook.KeyPressed += GlobalKeyboardHook_KeyPressed;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
                {
                    e.Handled = true;
                    consolidationControl.KeyPressed(e.KeyCode);
                }
            }

            if (tabControl.SelectedIndex == 2)
            {
                // Compilation control
                if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
                {
                    e.Handled = true;
                    compilationBuilderControl.KeyPressed(e);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            DateTime? serialisedDate = Data.SerialisedDate;

            bool initialiseFromStaticFile = false;

            if (serialisedDate != null)
            {
                initialiseFromStaticFile = MessageBox.Show(this, string.Format("Serialised data from {0} is available for fast load\r\n\r\nLoad it?", ((DateTime) serialisedDate).ToRelativeString()), "Itunes Tools", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes;
            }

            ProgressForm progressForm = new ProgressForm("Reading tracks...", 0, "0 / 0");

            Data.ProgressMadeDelegate progressMadeDelegate = (o, args) =>
             progressForm.SetProgress(args.Value, args.MaxValue, args.Value + " / " + args.MaxValue);

            Data.ProgressMade += progressMadeDelegate;

            progressForm.CenterForm(this).Show(this);
            Application.DoEvents();

            if (initialiseFromStaticFile)
            {
                Data.Instance.InitialiseFromStaticFile();
            }
            else
            {
                Data.Instance.InitialiseFromItunes();
            }

            Data.ProgressMade -= progressMadeDelegate;

            progressForm.Close();
        }
    }
}
