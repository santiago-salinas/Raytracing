using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DTOs
{
    public class ModelDTO
    {
        public string Name { get; set; }
        public string ShapeName { get; set; }
        public string MaterialName { get; set; }
        public string OwnerName { get; set; }
        public PpmDTO Preview { get; set; }

        public ModelDTO() { }

        public ModelDTO(string name, string shape, string material, string owner)
        {
            Name = name;
            ShapeName = shape;
            MaterialName = material;
            OwnerName = owner;
        }
    }
}
