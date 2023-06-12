using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;

namespace DataTransferObjects
{
    public static class SphereMapper
    {
        public static SphereDTO ConvertToDTO(Sphere sphere)
        {
            SphereDTO sphereDTO = new SphereDTO
            {
                Name = sphere.Name,
                Radius = sphere.Radius,
                OwnerName = sphere.Owner
            };

            return sphereDTO;
        }

        public static Sphere ConvertToSphere(SphereDTO sphereDTO)
        {
            Sphere sphere = new Sphere
            {
                Name = sphereDTO.Name,
                Radius = sphereDTO.Radius,
                Owner = sphereDTO.OwnerName,
            };

            return sphere;
        }
    }
}
