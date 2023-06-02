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
        public double Roughness { get; set; }


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
            Vector newVectorPoint = Reflect(hitRecord.Inray.Direction.GetUnit(), hitRecord.Normal);
            newVectorPoint = newVectorPoint.Add(Vector.GetRandomInUnitSphere().Multiply(hitRecord.Roughness));
            Vector newVector = newVectorPoint.Subtract(hitRecord.Intersection);
            Ray newRay = new Ray(hitRecord.Intersection, newVector);
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
            return hit;
        }
    }
}
