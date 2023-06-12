using BusinessLogic.Exceptions;
using BusinessLogic.Objects;
using DataTransferObjects;
using RepoInterfaces;
using Services.Exceptions;
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

        public void AddMaterial(MaterialDTO materialDTO)
        {
            try
            {
                Material material = MaterialMapper.ConvertToMaterial(materialDTO);
                if (_repository.ContainsMaterial(material.Name, material.Owner))
                {
                    throw new Service_ArgumentException("User already owns a material with that name");
                }
                _repository.AddMaterial(material);
            }
            catch (BusinessLogicException ex)
            {
                throw new Service_ArgumentException(ex.Message);
            }

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
