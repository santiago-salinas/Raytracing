using BusinessLogic.DomainObjects;
using BusinessLogic.Exceptions;
using BusinessLogic.Utilities;
using System;

namespace BusinessLogic.DomainObjects
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
                throw new BusinessLogicException("Name cant be null");
            }
        }


        public Sphere Shape { get; set; }

        public Material Material { get; set; }

        public PPM Preview { get; set; }

        public override bool Equals(object other)
        {
            Model otherAsModel = other as Model;
            bool nameEqual = Name == otherAsModel.Name;
            bool shapeEqual = Shape.Equals(otherAsModel.Shape);
            bool materialEqual = Material.Equals(otherAsModel.Material);

            return nameEqual && shapeEqual && materialEqual;
        }

    }
}
