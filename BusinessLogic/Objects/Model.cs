using BusinessLogic.Utilities;
using System;

namespace BusinessLogic.Objects
{
    public class Model
    {
        private string _name;
        public Model() { }

        public HitRecord IsHitByRay(Ray ray, double tMin, double tMax, Vector position)
        {
            HitRecord hit = Shape.IsHitByRay(ray, tMin, tMax, position);
            hit = Material.IsHitByRay(hit);
            return hit;
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            return Material.GetBouncedRay(hitRecord);
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

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }


        public Sphere Shape { get; set; }

        public Material Material { get; set; }

        public PPM Preview { get; set; }

        public override bool Equals(object other)
        {
            Model otherAsModel = other as Model;
            bool nameEqual = this.Name == otherAsModel.Name;
            bool shapeEqual = this.Shape == ((Model)other).Shape;
            bool colorEqual = this.Material == ((Model)other).Material;

            return nameEqual && shapeEqual && colorEqual;
        }

    }
}
