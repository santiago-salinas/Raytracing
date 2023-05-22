﻿using BusinessLogic;
using Controllers.DTOs;
using System.Drawing;
using System.Windows.Forms;

namespace UI
{
    public partial class PPMViewer : UserControl
    {

        private PPM _ppm;
        public PPMViewer(PPM providedPPM)
        {
            InitializeComponent();
            _ppm = providedPPM;
            this.Dock = DockStyle.Fill;
            Render();
        }

        private void Render()
        {
            int width = _ppm.Width;
            int height = _ppm.Heigth;
            Bitmap bitmap = new Bitmap(width, height);
            BusinessLogic.Color[,] pixels = _ppm.PixelsValues;

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
