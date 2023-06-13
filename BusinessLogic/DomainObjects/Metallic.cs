using BusinessLogic.Utilities;
using System;

namespace BusinessLogic.DomainObjects
{
    public class Metallic : Material
    {
        private const int _lowerBoundForPercentages = 0;
        private const int _upperBoundForPercentages = 1;
        private double _roughness;

        public Metallic() { }

        public Color Color { get; set; }
        public double Roughness
        {
            get
            {
                return _roughness;
            }
            set
            {
                if (ValueIsBetweenStrictBounds(value, _lowerBoundForPercentages, _upperBoundForPercentages))
                {
                    _roughness = value;
                }
                else
                {
                    throw new ArgumentException("Roughness value must be between 0 and 1");
                }
            }
        }

        public bool ValueIsBetweenStrictBounds(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public override Color Preview
        {
            get { return Color; }
        }

        public override string Type
        {
            get { return "metallic"; }
        }

        public override string ToString()
        {
            return Type + ":\nRGB (" + Color.ToString() + ")\nRoughness: " + Roughness;
        }

        public override Ray GetBouncedRay(HitRecord hitRecord)
        {
            Vector newVectorPoint = Reflect(hitRecord.Inray.Direction.GetUnit(), hitRecord.Normal);
            newVectorPoint = newVectorPoint.Add(Vector.GetRandomInUnitSphere().Multiply(hitRecord.Roughness));
            Ray newRay = new Ray(hitRecord.Intersection, newVectorPoint);

            if (newRay.Direction.Dot(hitRecord.Normal) > 0)
            {
                return newRay;
            }

            newRay.Nulleable = true;
            return newRay;
        }

        public Vector Reflect(Vector vectorV, Vector vectorN)
        {
            double dotVN = vectorV.Dot(vectorN);
            return vectorV.Subtract(vectorN.Multiply(2 * dotVN));
        }

        public override HitRecord IsHitByRay(HitRecord hit)
        {
            hit.Attenuation = Color;
            hit.Roughness = Roughness;
            return hit;
        }

        public override bool Equals(object other)
        {
            Metallic otherMetal = other as Metallic;
            bool baseEquals = base.Equals(otherMetal);
            bool colorEquals = Color.Equals(otherMetal.Color);
            bool roughnessEquals = Roughness == otherMetal.Roughness;
            return baseEquals && colorEquals && roughnessEquals;
        }
    }
}
