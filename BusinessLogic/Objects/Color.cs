using System;

namespace BusinessLogic
{
    public class Color
    {
        private double _redValue;
        private double _greenValue;
        private double _blueValue;

        private const int lowerBoundForPercentages = 0;
        private const int upperBoundForPercentages = 1;


        public Color(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public double Red
        {
            get
            {
                return PercentageTo255(_redValue);
            }
            set
            {
                if (ValueIsBetweenStrictBounds(value, lowerBoundForPercentages, upperBoundForPercentages))
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
            get
            {
                return PercentageTo255(_greenValue);
            }
            set
            {
                if (ValueIsBetweenStrictBounds(value, lowerBoundForPercentages, upperBoundForPercentages))
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
            get
            {
                return PercentageTo255(_blueValue);
            }
            set
            {
                if (ValueIsBetweenStrictBounds(value, lowerBoundForPercentages, upperBoundForPercentages))
                {
                    _blueValue = value;
                }
                else
                {
                    throw new ArgumentException("Color value must be between 0 and 1");
                }
            }
        }

        public double PercentageTo255(double value)
        {
            return Math.Abs((int)Math.Round(value * 255));
        }

        public bool ValueIsBetweenStrictBounds(double value, double min, double max)
        {
            return value >= min && value <= max;
        }

        public Color MultiplyBy(double value)
        {
            double firstProduct = _redValue * value;
            double secondProduct = _greenValue * value;
            double thirdProduct = _blueValue * value;

            return new Color(firstProduct, secondProduct, thirdProduct);
        }

        public Color Add(Color other)
        {
            double firstSum = _redValue + other._redValue;
            double secondSum = _greenValue + other._greenValue;
            double thirdSum = _blueValue + other._blueValue;

            return new Color(firstSum, secondSum, thirdSum);
        }
        public override bool Equals(object other)
        {
            Color otherVector = (Color)other;
            const double tolerance = 0.0001;

            bool firstEval = Math.Abs(Red - otherVector.Red) < tolerance;
            bool secondEval = Math.Abs(Green - otherVector.Green) < tolerance;
            bool thirdEval = Math.Abs(Blue - otherVector.Blue) < tolerance;

            return firstEval && secondEval && thirdEval;
        }
    }
}
