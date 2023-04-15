using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Vector
    {
        private double _fstValue;
        private double _sndValue;
        private double _thrdValue;

        public double FstValue { get; set; }
        public double SndValue { get; set; }
        public double ThrdValue { get; set; }

        public Vector()
        {
            
        }

        public Vector(int x, int y, int z)
        {
            if (x < 0 || x > 255 || y < 0 || y > 255 || z < 0 || z > 255)
            {
                throw new ArgumentOutOfRangeException("Values must be natural and between 0 and 255");
            }

            _fstValue = x;
            _sndValue = y;
            _thrdValue = z;
        }

    }
}
