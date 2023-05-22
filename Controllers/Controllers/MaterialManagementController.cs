using BusinessLogic;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using Controllers.Converter;

namespace Controllers.Controllers
{
    public class MaterialManagementController : IMaterialManagement
    {
        private MemoryLambertianRepository _repository;
        private ColorConverter _colorConverter;
        
        public MaterialManagementController(MemoryLambertianRepository repository,ColorConverter converter)
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

        public Lambertian GetLambertian(string name, string ownerName)
        {
            return _repository.GetLambertian(name, ownerName);
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
