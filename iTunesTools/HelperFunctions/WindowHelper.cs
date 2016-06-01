using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace iTunesTools.HelperFunctions
{
    public static class WindowHelper
    {
        public static Rect WindowLocation(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);

            if (processes.Length == 1)
            {
                Rect rect = new Rect();

                IntPtr mainWindowHandle = processes[0].MainWindowHandle;

                if (GetWindowRect(mainWindowHandle, ref rect))
                {
                    rect.Width = rect.Right - rect.Left;
                    rect.Height = rect.Bottom - rect.Top;
                }

                return rect;
            }
            throw new ArgumentException("Process '" + processName + "' not found");
        }

        #region Native Methods

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string strClassName, string strWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowRect(IntPtr hwnd, ref Rect rectangle);

        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left { get; set; }
            public int Top { get; set; }
            public int Right { get; set; }
            public int Bottom { get; set; }
            public int Width { get; set; }
            public int Height{ get; set; }
        }

        #endregion
    }
}
