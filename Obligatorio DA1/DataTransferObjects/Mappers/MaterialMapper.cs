using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace DataTransferObjects
{
    public static class MaterialMapper
    {
        public static LambertianDTO ConvertToDTO(Lambertian lambertian)
        {
            LambertianDTO lambertianDTO = new LambertianDTO()
            {
                Name = lambertian.Name,
                Owner = lambertian.Owner,
                Color = ColorMapper.ConvertToDTO(lambertian.Color),
            };

            return lambertianDTO;
        }

        public static Lambertian ConvertToLambertian(LambertianDTO dto)
        {
            Lambertian lambertian = new Lambertian()
            {
                Name = dto.Name,
                Owner = dto.Owner,
                Color = ColorMapper.ConvertToColor(dto.Color),
            };

            return lambertian;

        }
    }
}
