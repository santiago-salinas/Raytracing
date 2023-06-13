using System;

namespace BusinessLogic
{
    public class Metalic : Material
    {
        private string _name;
        private double _roughness;

        public Metalic() { }

        public Metalic(string name, Color color, User user)
        {
            Name = name;
            Color = color;
            Owner = user;
        }

        public Color Color { get; set; }

        public double Roughness {
            get {
                return _roughness;
                }

            set {
                if (value >= 0)
                {
                    _roughness = value;
                }
                else
                {
                    throw new ArgumentException("Roughness value must be a positive number");
                }
            }
        }
        public override Ray GetBouncedRay(Ray rayin, HitRecord hitRecord)
        {
            Vector vectorReflected = Reflect(rayin.Direction.GetUnit(), hitRecord.Normal);
            Vector dir = vectorReflected.Add(Vector.GetRandomInUnitSphere().Multiply(Roughness));
            Ray rayScattered = new Ray(hitRecord.Intersection, dir);

            if (dir.Dot(hitRecord.Normal) > 0)
            {
                return rayScattered;

            }
            rayScattered.Exists = false;

            return rayScattered;
        }

        private Vector Reflect(Vector v, Vector n)
        {
            double dotVN = v.Dot(n);
            return v.Subtract(n.Multiply(2 * dotVN));
        }

        public override HitRecord AddToHit(HitRecord hitRecord)
        {
            hitRecord.Roughness = Roughness;
            hitRecord.Attenuation = Color;
            return hitRecord;
        }


        public override bool Equals(object other)
        {
            bool namesEqual = this.Name == ((Metalic)other).Name;
            bool colorEqual = this.Color == ((Metalic)other).Color;
            return namesEqual && colorEqual;
        }
    }
}
