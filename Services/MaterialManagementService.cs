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

        public void AddLambertian(LambertianDTO lambertianDTO)
        {
            Lambertian lambertian = MaterialMapper.ConvertToLambertian(lambertianDTO);
            _repository.AddLambertian(lambertian);
        }

        public void RemoveLambertian(string name, string ownerName)
        {
            _repository.RemoveLambertian(name, ownerName);
        }

        public Lambertian GetLambertian(string name, string ownerName)
        {            
            return _repository.GetLambertian(name, ownerName);
        }

        public bool ContainsLambertian(string lambertianName, string ownerName)
        {
            return _repository.ContainsLambertian(lambertianName, ownerName);
        }

        public List<LambertianDTO> GetLambertiansFromUser(string owner)
        {
            List<Lambertian> lambertians = _repository.GetLambertiansFromUser(owner);
            List<LambertianDTO> lambertianDTOs = ConvertListToDTOs(lambertians);
            return lambertianDTOs;
        }
        private List<LambertianDTO> ConvertListToDTOs(List<Lambertian> lambertians)
        {
            List<LambertianDTO> lambertianDTOs = new List<LambertianDTO>();

            foreach (Lambertian lambertian in lambertians)
            {
                LambertianDTO lambertianDTO = MaterialMapper.ConvertToDTO(lambertian);
                lambertianDTOs.Add(lambertianDTO);
            }

            return lambertianDTOs;
        }

    }
}
