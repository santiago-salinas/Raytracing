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
        public static MaterialDTO ConvertToDTO(Material lambertian)
        {
            MaterialDTO lambertianDTO = new MaterialDTO()
            {
                Name = lambertian.Name,
                Owner = lambertian.Owner,
                Color = ColorMapper.ConvertToDTO(lambertian.Preview),
                Type = "lambertian",
            };

            return lambertianDTO;
        }

        public static Material ConvertToMaterial(MaterialDTO dto)
        {
            Material ret = null;

            if(dto.Type == "lambertian")
            {
                ret = new Lambertian()
                {
                    Name = dto.Name,
                    Owner = dto.Owner,
                    Color = ColorMapper.ConvertToColor(dto.Color),
                };
            }else if(dto.Type == "metallic")
            {
                ret = new Metallic()
                {
                    Name = dto.Name,
                    Owner = dto.Owner,
                    Color = ColorMapper.ConvertToColor(dto.Color),
                };
            }

            return ret;
        }
    }
}
