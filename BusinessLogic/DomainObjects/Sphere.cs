﻿using BusinessLogic.Exceptions;
using BusinessLogic.Utilities;
using System;

namespace BusinessLogic.DomainObjects
{
    public class Sphere
    {

        public Sphere() { }
        public Sphere(string name, double radius, string owner)
        {
            Name = name;
            Radius = radius;
            Owner = owner;
        }

        private const int _minimumRadius = 0;
        private double _radius;
        private string _name;
        public double Radius
        {
            get { return _radius; }
            set
            {
                if (value <= _minimumRadius)
                {
                    throw new BusinessLogicException("Radius must be a value over zero");
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

        public string Owner { get; set; }

        private void CheckIfStringNull(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                throw new BusinessLogicException("Name cannot be empty");
            }
        }

        public HitRecord IsHitByRay(Ray ray, double tMin, double tMax, Vector position)
        {
            Vector vectorOriginCenter = ray.Origin.Subtract(position);
            double a = ray.Direction.Dot(ray.Direction);
            double b = vectorOriginCenter.Dot(ray.Direction) * 2;
            double c = vectorOriginCenter.Dot(vectorOriginCenter) - Radius * Radius;
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                return new HitRecord() { IsHit = false };
            }
            else
            {
                double t = (-1 * b - Math.Sqrt(discriminant)) / (2 * a);
                Vector intersectionPoint = ray.PointAt(t);
                Vector normal = intersectionPoint.Subtract(position).Divide(Radius);
                if (t < tMax && t > tMin)
                {
                    return new HitRecord()
                    {
                        IsHit = true,
                        TDistanceFromOrigin = t,
                        Intersection = intersectionPoint,
                        Normal = normal,
                    };
                }
                else
                {
                    return new HitRecord() { IsHit = false };
                }
            }
        }

        public override bool Equals(object other)
        {
            bool nameEquals = Name == ((Sphere)other).Name;
            bool ownerEquals = Owner == ((Sphere)other).Owner;
            bool radiusEquals = Radius == ((Sphere)other).Radius;
            return nameEquals && ownerEquals && radiusEquals;
        }

    }
}
