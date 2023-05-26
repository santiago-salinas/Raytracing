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
            Sphere sphere = SphereMapper.ConvertToSphere(sphereDTO);
            _repository.AddSphere(sphere);
        }

        public void RemoveSphere(string name, string ownerName)
        {
            _repository.RemoveSphere(name, ownerName);
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {
            List<Sphere> spheres = _repository.GetSpheresFromUser(owner);
            return ConvertToSphereDTOs(spheres);
        }

        private List<SphereDTO> ConvertToSphereDTOs(List<Sphere> spheres)
        {
            List<SphereDTO> sphereDTOs = new List<SphereDTO>();

            foreach (Sphere sphere in spheres)
            {
                SphereDTO sphereDTO = SphereMapper.ConvertToDTO(sphere);
                sphereDTOs.Add(sphereDTO);
            }

            return sphereDTOs;
        }
    }
}
