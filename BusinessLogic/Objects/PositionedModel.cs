using BusinessLogic.Objects;
using System.Diagnostics;

namespace BusinessLogic
{
    public class PositionedModel
    {
        public PositionedModel()
        {
        }

        public Model PositionedModelModel { get; set; }
        public Vector PositionedModelPosition { get; set; }

        public Color shootRay(Ray ray)
        {
            double tDistanceFromOrigin = PositionedModelModel.ModelShape.isSphereHit(ray, PositionedModelPosition);
            if (tDistanceFromOrigin>0)
            {
                Vector surfaceNormal = ray.PointAt(tDistanceFromOrigin).Subtract(PositionedModelPosition);
                Vector unitSurfaceNormal = surfaceNormal.GetUnit();
                Color vectorColor = new Color(
                    (unitSurfaceNormal.FirstValue + 1)/2,
                    (unitSurfaceNormal.SecondValue + 1)/2,
                    (unitSurfaceNormal.ThirdValue + 1) / 2);
                return vectorColor;

                //return PositionedModelModel.ModelColor.Color;
            }
            else
            {
                return GetSkyBoxColor(ray);
            }
        }

        public Color GetSkyBoxColor(Ray ray)
        {
            Vector vectorDirectionUnit = ray.Direction.GetUnit();
            double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
            Color colorStart = new Color(1, 1, 1);
            Color colorEnd = new Color(0.5, 0.7, 1);
            return colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
        }
                
        public override bool Equals(object other)
        {
            bool evalModel = this.PositionedModelModel == ((PositionedModel)other).PositionedModelModel;
            bool evalPosition = this.PositionedModelPosition == ((PositionedModel)other).PositionedModelPosition;

            return evalModel && evalPosition;
        }
    }
}