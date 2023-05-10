using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic;

namespace UI
{
    public partial class PPMViewer : UserControl
    {

        private PPM ppm;
        public PPMViewer(PPM providedPPM)
        {
            InitializeComponent();
            ppm = providedPPM;
            this.Dock = DockStyle.Fill;
            render();
        }

        private void render()
        {
            var width = ppm.Width;
            var height = ppm.Heigth;
            var bitmap = new Bitmap(width, height);
            var pixels = ppm.PixelsValues;

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    int red = (int)pixels[row, column].Red;
                    int green = (int)pixels[row, column].Green;
                    int blue = (int)pixels[row, column].Blue;

                    bitmap.SetPixel(column, row, System.Drawing.Color.FromArgb(red, green, blue));
                }
            }

            pictureBox.Image = bitmap;
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            Refresh();
        }
    }
}
