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
                Red = (int)color.Red,
                Green = (int)color.Green,
                Blue = (int)color.Blue,
            };

            return colorDTO;
        }

        private Color ConvertToColor(ColorDTO colorDTO)
        {
            int upperRGBBound = 255;
            int redValue = colorDTO.Red;
            int greenValue = colorDTO.Green;
            int blueValue = colorDTO.Blue;
            if(!IsBetweenBounds(redValue) || !IsBetweenBounds(greenValue) || !IsBetweenBounds(blueValue))
            {
                throw new BusinessLogicException("Inserted RGB values must be between 0 and 255");
            }

            Color color = new Color()
            {   
                Red = (double)colorDTO.Red/ upperRGBBound,
                Green = (double)colorDTO.Green/ upperRGBBound,
                Blue = (double)colorDTO.Blue/ upperRGBBound,
            };

            return color;
        }

        private bool IsBetweenBounds(int value)
        {
            int upperBound = 255;
            int lowerBound = 0;
            return (value >= lowerBound) && (value <= upperBound);
        }

    }
}
