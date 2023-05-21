using BusinessLogic;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    public class LambertianController
    {
        private LambertianRepository _repository;

        public LambertianController(LambertianRepository repository)
        {
            _repository = repository;
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
                Color = ConvertToColor(dto.Color),
            };

            return lambertian;

        }


        private List<LambertianDTO> ConvertToLambertianDTOs(List<Lambertian> lambertians)
        {
            List<LambertianDTO> lambertianDTOs = new List<LambertianDTO>();

            foreach (Lambertian lambertian in lambertians)
            {
                LambertianDTO lambertianDTO = new LambertianDTO()
                {
                    Name = lambertian.Name,
                    Owner = lambertian.Owner,
                    Color = ConvertToColorDTO(lambertian.Color),
                };
                lambertianDTOs.Add(lambertianDTO);
            }

            return lambertianDTOs;
        }

        private ColorDTO ConvertToColorDTO(Color color)
        {
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = color.Red,
                Green = color.Green,
                Blue = color.Blue,
            };

            return colorDTO;
        }

        private Color ConvertToColor(ColorDTO colorDTO)
        {
            Color color = new Color()
            {
                Red = colorDTO.Red,
                Green = colorDTO.Green,
                Blue = colorDTO.Blue,
            };

            return color;
        }

    }
}
