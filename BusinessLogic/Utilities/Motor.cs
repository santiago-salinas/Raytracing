﻿using BusinessLogic.Objects;
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
        private bool _isRandomActive;


        public Motor(Scene scene, Camera camera)
        {
            _scene = scene;
            _camera = camera;
            _samplesPerPixel = camera.SamplesPerPixel;
            random = new Random();
            _isRandomActive = true;

        }

        public void RandomOff()
        {
            random = new RandomProvider();
            _isRandomActive = false;
        }

        public void RandomOn()
        {
            random = new Random();
            _isRandomActive = true;
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

                        pixel = shootRay(_camera.GetRay(u, v), _camera.MaxDepth);

                        AddToPixelBuffer(pixel);
                    }

                    pixel = GetAveragePixelAndReset();

                    ppm.SavePixel((int)row, (int)column, pixel);

                }
            }

            return ppm;
        }



        public Color shootRay(Ray ray, int depthLeft)
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
                if (depthLeft > 0)
                {
                    return GetColor(closestObjectHitRecord, depthLeft);
                }
                else
                {
                    return new Color(0, 0, 0);
                }
            }
            else
            {
                return GetSkyBoxColor(ray);
            }
        }

        public Color GetAveragePixelAndReset()
        {
            Color pixel = new Color((_redBuffer/255) / _samplesPerPixel, (_greenBuffer / 255) / _samplesPerPixel, (_blueBuffer / 255) / _samplesPerPixel);
            _redBuffer = 0;
            _greenBuffer = 0;
            _blueBuffer = 0;
            return pixel;
        }

        public void AddToPixelBuffer(Color pixel)
        {
            _redBuffer += pixel.Red;
            _greenBuffer += pixel.Green;
            _blueBuffer += pixel.Blue;
        }

        public Color GetColor(HitRecord hitRecord, int depthLeft)
        {
            Vector newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(GetRandomInUnitSphere());
            Vector newVector = newVectorPoint.Subtract(hitRecord.Intersection);
            Ray newRay = new Ray(hitRecord.Intersection, newVector);
            Color color = shootRay(newRay, depthLeft-1);
            Color attenuation = hitRecord.Attenuation;
            return new Color((color.Red * attenuation.Red)/ 65025, (color.Green * attenuation.Green)/65025, (color.Blue * attenuation.Blue)/ 65025);
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
            return firstColor.MultiplyBy(1 - factor).Add(secondColor.MultiplyBy(factor));
        }

        public HitRecord IsPositionedModelHitByRay(PositionedModel positionedModel, Ray ray, double tMax)
        {
            return positionedModel.IsModelHit(ray, 0, tMax);
        }

        public Vector GetRandomInUnitSphere()
        {
            Vector vector;
            do
            {
                Vector vectorTemp = new Vector(random.NextDouble(), random.NextDouble(), random.NextDouble());
                vector = vectorTemp.Multiply(2).Subtract(new Vector(1, 1, 1));
            } while (vector.SquaredLength() >= 1);

            return vector;
        }

    }
}