using System;

namespace BusinessLogic
{
    public class Engine
    {
        private const int attenuationDivisor = 65025;
        private const int zero = 0;
        private double _redBuffer = zero;
        private double _greenBuffer = zero;
        private double _blueBuffer = zero;

        private int rgbUpperBound = 255;

        private double RenderInfinity = 3.4 * Math.Pow(10, 38);

        private Color colorSkyStart = new Color(1, 1, 1);
        private Color colorSkyEnd = new Color(0.5, 0.7, 1);

        public static Random random;

        static Engine()
        {
            random = new Random();
        }

        public Engine(Scene scene)
        {
            Camera camera = new Camera(scene.CameraDTO);

            SceneToRender = scene;
            CameraUsedToRender = camera;
            SamplesPerPixel = camera.SamplesPerPixel;
            ResolutionX = camera.ResolutionX;
            ResolutionY = camera.ResolutionY;
            MaxDepth = camera.MaxDepth;

            random = new Random();
        }
        private Scene SceneToRender { get; set; }
        private Camera CameraUsedToRender { get; set; }
        private int SamplesPerPixel { get; }
        private int ResolutionX { get; }
        private int ResolutionY { get; }
        private int MaxDepth { get; }


        public void RandomOff()
        {
            random = new RandomProvider();
        }

        public void RandomOn()
        {
            random = new Random();
        }
        public PPM Render()
        {
            PPM ppm = new PPM(ResolutionX, ResolutionY);

            for (int row = zero; row < ppm.Heigth; row++)
            {
                for (int column = zero; column < ppm.Width; column++)
                {
                    generatePixel(ppm, row, column);
                }
            }

            return ppm;
        }

        private void generatePixel(PPM ppm, int row, int column)
        {
            Color pixel;

            for (int sample = zero; sample < SamplesPerPixel; sample++)
            {
                double randomU = random.NextDouble();
                double randomV = random.NextDouble();

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
            double tMax = RenderInfinity;
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
                return GetColor(closestObject, closestObjectHitRecord, depthLeft);
            }
            else
            {
                return GetSkyBoxColor(ray);
            }
        }

        private Color GetAveragePixel()
        {
            Color pixel = new Color((_redBuffer / rgbUpperBound) / SamplesPerPixel,
                                    (_greenBuffer / rgbUpperBound) / SamplesPerPixel,
                                    (_blueBuffer / rgbUpperBound) / SamplesPerPixel);
            return pixel;
        }

        private void ResetBuffer()
        {
            _redBuffer = zero;
            _greenBuffer = zero;
            _blueBuffer = zero;
        }



        private void AddToPixelBuffer(Color pixel)
        {
            _redBuffer += pixel.Red;
            _greenBuffer += pixel.Green;
            _blueBuffer += pixel.Blue;
        }

        private Color GetColor(PositionedModel positionedModel, HitRecord hitRecord, int depthLeft)
        {
            if (depthLeft > zero)
            {
                Ray bouncedRay = positionedModel.GetBouncedRay(hitRecord);
                Color color = shootRay(bouncedRay, depthLeft - 1);
                Color attenuation = hitRecord.Attenuation;
                return new Color((color.Red * attenuation.Red) / attenuationDivisor, 
                    (color.Green * attenuation.Green) / attenuationDivisor,
                    (color.Blue * attenuation.Blue) / attenuationDivisor);
            }
            else
            {
                return new Color(zero, zero, zero);
            }
        }

        private Color GetSkyBoxColor(Ray ray)
        {
            Vector vectorDirectionUnit = ray.Direction.GetUnit();
            double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
            return MixColorsWithWeight(colorSkyStart, colorSkyEnd, posY);
        }

        private Color MixColorsWithWeight(Color firstColor, Color secondColor, double factor)
        {
            return firstColor.MultiplyBy(1 - factor).Add(secondColor.MultiplyBy(factor));
        }

        private HitRecord IsPositionedModelHitByRay(PositionedModel positionedModel, Ray ray, double tMax)
        {
            return positionedModel.IsModelHit(ray, zero, tMax);
        }

    }
}