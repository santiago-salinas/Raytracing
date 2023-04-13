using System;

namespace BusinessLogic
{
    public class Sphere : UserObject
    {
        public Sphere() { }

        private float _radius;
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
    }
}