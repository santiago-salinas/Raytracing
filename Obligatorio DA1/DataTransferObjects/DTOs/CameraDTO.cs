namespace DataTransferObjects
{
    public class CameraDTO
    {
        public VectorDTO LookFrom { get; set; }
        public VectorDTO LookAt { get; set; }
        public VectorDTO Up { get; set; }
        public int FieldOfView { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int SamplesPerPixel { get; set; }
        public int MaxDepth { get; set; }

        public CameraDTO() { }
    }


}
