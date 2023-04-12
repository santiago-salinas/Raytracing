using System;

namespace BusinessLogic
{
    public class Sphere
    {
        public Sphere() { }

        private float _radius;
        private string _name;
        public float Radius
        {
            get { return _radius; }
            set {
                if (value <=0)
                {
                    throw new BusinessLogicException("Radius must be a value over zero >0");
                }
                _radius = value;
            }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}