using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class HitRecord
    {
        private bool _isHit;
        private double _tDistanceFromOrigin;
        private Vector _intersection;
        private Vector _normal;

        public bool IsHit
        {
            get { return _isHit; }
            set { _isHit = value; }
        }

        public double TDistanceFromOrigin
        {
            get { return _tDistanceFromOrigin; }
            set { _tDistanceFromOrigin = value; }
        }

        public Vector Intersection
        {
            get { return _intersection; }
            set { _intersection = value; }
        }

        public Vector Normal
        {
            get { return _normal; }
            set { _normal = value; }
        }
    }
}
