using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DTOs
{
    public class PpmDTO
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public ColorDTO[,] Pixels { get; set; }

        public PpmDTO() { }

        public PpmDTO(int width, int height)
        {
            Width = width;
            Height = height;
            Pixels = new ColorDTO[height, width];
        }
    }
}
