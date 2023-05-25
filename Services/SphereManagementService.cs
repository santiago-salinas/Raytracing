using BusinessLogic;
using Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using DataTransferObjects;

namespace Services
{
    public class SphereManagementService
    {
        private ISphereRepository _repository;

        public SphereManagementService(ISphereRepository sphereRepo)
        {
            _repository = sphereRepo;
        }

        public void AddSphere(SphereDTO sphereDTO)
        {
            Sphere sphere = ConvertToSphere(sphereDTO);
            _repository.AddSphere(sphere);
        }

        public void RemoveSphere(string name, string ownerName)
        {
            _repository.RemoveSphere(name, ownerName);
        }

        public SphereDTO GetSphere(string name, string owner)
        {
            Sphere sphere = _repository.GetSphere(name, owner);
            return ConvertToDTO(sphere);
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {
            List<Sphere> spheres = _repository.GetSpheresFromUser(owner);
            return ConvertToSphereDTOs(spheres);
        }

        private Sphere ConvertToSphere(SphereDTO sphereDTO)
        {
            Sphere sphere = new Sphere
            {
                Name = sphereDTO.Name,
                Radius = sphereDTO.Radius,
                Owner = sphereDTO.OwnerName,
            };

            return sphere;
        }

        private SphereDTO ConvertToDTO(Sphere sphere)
        {
            SphereDTO sphereDTO = new SphereDTO
            {
                Name = sphere.Name,
                Radius = sphere.Radius,
                OwnerName = sphere.Owner
            };

            return sphereDTO;
        }

        private List<SphereDTO> ConvertToSphereDTOs(List<Sphere> spheres)
        {
            List<SphereDTO> sphereDTOs = new List<SphereDTO>();

            foreach (Sphere sphere in spheres)
            {
                SphereDTO sphereDTO = ConvertToDTO(sphere);
                sphereDTOs.Add(sphereDTO);
            }

            return sphereDTOs;
        }
    }
}
