using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Lambertian
    {
        private String _name;
        private Vector _color;
        static double RGBLowerBound = 0;
        static double RGBUpperBound = 255;

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

        public Vector Color
        {
            get { return _color; }
            set {

                double x =  value.FstValue;
                double y =  value.SndValue;
                double z =  value.ThrdValue;

                ValueInRange(x, RGBLowerBound, RGBUpperBound);
                ValueInRange(y, RGBLowerBound, RGBUpperBound);
                ValueInRange(z, RGBLowerBound, RGBUpperBound);


                if (x != Math.Floor(x) && 
                    y != Math.Floor(y) && 
                    z != Math.Floor(z))
                {
                    throw new ArgumentException("Values must be natural numbers");
                }

                _color = value; }
        }

        private void ValueInRange (double value, double lowerBound, double upperBound)
        {
            if (value < lowerBound || value > upperBound) {
                throw new ArgumentOutOfRangeException("Values must be between 0 and 255");
            }
        }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }
    }
}
