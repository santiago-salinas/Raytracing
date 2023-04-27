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
        private Color[][] _pixels;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _heigth; }
            set { _heigth = value; }
        }

        public void SavePixel(int row, int column, Color pixelRGB)
        {
            _pixels[row][column]= pixelRGB;
        }

        public string GetImageAscii() {
            string ret = "P3 \n";
            ret += _width + "\n";
            ret += _heigth + "\n";
            ret += 255 + "\n";
            for(int i=0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    ret += _pixels[j][i].Red + " " + _pixels[j][i].Green + " " + _pixels[j][i].Blue + "\n";
                }
            }
            return ret;
        }
    }
}
