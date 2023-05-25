using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public class ModelDTO
    {
        public string Name { get; set; }
        public SphereDTO Shape { get; set; }
        public LambertianDTO Material { get; set; }
        public string OwnerName { get; set; }
        public PpmDTO Preview { get; set; }

        public ModelDTO() { }

    }
}
