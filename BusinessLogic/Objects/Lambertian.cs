using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;

namespace BusinessLogic
{
    public class Lambertian
    {
        private String _name;
        private Color _color;
        //static double RGBLowerBound = 0;
        //static double RGBUpperBound = 255;

        public Lambertian() { }

        public Lambertian(string name, Color color)
        {
            Name = name;
            Color = color;
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

        public Color Color
        {
            get { return _color; }
            set {
                /*
                double x =  value.FstValue;
                double y =  value.SndValue;
                double z =  value.ThrdValue;

                ValueInRange(x, RGBLowerBound, RGBUpperBound);
                ValueInRange(y, RGBLowerBound, RGBUpperBound);
                ValueInRange(z, RGBLowerBound, RGBUpperBound);

                DoubleHasNoDecimal(x);
                DoubleHasNoDecimal(y);
                DoubleHasNoDecimal(z);
                */
                _color = value; 
            }
        }

        /*private void ValueInRange (double value, double lowerBound, double upperBound)
        {
            if (value < lowerBound || value > upperBound) {
                throw new ArgumentOutOfRangeException("Values must be between 0 and 255");
            }
        }

        private void DoubleHasNoDecimal(double value)
        {
            if (value != Math.Floor(value))
            {
                throw new ArgumentException("Values must be natural numbers");
            }
        }*/

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be null");
            }
        }

        public override bool Equals(object other)
        {
            return this.Name == ((Lambertian)other).Name && this.Color == ((Lambertian)other).Color;
        }
    }
}
