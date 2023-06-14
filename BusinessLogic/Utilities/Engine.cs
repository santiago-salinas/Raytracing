using BusinessLogic.DomainObjects;
using System;

namespace BusinessLogic.Utilities
{
    public class Engine
    {
        private const int _attenuationDivisor = 65025;
        private const int _zero = 0;
        private double _redBuffer = _zero;
        private double _greenBuffer = _zero;
        private double _blueBuffer = _zero;

        private int _rgbUpperBound = 255;

        private double _renderInfinity = 3.4 * Math.Pow(10, 38);

        private Color _colorSkyStart = new Color(1, 1, 1);
        private Color _colorSkyEnd = new Color(0.5, 0.7, 1);

        public static Random Random;

        static Engine()
        {
            Random = new Random();
        }

        public Engine(Scene scene, ICamera camera)
        {
            Random = new Random();

            CameraUsedToRender = camera;

            SceneToRender = scene;
            SamplesPerPixel = CameraUsedToRender.SamplesPerPixel;
            ResolutionX = CameraUsedToRender.ResolutionX;
            ResolutionY = CameraUsedToRender.ResolutionY;
            MaxDepth = CameraUsedToRender.MaxDepth;
        }
        private Scene SceneToRender { get; set; }
        private ICamera CameraUsedToRender { get; set; }
        private int SamplesPerPixel { get; }
        private int ResolutionX { get; }
        private int ResolutionY { get; }
        private int MaxDepth { get; }

        public void RandomOff()
        {
            Random = new RandomProvider();
        }

        public void RandomOn()
        {
            Random = new Random();
        }
        public PPM Render()
        {
            PPM ppm = new PPM(ResolutionX, ResolutionY);

            for (int row = _zero; row < ppm.Heigth; row++)
            {
                for (int column = _zero; column < ppm.Width; column++)
                {
                    generatePixel(ppm, row, column);
                }
            }

            return ppm;
        }

        private void generatePixel(PPM ppm, int row, int column)
        {
            Color pixel;

            for (int sample = _zero; sample < SamplesPerPixel; sample++)
            {
                double randomU = Random.NextDouble();
                double randomV = Random.NextDouble();

                double u = (column + randomU) / ppm.Width;
                double v = (row + randomV) / ppm.Heigth;

                Ray fromCameraToPixel = CameraUsedToRender.GetRay(u, v);

                pixel = shootRay(fromCameraToPixel, MaxDepth);

                AddToPixelBuffer(pixel);
            }

            pixel = GetAveragePixel();
            ResetBuffer();

            ppm.SavePixel(row, column, pixel);
        }

        private Color shootRay(Ray ray, int depthLeft)
        {
            HitRecord closestObjectHitRecord = new HitRecord()
            {
                IsHit = false,
            };
            double tMax = _renderInfinity;
            PositionedModel closestObject = new PositionedModel();
            foreach (PositionedModel positionedModel in SceneToRender.GetModels())
            {
                HitRecord hit = IsPositionedModelHitByRay(positionedModel, ray, tMax);
                if (hit.IsHit)
                {
                    closestObjectHitRecord = hit;
                    tMax = closestObjectHitRecord.TDistanceFromOrigin;
                    closestObject = positionedModel;
                }
            }

            if (closestObjectHitRecord.IsHit)
            {
                closestObjectHitRecord.Inray = ray;
                return GetColor(closestObject, closestObjectHitRecord, depthLeft);
            }
            else
            {
                return GetSkyBoxColor(ray);
            }
        }

        private Color GetAveragePixel()
        {
            Color pixel = new Color((_redBuffer / _rgbUpperBound) / SamplesPerPixel,
                                    (_greenBuffer / _rgbUpperBound) / SamplesPerPixel,
                                    (_blueBuffer / _rgbUpperBound) / SamplesPerPixel);
            return pixel;
        }

        private void ResetBuffer()
        {
            _redBuffer = _zero;
            _greenBuffer = _zero;
            _blueBuffer = _zero;
        }



        private void AddToPixelBuffer(Color pixel)
        {
            _redBuffer += pixel.Red;
            _greenBuffer += pixel.Green;
            _blueBuffer += pixel.Blue;
        }

        private Color GetColor(PositionedModel positionedModel, HitRecord hitRecord, int depthLeft)
        {
            if (depthLeft > _zero)
            {
                Ray bouncedRay = positionedModel.GetBouncedRay(hitRecord);

                if (bouncedRay.Nulleable)
                {
                    return new Color(_zero, _zero, _zero);
                }

                Color color = shootRay(bouncedRay, depthLeft - 1);
                Color attenuation = hitRecord.Attenuation;
                return new Color((color.Red * attenuation.Red) / _attenuationDivisor,
                    (color.Green * attenuation.Green) / _attenuationDivisor,
                    (color.Blue * attenuation.Blue) / _attenuationDivisor);
            }
            else
            {
                return new Color(_zero, _zero, _zero);
            }
        }

        private Color GetSkyBoxColor(Ray ray)
        {
            Vector vectorDirectionUnit = ray.Direction.GetUnit();
            double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
            return MixColorsWithWeight(_colorSkyStart, _colorSkyEnd, posY);
        }

        private Color MixColorsWithWeight(Color firstColor, Color secondColor, double factor)
        {
            return firstColor.MultiplyBy(1 - factor).Add(secondColor.MultiplyBy(factor));
        }

        private HitRecord IsPositionedModelHitByRay(PositionedModel positionedModel, Ray ray, double tMax)
        {
            return positionedModel.IsModelHit(ray, _zero, tMax);
        }

    }
}