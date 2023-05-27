using BusinessLogic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace UI
{
    public partial class PPMViewer : UserControl
    {
        private Bitmap bitmap;
        public PPM ppm;
        public PPMViewer(PPM providedPPM)
        {
            InitializeComponent();
            ppm = providedPPM;
            this.Dock = DockStyle.Fill;
            Render();
        }

        private void Render()
        {
            var width = ppm.Width;
            var height = ppm.Heigth;
            bitmap = new Bitmap(width, height);
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

        public void SavePPM(FileStream fs)
        {
            var width = ppm.Width;
            var height = ppm.Heigth;
            var pixels = ppm.PixelsValues;
            using (StreamWriter writetext = new StreamWriter(fs))
            {
                string format = "P3\r\n";
                string maxColorRange = "255\r\n";
                writetext.WriteLine(format + + width + " " + height + "\r\n" + maxColorRange);
                for (int row = 0; row < height; row++)
                {
                    for (int column = 0; column < width; column++)
                    {
                        double red = pixels[row, column].Red;
                        double green = pixels[row, column].Green;
                        double blue = pixels[row, column].Blue;

                        writetext.WriteLine(red + " " + green + " " + blue + "\r\n");
                    }
                }
            }
        }
        
        public Image GetImage()
        {
            return pictureBox.Image;
        }
    }
}
