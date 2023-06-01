using System;

namespace BusinessLogic
{
    public class Metallic
    {
        private string _name;

        public Metallic() { }

        public Metallic(string name, Color color, string user)
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

        public string Owner { get; set; }
        public Color Color { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new BusinessLogicException("Name cannot be empty");
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
            bool ownerEqual = this.Owner == ((Lambertian)other).Owner;
            return namesEqual && ownerEqual;
        }
    }
}
