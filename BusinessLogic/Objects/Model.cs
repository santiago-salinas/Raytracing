using System;

namespace BusinessLogic
{
    public class Model
    {
        private string _name;
        private Sphere _shape;
        private Lambertian _color;
        private User _owner;
        private PPM _preview;
        public Model() { }

        public Model(string name, Sphere shape, Lambertian color, User owner)
        {
            Name = name;
            ModelShape = shape;
            ModelColor = color;
            Owner = owner;
        }

        public HitRecord IsHitByRay(Ray ray, double tMin, double tMax, Vector position)
        {
            HitRecord hit = ModelShape.IsHitByRay(ray, tMin, tMax, position);
            hit.Attenuation = ModelColor.Color;
            return hit;
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            return ModelColor.GetBouncedRay(hitRecord);
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

        public User Owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        
        public Sphere ModelShape { get; set; }

        public Lambertian ModelColor { get; set; }

        public PPM Preview { get; set; }

        public override bool Equals(object other)
        {
            bool nameEqual = this.Name == ((Model)other).Name;
            bool shapeEqual = this.ModelShape == ((Model)other).ModelShape;
            bool colorEqual = this.ModelColor == ((Model)other).ModelColor;

            return nameEqual && shapeEqual && colorEqual;
        }
    }
}
