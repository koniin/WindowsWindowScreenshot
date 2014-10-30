using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowScreenshot
{
    public class Win32
    {
        #region Delegates

        public delegate int EnumWindowsProcDelegate(IntPtr hWnd, int lParam);

        #endregion

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_CLOSE = 0xF060;

        private const int GWL_EXSTYLE = (-20);
        private const int WS_EX_TOOLWINDOW = 0x80;
        private const int WS_EX_APPWINDOW = 0x40000;

        public const int GW_HWNDFIRST = 0;
        public const int GW_HWNDLAST = 1;
        public const int GW_HWNDNEXT = 2;
        public const int GW_HWNDPREV = 3;
        public const int GW_OWNER = 4;
        public const int GW_CHILD = 5;
        private const UInt32 WM_KEYDOWN = 0x0100;
        private const UInt32 WM_KEYUP = 0x0101;

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(
            string lpClassName, // class name 
            string lpWindowName // window name 
            );

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(
            int hWnd, // handle to destination window 
            uint Msg, // message 
            int wParam, // first message parameter 
            int lParam // second message parameter 
            );

        [DllImport("user32.dll")]
        public static extern int SetForegroundWindow(
            IntPtr hWnd // handle to window
            );

        [DllImport("user32")]
        public static extern int EnumWindows(EnumWindowsProcDelegate lpEnumFunc, int lParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("user32", EntryPoint = "GetWindowLongA")]
        public static extern int GetWindowLongPtr(IntPtr hwnd, int nIndex);

        [DllImport("user32")]
        public static extern int GetParent(IntPtr hwnd);

        [DllImport("user32")]
        public static extern int GetWindow(IntPtr hwnd, int wCmd);


        [DllImport("user32")]
        public static extern int IsWindowVisible(IntPtr hwnd);

        [DllImport("user32")]
        public static extern int GetDesktopWindow();

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public static void PressKeys(IntPtr HWnd, byte[] keys)
        {
            foreach (byte b in keys)
            {
                PostMessage(HWnd, WM_KEYDOWN, b, 0);
            }
            foreach (byte b in keys)
            {
                PostMessage(HWnd, WM_KEYUP, b, 0);
            }
        }

        public static void PressKeys(IntPtr HWnd, byte[] keys, int holdDelayMs)
        {
            PressKeyDown(HWnd, keys);
            Thread.Sleep(holdDelayMs);
            PressKeyUp(HWnd, keys);
        }

        public static void PressKeyDown(IntPtr HWnd, byte[] keys)
        {
            foreach (byte b in keys)
            {
                PostMessage(HWnd, WM_KEYDOWN, b, 0);
            }
        }

        public static void PressKeyUp(IntPtr HWnd, byte[] keys)
        {
            foreach (byte b in keys)
            {
                PostMessage(HWnd, WM_KEYUP, b, 0);
            }
        }

        public static void PressKeyDown(IntPtr HWnd, int key)
        {
            PostMessage(HWnd, WM_KEYDOWN, key, 0);
        }

        public static void PressKeyUp(IntPtr HWnd, int key)
        {
            PostMessage(HWnd, WM_KEYUP, key, 0);
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowInfo(IntPtr hwnd, ref WINDOWINFO pwi);

        public static WINDOWINFO GetWindowInfo(IntPtr hWnd)
        {
            var info = new WINDOWINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            GetWindowInfo(hWnd, ref info);
            return info;
        }
    }
}
