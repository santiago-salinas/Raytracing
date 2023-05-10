﻿namespace BusinessLogic
{
    public class PositionedModel
    {
        public PositionedModel()
        {
        }

        public Model Model { get; set; }
        public Vector Position { get; set; }

        public HitRecord IsModelHit(Ray ray, double tMin, double tMax)
        {
            return Model.IsHitByRay(ray, tMin, tMax, Position);
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            return Model.GetBouncedRay(hitRecord);
        }

    }
}