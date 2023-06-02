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
        public static MaterialDTO ConvertToDTO(Material material)
        {
            MaterialDTO lambertianDTO = new MaterialDTO()
            {
                Name = material.Name,
                Owner = material.Owner,
                Color = ColorMapper.ConvertToDTO(material.Preview),
                Type = typeof(Material).ToString(),
            };

            return lambertianDTO;
        }

        public static Material ConvertToMaterial(MaterialDTO dto)
        {
            Material ret = null;

            if(dto.Type == "Lambertian")
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
