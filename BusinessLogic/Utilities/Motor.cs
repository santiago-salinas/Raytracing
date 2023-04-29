using BusinessLogic.Objects;
using System;
using System.Linq.Expressions;
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
            Vector vectorHorizontal = new Vector(4,0,0);
            Vector vectorVertical = new Vector(0, 2, 0);


            PPM ppm = new PPM(5, 5);

            for (double row = ppm.Heigth - 1; row >=0; row--)
            {
                for (double column = 0; column < ppm.Width; column++)
                {
                    foreach (PositionedModel positionedModel in _scene.GetModels()) {

                        double u = column / ppm.Width;
                        double v = row / ppm.Heigth;

                        Vector horizontalPosition = vectorHorizontal.Multiply(u);
                        Vector verticalPosition = vectorVertical.Multiply(v);

                        Vector pointPosition = _scene.LookAt.Add(horizontalPosition.Add(verticalPosition));

                        Ray ray = new Ray(_scene.LookFrom, pointPosition);

                        Color pixel = positionedModel.shootRay(ray);

                        ppm.SavePixel((int)row, (int)column, pixel);
                    }
                }
            }

            return ppm;
        }
    }
}