﻿using System;

namespace BusinessLogic
{
    public class Sphere
    {

        public Sphere() { }
        public Sphere(string name, double radius)
        {
            Name = name;
            Radius = radius;
        }

        private double _radius;
        private string _name;
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= 0)
                {
                    throw new BusinessLogicException("Radius must be a value over zero >0");
                }
                _radius = value;
            }
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

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Name cant be empty");
            }
        }

        public override bool Equals(object other)
        {
            return this.Name == ((Sphere)other).Name && this.Radius == ((Sphere)other).Radius;
        }

    }
}
