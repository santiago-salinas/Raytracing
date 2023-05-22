namespace BusinessLogic
{
    public class PPM
    {
        private Color[,] _pixels;

        public PPM(int width, int height)
        {
            Width = width;
            Heigth = height;
            PixelsValues = new Color[height, width];
        }

        public int Width { get; set; }

        public int Heigth { get; set; }

        public Color[,] PixelsValues
        {
            get
            {
                return _pixels;
            }

            set { _pixels = value; }
        }
        public void SavePixel(int row, int column, Color pixelRGB)
        {
            int posX = column;
            int posY = Heigth - row - 1;
            _pixels[posY, posX] = pixelRGB;
        }

        public string GetImageAscii()
        {
            string format = "P3\r\n";
            string maxColorRange = "255\r\n";
            string ppmAsString = format + +Width + " " + Heigth + "\r\n" + maxColorRange;
            for (int row = 0; row < Heigth; row++)
            {
                for (int column = 0; column < Width; column++)
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
