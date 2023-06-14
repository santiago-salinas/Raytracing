namespace DataTransferObjects.DTOs
{
    public class PositionedModelDTO
    {
        public PositionedModelDTO() { }
        public ModelDTO ModelDTO { get; set; }
        public VectorDTO Position { get; set; }
    }
}
