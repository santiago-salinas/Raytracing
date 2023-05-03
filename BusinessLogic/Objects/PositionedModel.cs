using BusinessLogic.Objects;
using System;
using System.Diagnostics;

namespace BusinessLogic
{
    public class PositionedModel
    {
        public PositionedModel()
        {
        }

        public Model PositionedModelModel { get; set; }
        public Vector PositionedModelPosition { get; set; }

        public HitRecord IsModelHit(Ray ray, double tMin, double tMax)
        {
            double radius = PositionedModelModel.ModelShape.Radius;

            Vector vectorOriginCenter = ray.Origin.Subtract(PositionedModelPosition);
            double a = ray.Direction.Dot(ray.Direction);
            double b = vectorOriginCenter.Dot(ray.Direction) * 2;
            double c = vectorOriginCenter.Dot(vectorOriginCenter) - radius * radius;
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return new HitRecord() { IsHit = false };
            }
            else
            {
                double t = (-1 * b - Math.Sqrt(discriminant)) / (2 * a);
                Vector intersectionPoint = ray.PointAt(t);
                Vector normal = intersectionPoint.Subtract(PositionedModelPosition).Divide(radius);
                if (t < tMax && t > tMin)
                {
                    return new HitRecord()
                    {
                        IsHit = true,
                        TDistanceFromOrigin = t,
                        Intersection = intersectionPoint,
                        Normal = normal,
                        Attenuation = PositionedModelModel.ModelColor.Color,
                    };
                }
                else
                {
                    return new HitRecord() { IsHit = false };
                }
            }
        }

        public override bool Equals(object other)
        {
            bool evalModel = this.PositionedModelModel == ((PositionedModel)other).PositionedModelModel;
            bool evalPosition = this.PositionedModelPosition == ((PositionedModel)other).PositionedModelPosition;

            return evalModel && evalPosition;
        }
    }
}