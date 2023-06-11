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

        public void AddMaterial(MaterialDTO lambertianDTO)
        {
            Material lambertian = MaterialMapper.ConvertToMaterial(lambertianDTO);
            _repository.AddMaterial(lambertian);
        }

        public void RemoveMaterial(string name, string ownerName)
        {
            _repository.RemoveMaterial(name, ownerName);
        }

        public Material GetLambertian(string name, string ownerName)
        {            
            return _repository.GetMaterial(name, ownerName);
        }

        public bool ContainsLambertian(string lambertianName, string ownerName)
        {
            return _repository.ContainsMaterial(lambertianName, ownerName);
        }

        public List<MaterialDTO> GetMaterialsFromUser(string owner)
        {
            List<Material> lambertians = _repository.GetMaterialsFromUser(owner);
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
