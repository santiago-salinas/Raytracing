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

        public double FstValue {
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
            bool evalFst = this.FstValue == ((Vector)other).FstValue;
            bool evalSnd = this.SndValue == ((Vector)other).SndValue;
            bool evalThrd = this.ThrdValue == ((Vector)other).ThrdValue;

            return evalFst && evalSnd && evalThrd;
        }



    }
}
