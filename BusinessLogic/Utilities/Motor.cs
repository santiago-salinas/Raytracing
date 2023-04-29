using BusinessLogic.Objects;
using System;
using System.Linq.Expressions;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class Motor
    {
        private Scene _scene;
        private Camera _camera;

        public Motor(Scene scene, Camera camera)
        {
            _scene = scene;
            _camera = camera;
        }

        public PPM render()
        {
            int resolutionX = 5;
            int resolutionY = 5;


            int samplesPerPixel = 100;

            


            PPM ppm = new PPM(5, 5);

            for (double row = ppm.Heigth - 1; row >= 0; row--)
            {
                for (double column = 0; column < ppm.Width; column++)
                {
                    double RedBuffer = 0;
                    double GreenBuffer = 0;
                    double BlueBuffer = 0;
                    Color pixel;

                    for (int sample = 0; sample < samplesPerPixel; sample++)
                    {
                        double u = column / ppm.Width;
                        double v = row / ppm.Heigth;

                        pixel = shootRay(_camera.GetRay(u, v));
                        RedBuffer += pixel.Red/255;
                        GreenBuffer += pixel.Green/255;
                        BlueBuffer += pixel.Blue / 255;
                    }

                    pixel = new Color(RedBuffer / samplesPerPixel, GreenBuffer / samplesPerPixel, BlueBuffer / samplesPerPixel);

                    ppm.SavePixel((int)row, (int)column, pixel);

                }
            }

            return ppm;
        }
        

        public Color shootRay(Ray ray)
        {
            HitRecord hitRecord = new HitRecord()
            {
                IsHit = false,
            };
            double tMax = 3.4 * Math.Pow(10, 38);

            foreach (PositionedModel positionedModel in _scene.GetModels())
            {
                HitRecord hit = IsPositionedModelHitByRay(positionedModel, ray, tMax);
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
            else
            {
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

        public HitRecord IsPositionedModelHitByRay(PositionedModel positionedModel, Ray ray, double tMax)
        {
            return positionedModel.IsModelHit(ray, 0, tMax);
        }
    }
}