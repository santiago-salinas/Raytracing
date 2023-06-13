using BusinessLogic.DomainObjects;

namespace DataTransferObjects
{
    public static class MaterialMapper
    {
        public static MaterialDTO ConvertToDTO(Material material)
        {
            MaterialDTO materialDTO = new MaterialDTO()
            {
                Name = material.Name,
                Owner = material.Owner,
                Color = ColorMapper.ConvertToDTO(material.Preview),
                Type = material.Type,
                Info = material.ToString(),
            };

            if (material.Type == "metallic")
            {
                materialDTO.Roughness = ((Metallic)material).Roughness;
            }
            return materialDTO;
        }

        public static Material ConvertToMaterial(MaterialDTO dto)
        {
            Material ret = null;

            if (dto.Type == "lambertian")
            {
                ret = new Lambertian()
                {
                    Name = dto.Name,
                    Owner = dto.Owner,
                    Color = ColorMapper.ConvertToColor(dto.Color),
                };
            }
            else if (dto.Type == "metallic")
            {
                ret = new Metallic()
                {
                    Name = dto.Name,
                    Owner = dto.Owner,
                    Color = ColorMapper.ConvertToColor(dto.Color),
                    Roughness = dto.Roughness,
                };
            }

            return ret;
        }
    }
}
