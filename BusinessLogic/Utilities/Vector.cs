using System;

namespace BusinessLogic
{
    public class Vector
    {
        private double _firstValue;
        private double _secondValue;
        private double _thirdValue;

        public Vector()
        { }

        public Vector(double x, double y, double z)
        {
            FirstValue = x;
            SecondValue = y;
            ThirdValue = z;
        }
        public Vector(int x, int y, int z)
        {
            FirstValue = x;
            SecondValue = y;
            ThirdValue = z;
        }

        public double FirstValue
        {
            get { return _firstValue; }
            set { _firstValue = value; }
        }
        public double SecondValue
        {
            get { return _secondValue; }
            set { _secondValue = value; }
        }
        public double ThirdValue
        {
            get { return _thirdValue; }
            set { _thirdValue = value; }
        }

        public override string ToString()
        {
            return $"({FirstValue} ; {SecondValue} ; {ThirdValue})";
        }
        public override bool Equals(object other)
        {
            Vector otherVector = (Vector)other;
            const double tolerance = 0.0001;

            bool evalFst = Math.Abs(FirstValue - otherVector.FirstValue) < tolerance;
            bool evalSnd = Math.Abs(SecondValue - otherVector.SecondValue) < tolerance;
            bool evalThrd = Math.Abs(ThirdValue - otherVector.ThirdValue) < tolerance;

            return evalFst && evalSnd && evalThrd;
        }

        public Vector Add(Vector other)
        {
            return new Vector(_firstValue + other.FirstValue, _secondValue + other.SecondValue, _thirdValue + other.ThirdValue);
        }

        public Vector Subtract(Vector other)
        {
            return new Vector(_firstValue - other.FirstValue, _secondValue - other.SecondValue, _thirdValue - other.ThirdValue);
        }

        public Vector Multiply(double value)
        {
            return new Vector(_firstValue * value, _secondValue * value, _thirdValue * value);
        }

        public Vector Divide(double value)
        {
            return new Vector(_firstValue / value, _secondValue / value, _thirdValue / value);
        }

        public void AddTo(Vector other)
        {
            _firstValue += other.FirstValue;
            _secondValue += other.SecondValue;
            _thirdValue += other.ThirdValue;
        }

        public void SubtractFrom(Vector other)
        {
            _firstValue -= other.FirstValue;
            _secondValue -= other.SecondValue;
            _thirdValue -= other.ThirdValue;
        }

        public void ScaleUpBy(int iCount)
        {
            _firstValue *= iCount;
            _secondValue *= iCount;
            _thirdValue *= iCount;
        }

        public void ScaleDownBy(int iCount)
        {
            _firstValue /= iCount;
            _secondValue /= iCount;
            _thirdValue /= iCount;
        }

        public double SquaredLength()
        {
            return _firstValue * _firstValue + _secondValue * _secondValue + _thirdValue * _thirdValue;
        }

        public double Length()
        {
            return Math.Sqrt(SquaredLength());
        }
        public Vector GetUnit()
        {
            double length = Length();
            if (length == 0)
            {
                return new Vector(FirstValue, SecondValue, ThirdValue);
            }
            else
            {
                return Divide(length);
            }            
        }

        public double Dot(Vector other)
        {
            return _firstValue * other.FirstValue + _secondValue * other.SecondValue + _thirdValue * other.ThirdValue;
        }

        public Vector Cross(Vector other)
        {
            double x = _secondValue * other.ThirdValue - _thirdValue * other.SecondValue;
            double y = _thirdValue * other.FirstValue - _firstValue * other.ThirdValue;
            double z = _firstValue * other.SecondValue - _secondValue * other.FirstValue;
            return new Vector(x, y, z);
        }
    }
}
