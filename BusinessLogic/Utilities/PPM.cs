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
            string ret = "P3\n";
            ret += _width + " " + _heigth + "\n";
            ret += 255 + "\n";
            for(int j= 0; j < _heigth; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    ret += _pixels[j, i].Red + " " + _pixels[j, i].Green + " " + _pixels[j, i].Blue + "\n";
                }
            }
            return ret;
        }

        public override bool Equals(object other)
        {
            PPM otherPPM = (PPM)other;
            return GetImageAscii() == otherPPM.GetImageAscii();
        }
    }
}
