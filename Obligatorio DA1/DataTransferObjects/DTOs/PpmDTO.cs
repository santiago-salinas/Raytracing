using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
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
