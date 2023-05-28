using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class ColorDTO
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public ColorDTO() { }

        public ColorDTO(int red, int green, int blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
