using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Objects
{
    public class Color
    {
        private double _redValue;
        private double _greenValue;
        private double _blueValue;

      

        public Color(double r, double g, double b)
        {
            Red = r;
            Green = g;
            Blue = b;
        }

        public double Red
        {
            get { return _redValue; }
            set {
                bool isBetweenBounds = value >= 0 && value <= 1;
                if(isBetweenBounds)
                {
                    _redValue = value;
                }
                else
                {
                    throw new ArgumentException("Color value must be between 0 and 1");
                }                
            }
        }
        public double Green
        {
            get { return _greenValue; }
            set {
                bool isBetweenBounds = value >= 0 && value <= 1;
                if (isBetweenBounds)
                {
                    _greenValue = value;
                }
                else
                {
                    throw new ArgumentException("Color value must be between 0 and 1");
                }
            }
        }
        public double Blue
        {
            get { return _blueValue; }
            set {
                bool isBetweenBounds = value >= 0 && value <= 1;
                if (isBetweenBounds)
                {
                    _blueValue = value;
                }
                else
                {
                    throw new ArgumentException("Color value must be between 0 and 1");
                }
            }
        }

        public override bool Equals(object other)
        {
            Color otherVector = (Color)other;
            const double tolerance = 0.0001;

            bool evalFst = Math.Abs(Red - otherVector.Red) < tolerance;
            bool evalSnd = Math.Abs(Green - otherVector.Green) < tolerance;
            bool evalThrd = Math.Abs(Blue - otherVector.Blue) < tolerance;

            return evalFst && evalSnd && evalThrd;
        }
    }
}
