namespace BusinessLogic
{
    public class BLCameraDTO
    {
        public Vector LookFrom { get; set; }
        public Vector LookAt { get; set; }
        public Vector Up { get; set; }
        public int FieldOfView { get; set; }
        public int ResolutionX { get; set; }
        public int ResolutionY { get; set; }
        public int SamplesPerPixel { get; set; }
        public int MaxDepth { get; set; }

        public BLCameraDTO() { }
    }


}
