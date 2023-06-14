namespace DataTransferObjects.DTOs
{
    public class PpmDTO
    {
        public int Width { get; set; }
        public int Heigth { get; set; }
        public ColorDTO[,] Pixels { get; set; }

        public PpmDTO() { }

        public PpmDTO(int width, int height)
        {
            Width = width;
            Heigth = height;
            Pixels = new ColorDTO[height, width];
        }
    }
}
