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
            if (isSphereHit(ray))
            {
                return PositionedModelModel.ModelColor.Color;
            }
            else
            {
                
                Vector vectorDirectionUnit = ray.Direction.GetUnit();
                double posY = 0.5 * (vectorDirectionUnit.SecondValue + 1);
                Color colorStart = new Color(1, 1, 1);
                Color colorEnd = new Color(0.5, 0.7, 1);
                return colorStart.Multiply(1 - posY).Add(colorEnd.Multiply(posY));
                
                //return new Color(0, 1, 1);
                }
        }

        // Mover a sphere, pasandole los datos de posicion
        public bool isSphereHit(Ray ray)
        {
            var vectorOriginCenter = ray.Origin.Subtract(PositionedModelPosition);
            var a = ray.Direction.Dot(ray.Direction);
            var b = vectorOriginCenter.Dot(ray.Direction) * 2;
            var c = vectorOriginCenter.Dot(vectorOriginCenter) - PositionedModelModel.ModelShape.Radius * PositionedModelModel.ModelShape.Radius;
            var discriminant = b * b - 4 * a * c;
            return discriminant > 0;
        }
        public override bool Equals(object other)
        {
            bool evalModel = this.PositionedModelModel == ((PositionedModel)other).PositionedModelModel;
            bool evalPosition = this.PositionedModelPosition == ((PositionedModel)other).PositionedModelPosition;

            return evalModel && evalPosition;
        }
    }
}