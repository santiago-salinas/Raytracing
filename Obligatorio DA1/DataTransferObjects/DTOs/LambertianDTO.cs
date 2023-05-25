using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers;

namespace Services
{
    public class LambertianDTO
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public ColorDTO Color { get; set; }

        public LambertianDTO() { }

        public LambertianDTO(string name, string owner, ColorDTO color)
        {
            Name = name;
            Owner = owner;
            Color = color;
        }
    }
}
