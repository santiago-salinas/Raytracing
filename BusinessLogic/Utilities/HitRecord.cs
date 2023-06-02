
namespace BusinessLogic
{
    public class HitRecord
    {
        public bool IsHit { get; set; }

        public double TDistanceFromOrigin { get; set; }

        public Vector Intersection { get; set; }

        public Vector Normal { get; set; }

        public Color Attenuation { get; set; }
        public Ray Inray { get; set; }
        public double Roughness { get; set; }

    }
}
