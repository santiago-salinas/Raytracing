using System;

namespace BusinessLogic
{
    public class Lambertian
    {
        private string _name;

        public Lambertian() { }

        public Lambertian(string name, Color color, User user)
        {
            Name = name;
            Color = color;
            Owner = user;
        }

        public string Name
        {
            get { return _name; }
            set
            {
                value = value.Trim();
                CheckIfStringNull(value);
                _name = value;
            }
        }

        public User Owner { get; set; }
        public Color Color { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            Vector newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(Vector.GetRandomInUnitSphere());
            Vector newVector = newVectorPoint.Subtract(hitRecord.Intersection);
            Ray newRay = new Ray(hitRecord.Intersection, newVector);

            return newRay;
        }

        public override bool Equals(object other)
        {
            bool namesEqual = this.Name == ((Lambertian)other).Name;
            bool colorEqual = this.Color == ((Lambertian)other).Color;
            return namesEqual && colorEqual;
        }
    }
}
