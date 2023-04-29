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
            Vector canvasHorizontal = new Vector(4, 0, 0);
            Vector canvasVertical = new Vector(0, 2, 0);


            PPM ppm = new PPM(5, 5);

            for (double row = ppm.Heigth - 1; row >= 0; row--)
            {
                for (double column = 0; column < ppm.Width; column++)
                {
                    double u = column / ppm.Width;
                    double v = row / ppm.Heigth;

                    Vector horizontalPosition = canvasHorizontal.Multiply(u);
                    Vector verticalPosition = canvasVertical.Multiply(v);

                    Vector pointPosition = _scene.LookAt.Add(horizontalPosition.Add(verticalPosition));

                    Ray ray = new Ray(_scene.LookFrom, pointPosition);

                    Color pixel = shootRay(ray);

                    ppm.SavePixel((int)row, (int)column, pixel);

                }
            }

            return ppm;
        }
        public Color shootRay(Ray ray)
        {
            HitRecord hitRecord = new HitRecord(){
                IsHit = false,
            };
            double tMax = 3.4 * Math.Pow(10, 38);

            foreach (PositionedModel positionedModel in _scene.GetModels())
            {
                HitRecord hit = positionedModel.PositionedModelModel.ModelShape.IsSphereHit(ray, positionedModel.PositionedModelPosition, 0, tMax);
                if (hit.IsHit)
                {
                    hitRecord = hit;
                    tMax = hitRecord.TDistanceFromOrigin;
                }
            }

            if (hitRecord.IsHit)
            {
                Color vectorColor = new Color(
                    (hitRecord.Normal.FirstValue + 1) / 2,
                    (hitRecord.Normal.SecondValue + 1) / 2,
                    (hitRecord.Normal.ThirdValue + 1) / 2);
                return vectorColor;
            }
            else {
                return GetSkyBoxColor(ray);
            }

        }

        public Color GetSkyBoxColor(Ray ray)
        {
            Vector vectorDirectionUnit = ray.Direction.GetUnit();
            double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
            Color colorStart = new Color(1, 1, 1);
            Color colorEnd = new Color(0.5, 0.7, 1);
            return colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
        }
    }
}