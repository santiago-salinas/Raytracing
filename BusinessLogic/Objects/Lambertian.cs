using System;
using System.Xml.Linq;
using BusinessLogic.Utilities;

namespace BusinessLogic.Objects
{
    public class Lambertian : Material
    {
        public Lambertian() { }


        public Color Color { get; set; }
        public override Color Preview
        {
            get { return Color; }
        }

        public override string Type
        {
            get { return "lambertian"; }
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

        public override string ToString()
        {
            return Type+":\nRGB (" + Color.ToString() + ")";
        }
    }
}
