using BusinessLogic;
using Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using DataTransferObjects;
using Repositories.Interfaces;

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
            try
            {
                Sphere sphere = SphereMapper.ConvertToSphere(sphereDTO);
                try
                {
                    _repository.AddSphere(sphere);
                }
                catch (Exception ex)
                {
                    throw new Exception("User already owns sphere with that name");
                }
            }
            catch (BusinessLogicException ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public void RemoveSphere(string name, string ownerName)
        {
            try
            {
                _repository.RemoveSphere(name, ownerName);
            }
            catch
            {
                throw new Exception("Cannot remove a sphere that is being used by a model");
            }            
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
