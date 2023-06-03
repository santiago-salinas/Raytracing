using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataTransferObjects
{
    public class MaterialDTO
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public ColorDTO Color { get; set; }
        public double Roughness { get; set; }

        public string Info { get; set; }
        public MaterialDTO() { }

    }
}
