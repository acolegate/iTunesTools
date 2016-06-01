using System;
using System.Windows.Forms;

using iTunesTools.NativeMethods;

namespace iTunesTools
{
    internal static class Program
    {
        public static GlobalKeyboardHook Hook;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // register the CONTROL + ALT + F12 combination as hot key.
            // You can change this.
            Hook = new GlobalKeyboardHook();
            Hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt, Keys.F12);
            
            Application.Run(new MainForm());
        }
    }
}
