using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowScreenshot
{
    public class WindowLocator
    {
        public IntPtr iHandle;

        public WindowLocator(string name)
        {
            iHandle = Win32.FindWindow(null, name);
            SetForeground();
        }

        public WINDOWINFO info
        {
            get { return Win32.GetWindowInfo(iHandle); }
        }

        public void SetForeground()
        {
            Win32.SetForegroundWindow(iHandle);
        }
        /*
        public void SendKeys(string keys)
        {
            SetForeground();
            Win32.PressKeys(iHandle, Encoding.ASCII.GetBytes(keys));
        }

        public void SendKeys(string keys, int holdDelayMs)
        {
            SetForeground();
            Win32.PressKeys(iHandle, Encoding.ASCII.GetBytes(keys), holdDelayMs);
        }

        public void SendKeyDown(string keys)
        {
            Win32.PressKeyDown(iHandle, Encoding.ASCII.GetBytes(keys));
        }

        public void SendKeyUp(string keys)
        {
            Win32.PressKeyUp(iHandle, Encoding.ASCII.GetBytes(keys));
        }

        public void SendKeyDown(int key)
        {
            Win32.PressKeyDown(iHandle, key);
        }

        public void SendKeyUp(int key)
        {
            Win32.PressKeyUp(iHandle, key);
        }*/
    }
}
