using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Controllers
{
    public class SphereController
    {
        private SphereRepository _repository;
        public SphereController(SphereRepository sphereRepo) {
            _repository = sphereRepo;
        }

        public void AddSphere(SphereDTO sphereDTO)
        {
            // Convert the SphereDTO to a Sphere object
            Sphere sphere = ConvertToSphere(sphereDTO);

            // Add the sphere to the repository
            _repository.AddSphere(sphere);
        }

        public void RemoveSphere(string name, string ownerName)
        {
            // Remove the sphere from the repository
            _repository.RemoveSphere(name, ownerName);
        }

        private bool ContainsSphere(string sphereName, string ownerName)
        {
            return _repository.ContainsSphere(sphereName, ownerName);
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {
            // Get the spheres from the repository
            List<Sphere> spheres = _repository.GetSpheresFromUser(owner);

            // Convert the spheres to SphereDTO objects
            List<SphereDTO> sphereDTOs = ConvertToSphereDTOs(spheres);

            return sphereDTOs;
        }

        public Sphere ConvertToSphere(SphereDTO sphereDTO)
        {
            // Convert the SphereDTO properties to the corresponding Sphere properties
            Sphere sphere = new Sphere
            {
                Name = sphereDTO.Name,
                Radius = sphereDTO.Radius,
                Owner = sphereDTO.OwnerName,
            };

            return sphere;
        }

        private List<SphereDTO> ConvertToSphereDTOs(List<Sphere> spheres)
        {
            List<SphereDTO> sphereDTOs = new List<SphereDTO>();

            foreach (Sphere sphere in spheres)
            {
                // Convert each Sphere to a SphereDTO and add it to the list
                SphereDTO sphereDTO = new SphereDTO
                {
                    Name = sphere.Name,
                    Radius = sphere.Radius,
                    OwnerName = sphere.Owner
                };

                sphereDTOs.Add(sphereDTO);
            }

            return sphereDTOs;
        }
    }
}
