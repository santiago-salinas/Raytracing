using BusinessLogic.Objects;
using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace BusinessLogic
{
    public class Motor
    {
        private Scene _scene;
        private Camera _camera;

        private double _redBuffer = 0;
        private double _greenBuffer = 0;
        private double _blueBuffer = 0;

        private int _samplesPerPixel;

        Random random = new Random();

        public Motor(Scene scene, Camera camera)
        {
            _scene = scene;
            _camera = camera;
            _samplesPerPixel = camera.SamplesPerPixel;
            random = new Random();
        }

        public void RandomOff()
        {
            random = new RandomProvider();
        }

        public void RandomOn()
        {
            random = new Random();
        }


        public PPM render()
        {
            PPM ppm = new PPM(_camera.ResolutionX, _camera.ResolutionY);

            for (double row = ppm.Heigth - 1; row >= 0; row--)
            {
                for (double column = 0; column < ppm.Width; column++)
                {
                    Color pixel;

                    for (int sample = 0; sample < _samplesPerPixel; sample++)
                    {
                        double randomU = random.NextDouble();
                        double randomV = random.NextDouble();

                        double u = (column + randomU) / ppm.Width;
                        double v = (row + randomV) / ppm.Heigth;

                        pixel = shootRay(_camera.GetRay(u, v));

                        AddToPixelBuffer(pixel);
                    }

                    pixel = GetAveragePixelAndReset();

                    ppm.SavePixel((int)row, (int)column, pixel);

                }
            }

            return ppm;
        }



        public Color shootRay(Ray ray)
        {
            HitRecord closestObjectHitRecord = new HitRecord()
            {
                IsHit = false,
            };
            double tMax = 3.4 * Math.Pow(10, 38);

            foreach (PositionedModel positionedModel in _scene.GetModels())
            {
                HitRecord hit = IsPositionedModelHitByRay(positionedModel, ray, tMax);
                if (hit.IsHit)
                {
                    closestObjectHitRecord = hit;
                    tMax = closestObjectHitRecord.TDistanceFromOrigin;
                }
            }

            if (closestObjectHitRecord.IsHit)
            {
                return GetNormalColor(closestObjectHitRecord);
            }
            else
            {
                return GetSkyBoxColor(ray);
            }
        }

        public Color GetAveragePixelAndReset()
        {
            Color pixel = new Color(_redBuffer / _samplesPerPixel, _greenBuffer / _samplesPerPixel, _blueBuffer / _samplesPerPixel);
            _redBuffer = 0;
            _greenBuffer = 0;
            _blueBuffer = 0;
            return pixel;
        }


        public void AddToPixelBuffer(Color pixel)
        {
            _redBuffer += pixel.Red / 255;
            _greenBuffer += pixel.Green / 255;
            _blueBuffer += pixel.Blue / 255;
        }

        public Color GetNormalColor(HitRecord hitRecord)
        {
            Color vectorColor = new Color(
                    (hitRecord.Normal.FirstValue + 1) / 2,
                    (hitRecord.Normal.SecondValue + 1) / 2,
                    (hitRecord.Normal.ThirdValue + 1) / 2);
            return vectorColor;
        }

        public Color GetSkyBoxColor(Ray ray)
        {
            Vector vectorDirectionUnit = ray.Direction.GetUnit();
            double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
            Color colorStart = new Color(1, 1, 1);
            Color colorEnd = new Color(0.5, 0.7, 1);
            return MixColorsWithWeight(colorStart, colorEnd, posY);
        }

        public Color MixColorsWithWeight(Color firstColor, Color secondColor, double factor)
        {
            return firstColor.Multiply(1 - factor).Add(secondColor.Multiply(factor));
        }

        public HitRecord IsPositionedModelHitByRay(PositionedModel positionedModel, Ray ray, double tMax)
        {
            return positionedModel.IsModelHit(ray, 0, tMax);
        }
    }
}