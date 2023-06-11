using BusinessLogic;
using BusinessLogic.Exceptions;
using RepoInterfaces;
using System.Collections.Generic;
using Services.Exceptions;
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
            try
            {
                Sphere sphere = SphereMapper.ConvertToSphere(sphereDTO);
                if(_repository.ContainsSphere(sphere.Name,sphere.Owner)) 
                    throw new Service_ObjectHandlingException("User already owns sphere with that name");
                else
                {
                    _repository.AddSphere(sphere);
                }
            }catch(BusinessLogicException ex) 
            {
                throw new Service_ObjectHandlingException(ex.Message);
            }
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
