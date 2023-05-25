using BusinessLogic;
using DataTransferObjects;
using Repositories.Interfaces;
using System.Collections.Generic;


namespace Services
{
    public class MaterialManagementService
    {
        private IMaterialRepository _repository;
        private ColorConverter _colorConverter;

        public MaterialManagementService(IMaterialRepository repository, ColorConverter converter)
        {
            _repository = repository;
            _colorConverter = converter;
        }

        public void AddLambertian(LambertianDTO lambertianDTO)
        {
            Lambertian lambertian = ConvertToLambertian(lambertianDTO);
            _repository.AddLambertian(lambertian);
        }

        public void RemoveLambertian(string name, string ownerName)
        {
            _repository.RemoveLambertian(name, ownerName);
        }

        public LambertianDTO GetLambertian(string name, string ownerName)
        {
            Lambertian lambertian = _repository.GetLambertian(name, ownerName);
            return ConvertToDTO(lambertian);
        }

        private bool ContainsLambertian(string lambertianName, string ownerName)
        {
            return _repository.ContainsLambertian(lambertianName, ownerName);
        }

        public List<LambertianDTO> GetLambertiansFromUser(string owner)
        {
            List<Lambertian> lambertians = _repository.GetLambertiansFromUser(owner);
            List<LambertianDTO> lambertianDTOs = ConvertToLambertianDTOs(lambertians);
            return lambertianDTOs;
        }

        public Lambertian ConvertToLambertian(LambertianDTO dto)
        {
            Lambertian lambertian = new Lambertian()
            {
                Name = dto.Name,
                Owner = dto.Owner,
                Color = _colorConverter.ConvertToColor(dto.Color),
            };

            return lambertian;

        }
        private List<LambertianDTO> ConvertToLambertianDTOs(List<Lambertian> lambertians)
        {
            List<LambertianDTO> lambertianDTOs = new List<LambertianDTO>();

            foreach (Lambertian lambertian in lambertians)
            {
                LambertianDTO lambertianDTO = ConvertToDTO(lambertian);
                lambertianDTOs.Add(lambertianDTO);
            }

            return lambertianDTOs;
        }

        public LambertianDTO ConvertToDTO(Lambertian lambertian)
        {
            LambertianDTO lambertianDTO = new LambertianDTO()
            {
                Name = lambertian.Name,
                Owner = lambertian.Owner,
                Color = _colorConverter.ConvertToColorDTO(lambertian.Color),
            };

            return lambertianDTO;
        }
    }
}
