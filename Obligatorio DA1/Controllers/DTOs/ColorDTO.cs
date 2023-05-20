using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DTOs
{
    public class ColorDTO
    {
        public double Red { get; set; }
        public double Green { get; set; }
        public double Blue { get; set; }

        public ColorDTO() { }

        public ColorDTO(double red, double green, double blue)
        {
            Red = red;
            Green = green;
            Blue = blue;
        }
    }
}
