using BusinessLogic.Utilities;

namespace BusinessLogic.Objects
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

        public override bool Equals(object other)
        {
            PositionedModel otherModel = other as PositionedModel;
            bool modelIsEqual = Model.Equals(otherModel.Model);
            bool positionIsEqual = Position.Equals(otherModel.Position);
            return modelIsEqual && positionIsEqual;
        }

    }
}