using System;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class Motor
    {
        private Scene _scene;
        public Motor(Scene scene)
        {
            _scene = scene;
        }

        public PPM render()
        {
            PPM ppm = new PPM(5, 5);

            for (double row = ppm.Heigth - 1; row >=0; row--)
            {
                for (double column = 0; column < ppm.Width; column++)
                {
                    double red = column / ppm.Width;
                    double green = row / ppm.Heigth;
                    double blue = 0.2;
                    Color pixel = new Color(red, green, blue);
                    ppm.SavePixel((int) row,(int) column, pixel);
                }
            }

            return ppm;
        }
    }
}