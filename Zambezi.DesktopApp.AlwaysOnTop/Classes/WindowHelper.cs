using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Zambezi.DesktopApp.AlwaysOnTop.BusinessEntities;

namespace Zambezi.DesktopApp.AlwaysOnTop.Classes
{

    public static class WindowHelper
    {
        /// <summary>Returns a dictionary that contains the handle and title of all the open windows.</summary>
        /// <returns>A dictionary that contains the handle and title of all the open windows.</returns>

        public static List<AppWindow> GetOpenAppWindows()
        {
            IntPtr lShellWindow = GetShellWindow();
            List<AppWindow> _result = new List<AppWindow>();
            

            EnumWindows(delegate(IntPtr hWnd, int lParam)
            {
                if (hWnd == lShellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int lLength = GetWindowTextLength(hWnd);
                if (lLength == 0) return true;

                StringBuilder lBuilder = new StringBuilder(lLength);
                GetWindowText(hWnd, lBuilder, lLength + 1);

                _result.Add(new AppWindow { WindowHandle = hWnd, WindowTilte = lBuilder.ToString() });
                return true;

            }, 0);

            return _result;
        }

        delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("USER32.DLL")]
        static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        static extern IntPtr GetShellWindow();

        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public const UInt32 SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter,
                                                int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(HandleRef hwnd, out RECT lpRect);
    }
}
