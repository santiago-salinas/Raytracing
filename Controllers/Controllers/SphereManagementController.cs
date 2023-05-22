using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Controllers.Interfaces;
using Controllers;

namespace Controllers
{
    public class SphereManagementController : ISphereManagement
    {
        private ISphereRepository _repository;
        public SphereManagementController(ISphereRepository sphereRepo) {
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

        private bool ContainsSphere(string sphereName, string ownerName)
        {
            return _repository.ContainsSphere(sphereName, ownerName);
        }

        public Sphere GetSphere(string name, string owner) 
        {
            return _repository.GetSphere(name, owner);
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {            
            List<Sphere> spheres = _repository.GetSpheresFromUser(owner);            
            List<SphereDTO> sphereDTOs = ConvertToSphereDTOs(spheres);

            return sphereDTOs;
        }

        public Sphere ConvertToSphere(SphereDTO sphereDTO)
        {            
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
