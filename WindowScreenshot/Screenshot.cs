using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowScreenshot
{
    public class Screenshot
    {
        private static Bitmap bmpScreenshot;
        private static Graphics gfxScreenshot;

        public Bitmap Capture()
        {
            return Capture(Screen.PrimaryScreen.Bounds.Left, Screen.PrimaryScreen.Bounds.Top,
                           Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
        }

        public Bitmap Capture(int left, int top, int width, int height)
        {
            // Set the bitmap object to the size of the screen

            bmpScreenshot = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            // Create a graphics object from the bitmap

            gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner

            gfxScreenshot.CopyFromScreen(left, top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);

            return bmpScreenshot;
            // Save the screenshot to the specified path that the user has chosen

            //bmpScreenshot.Save(saveScreenshot.FileName, ImageFormat.Png);
        }

        public Bitmap Capture(RECT rcWindow)
        {
            return Capture(rcWindow.Left, rcWindow.Top, rcWindow.Width, rcWindow.Height);
        }
    }
}
