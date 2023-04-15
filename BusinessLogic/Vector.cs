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

        public Vector()
        {
            
        }

        public Vector(int x, int y, int z)
        {
            _fstValue = x;
            _sndValue = y;
            _thrdValue = z;
        }

    }
}
