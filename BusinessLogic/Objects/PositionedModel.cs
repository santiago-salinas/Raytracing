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

                       
        public override bool Equals(object other)
        {
            bool evalModel = this.PositionedModelModel == ((PositionedModel)other).PositionedModelModel;
            bool evalPosition = this.PositionedModelPosition == ((PositionedModel)other).PositionedModelPosition;

            return evalModel && evalPosition;
        }
    }
}