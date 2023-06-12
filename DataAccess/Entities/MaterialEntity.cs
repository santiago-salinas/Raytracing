using BusinessLogic.Objects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities
{
    public class MaterialEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [ForeignKey(nameof(Owner))]
        [Column(Order = 2)]
        public string OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public LambertianEntity Lambertian { get; set; }
        public MetallicEntity Metallic { get; set; }

        public static Material FromEntity(MaterialEntity entity)
        {
            if (entity.Lambertian != null)
            {
                return LambertianEntity.FromEntity(entity.Lambertian);
            }
            else
            {
                return MetallicEntity.FromEntity(entity.Metallic);
            }
        }

        public static MaterialEntity FromDomain(Material material, EFContext context)
        {
            if (material.Type == "lambertian")
            {
                LambertianEntity lamEntity = LambertianEntity.FromDomain(material as Lambertian, context);
                return lamEntity.Material;
            }
            else
            {
                MetallicEntity metEntity = MetallicEntity.FromDomain(material as Metallic, context);
                return metEntity.Material;
            }
        }
    }
}
