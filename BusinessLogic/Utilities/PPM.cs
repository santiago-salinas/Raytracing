using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class PPM
    {
        private int _width;
        private int _heigth;
        private Color[,] _pixels;

        public PPM(int width, int height) { 
            _width = width;
            _heigth = height;
            _pixels = new Color[height, width];
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Heigth
        {
            get { return _heigth; }
            set { _heigth = value; }
        }

        public void SavePixel(int row, int column, Color pixelRGB)
        {
            int posX = column;
            int posY = _heigth - row - 1;
            _pixels[posY,posX] = pixelRGB;
        }

        public string GetImageAscii() {
            string format = "P3\r\n";
            string maxColorRange = "255\r\n";
            string ppmAsString = format +  + _width + " " + _heigth + "\r\n" + maxColorRange;
            for(int row= 0; row < _heigth; row++)
            {
                for (int column = 0; column < _width; column++)
                {
                    double red = _pixels[row, column].Red;
                    double green = _pixels[row, column].Green;
                    double blue = _pixels[row, column].Blue;

                    ppmAsString += red + " " + green + " " + blue + "\r\n";
                }
            }
            return ppmAsString;
        }

        public override bool Equals(object other)
        {
            PPM otherPPM = (PPM)other;
            return GetImageAscii() == otherPPM.GetImageAscii();
        }
    }
}
