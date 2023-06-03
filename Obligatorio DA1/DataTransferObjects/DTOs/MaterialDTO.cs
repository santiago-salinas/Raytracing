using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTransferObjects
{
    public class MaterialDTO
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public ColorDTO Color { get; set; }

        public MaterialDTO() { }

        public MaterialDTO(string name, string owner, ColorDTO color)
        {
            Name = name;
            Owner = owner;
            Color = color;
        }
    }
}
