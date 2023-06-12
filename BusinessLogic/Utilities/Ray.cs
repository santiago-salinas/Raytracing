namespace BusinessLogic.Utilities
{
    public class Ray
    {

        public Ray(Vector vectorOrigin, Vector vectorDirection)
        {
            Origin = vectorOrigin;
            Direction = vectorDirection;
            Nulleable = false;
        }

        public bool Nulleable { get; set; }

        public Vector Origin { get; set; }

        public Vector Direction { get; set; }

        public Vector PointAt(double iPosX)
        {
            return Origin.Add(Direction.Multiply(iPosX));
        }
    }

}
