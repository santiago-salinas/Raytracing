using System;

namespace BusinessLogic
{
    public class PositionedModel
    {
        public PositionedModel()
        {
        }

        public Model PositionedModelModel { get; set; }
        public Vector PositionedModelPosition { get; set; }

        public HitRecord IsModelHit(Ray ray, double tMin, double tMax)
        {
            return PositionedModelModel.IsHitByRay(ray, tMin, tMax, PositionedModelPosition);
        }

        public Ray GetBouncedRay(HitRecord hitRecord)
        {
            return PositionedModelModel.GetBouncedRay(hitRecord);
        }

        public override bool Equals(object other)
        {
            bool evalModel = this.PositionedModelModel == ((PositionedModel)other).PositionedModelModel;
            bool evalPosition = this.PositionedModelPosition == ((PositionedModel)other).PositionedModelPosition;

            return evalModel && evalPosition;
        }
    }
}