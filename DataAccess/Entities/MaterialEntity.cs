using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

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
            return LambertianEntity.FromEntity(entity.Lambertian);
        }

        public static MaterialEntity FromDomain(Material material, EFContext context)
        {
            LambertianEntity lamEntity = LambertianEntity.FromDomain(material as Lambertian, context);
            return lamEntity.Material;
        }
    }
}
