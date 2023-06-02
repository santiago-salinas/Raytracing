using BusinessLogic;
using DataTransferObjects;
using Repositories.Interfaces;
using System.Collections.Generic;


namespace Services
{
    public class MaterialManagementService
    {
        private IMaterialRepository _repository;
            

        public MaterialManagementService(IMaterialRepository repository)
        {
            _repository = repository;            
        }

        public void AddLambertian(MaterialDTO lambertianDTO)
        {
            Material lambertian = MaterialMapper.ConvertToMaterial(lambertianDTO);
            _repository.AddLambertian(lambertian);
        }

        public void RemoveLambertian(string name, string ownerName)
        {
            _repository.RemoveLambertian(name, ownerName);
        }

        public Material GetLambertian(string name, string ownerName)
        {            
            return _repository.GetLambertian(name, ownerName);
        }

        public bool ContainsLambertian(string lambertianName, string ownerName)
        {
            return _repository.ContainsLambertian(lambertianName, ownerName);
        }

        public List<MaterialDTO> GetLambertiansFromUser(string owner)
        {
            List<Material> lambertians = _repository.GetLambertiansFromUser(owner);
            List<MaterialDTO> lambertianDTOs = ConvertListToDTOs(lambertians);
            return lambertianDTOs;
        }
        private List<MaterialDTO> ConvertListToDTOs(List<Material> lambertians)
        {
            List<MaterialDTO> lambertianDTOs = new List<MaterialDTO>();

            foreach (Material lambertian in lambertians)
            {
                MaterialDTO lambertianDTO = MaterialMapper.ConvertToDTO(lambertian);
                lambertianDTOs.Add(lambertianDTO);
            }

            return lambertianDTOs;
        }

    }
}
