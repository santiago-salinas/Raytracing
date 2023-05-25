using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.DTOs
{
    public class SphereDTO
    {
        public string Name { get; set; }
        public double Radius { get; set; }
        public string OwnerName { get; set; }

        public SphereDTO() { }

        public SphereDTO(string name, double radius, string ownerName)
        {
            Name = name;
            Radius = radius;
            OwnerName = ownerName;
        }
    }
}