using System;
using BusinessLogic.Exceptions;


namespace BusinessLogic
{
    public class Metallic : Material
    {
        private const int _lowerBoundForPercentages = 0;
        private const int _upperBoundForPercentages = 1;
        private double _roughness;

        public Metallic() { }

        public Metallic(string name, Color color, string user)
        {
            Name = name;
            Color = color;
            Owner = user;
        }

        public Color Color { get; set; }
        public double Roughness {
            get
            {
                return _roughness;
            }
            set {
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
            return Type + ":\nRGB (" + Color.ToString() + ")\nRoughness: "+Roughness;
        }

        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new BusinessLogicException("Name cannot be empty");
            }
        }

        public override Ray GetBouncedRay(HitRecord hitRecord)
        {
            Vector newVectorPoint = Reflect(hitRecord.Inray.Direction.GetUnit(), hitRecord.Normal);
            newVectorPoint = newVectorPoint.Add(Vector.GetRandomInUnitSphere().Multiply(hitRecord.Roughness));
            Ray newRay = new Ray(hitRecord.Intersection, newVectorPoint);

            if(newRay.Direction.Dot(hitRecord.Normal) > 0)
            {
                return newRay;
            }
            
            newRay.Nulleable = true;
            return newRay;
        }

        public Vector Reflect(Vector vectorV,Vector vectorN)
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
    }
}
