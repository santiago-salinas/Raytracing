using System;

namespace BusinessLogic
{
    public class Metallic : Material
    {

        public Metallic() { }

        public Metallic(string name, Color color, string user)
        {
            Name = name;
            Color = color;
            Owner = user;
        }

        public Color Color { get; set; }

        public override Color Preview
        {
            get { return Color; }
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
            Vector newVectorPoint = hitRecord.Intersection.Add(hitRecord.Normal).Add(Vector.GetRandomInUnitSphere());
            Vector newVector = newVectorPoint.Subtract(hitRecord.Intersection);
            Ray newRay = new Ray(hitRecord.Intersection, newVector);

            return newRay;
        }

        public override HitRecord IsHitByRay(HitRecord hit)
        {
            hit.Attenuation = Color;
            return hit;
        }
    }
}
