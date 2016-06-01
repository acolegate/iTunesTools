using System;
using System.Windows.Forms;

using ItunesCache;

namespace TestWinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Data_ProgressMade(object sender, Data.ProgressMadeEventArgs args)
        {
            progressBar.Maximum = args.MaxValue; // set the max first
            progressBar.Value = args.Value;

            label.Text = args.Value + @" / " + args.MaxValue;
        }

        private void ReadiTunes()
        {
            progressBar.Value = 0;

            Data.ProgressMade += Data_ProgressMade;

            //Data.Instance.InitialiseFromItunes();
            Data.Instance.InitialiseFromStaticFile();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ReadiTunes();
        }
    }
}
