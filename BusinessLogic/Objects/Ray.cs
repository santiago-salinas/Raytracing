using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Objects
{
    public class Ray
    {
        private Vector _origin;
        private Vector _direction;

        public Ray(Vector vectorOrigin, Vector vectorDirection)
        {
            _origin = vectorOrigin;
            _direction = vectorDirection;
        }

        public Vector Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Vector Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public Vector PointAt(double iPosX)
        {
            return _origin.Add(_direction.Multiply(iPosX)); // origin + (t * direction)
        }
    }

}
