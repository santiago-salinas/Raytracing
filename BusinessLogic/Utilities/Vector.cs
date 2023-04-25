using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class Vector
    {
        private double _fstValue;
        private double _sndValue;
        private double _thrdValue;

        public Vector()
        { }

        public Vector(double x, double y, double z)
        {
            FstValue = x;
            SndValue = y;
            ThrdValue = z;
        }
        public Vector(int x, int y, int z)
        {
            FstValue = x;
            SndValue = y;
            ThrdValue = z;
        }

        public double FstValue
        {
            get { return _fstValue; }
            set { _fstValue = value; }
        }
        public double SndValue
        {
            get { return _sndValue; }
            set { _sndValue = value; }
        }
        public double ThrdValue
        {
            get { return _thrdValue; }
            set { _thrdValue = value; }
        }

        public override bool Equals(object other)
        {
            Vector otherVector = (Vector)other;
            const double tolerance = 0.0001;

            bool evalFst = Math.Abs(FstValue - otherVector.FstValue) < tolerance;
            bool evalSnd = Math.Abs(SndValue - otherVector.SndValue) < tolerance;
            bool evalThrd = Math.Abs(ThrdValue - otherVector.ThrdValue) < tolerance;

            return evalFst && evalSnd && evalThrd;
        }

        public Vector Add(Vector other)
        {
            return new Vector(_fstValue + other.FstValue, _sndValue + other.SndValue, _thrdValue + other.ThrdValue);
        }

        public Vector Subtract(Vector other)
        {
            return new Vector(_fstValue - other.FstValue, _sndValue - other.SndValue, _thrdValue - other.ThrdValue);
        }

        public Vector Multiply(double value)
        {
            return new Vector(_fstValue * value, _sndValue * value, _thrdValue * value);
        }

        public Vector Divide(double value)
        {
            return new Vector(_fstValue / value, _sndValue / value, _thrdValue / value);
        }

        public void AddTo(Vector other)
        {
            _fstValue += other.FstValue;
            _sndValue += other.SndValue;
            _thrdValue += other.ThrdValue;
        }

        public void SubtractFrom(Vector other)
        {
            _fstValue -= other.FstValue;
            _sndValue -= other.SndValue;
            _thrdValue -= other.ThrdValue;
        }

        public void ScaleUpBy(int iCount)
        {
            _fstValue *= iCount;
            _sndValue *= iCount;
            _thrdValue *= iCount;
        }

        public void ScaleDownBy(int iCount)
        {
            _fstValue /= iCount;
            _sndValue /= iCount;
            _thrdValue /= iCount;
        }

        public double SquaredLength()
        {
            return _fstValue * _fstValue + _sndValue * _sndValue + _thrdValue * _thrdValue;
        }

        public double Length()
        {
            return Math.Sqrt(SquaredLength());
        }
        public Vector GetUnit()
        {
            return Divide(Length());
        }

        public double Dot(Vector other)
        {
            return _fstValue * other.FstValue + _sndValue * other.SndValue + _thrdValue * other.ThrdValue;
        }

        public Vector Cross(Vector other)
        {
            double x = _sndValue * other.ThrdValue - _thrdValue * other.SndValue;
            double y = _thrdValue * other.FstValue - _fstValue * other.ThrdValue;
            double z = _fstValue * other.SndValue - _sndValue * other.FstValue;
            return new Vector(x, y, z);
        }
    }
}
