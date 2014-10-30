using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowScreenshot
{
    public partial class Form1 : Form {
        private Screenshot screenShot;
        private WindowLocator windowLocator;
        private Bitmap image;

        public Form1()
        {
            InitializeComponent();
            screenShot = new Screenshot();
        }

        private void btnCapture_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(tbWindowName.Text)) {
                MessageBox.Show("Window name is empty");
                return;
            } else {
                windowLocator = new WindowLocator(tbWindowName.Text);    
            }

            image = screenShot.Capture(windowLocator.info.rcWindow);
            image.Save(".\\" + tbWindowName.Text.Replace(" ", "_") + ".png", ImageFormat.Png);
        }
    }
}
