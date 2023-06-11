using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data.Entity;

using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;
using BusinessLogic;

namespace DataAccess
{
    public class ModelEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [ForeignKey(nameof(Owner))]
        [Column(Order = 2)]
        public string OwnerId { get; set; }
        public UserEntity Owner { get; set; }
        public MaterialEntity Material { get; set; }
        public SphereEntity Shape { get; set; }
        public PPMEntity PPMEntity { get; set; }

        public static Model FromEntity(ModelEntity entity)
        {
            Material material = MaterialEntity.FromEntity(entity.Material);
            Sphere shape = SphereEntity.FromEntity(entity.Shape);

            Model ret = new Model()
            {
                Name = entity.Name,
                Owner = entity.OwnerId,
                Material = material,
                Shape = shape,
                Preview = PPMEntity.FromEntity(entity.PPMEntity),
            };

            return ret;
        }

        public static ModelEntity FromDomain(Model model, EFContext efContext)
        {
            UserEntity userEntity = efContext.UserEntities.FirstOrDefault(u => u.Username == model.Owner);

            string materialName = model.Material.Name;
            string shapeName = model.Shape.Name;
            MaterialEntity materialEntity = efContext.MaterialEntities
                .Include(m => m.Lambertian)
                .Include(m => m.Metallic)
                .FirstOrDefault(m => m.OwnerId == userEntity.Username && m.Name == materialName);
            SphereEntity sphereEntity = efContext.SphereEntities.FirstOrDefault(s => s.OwnerId == userEntity.Username && s.Name == shapeName);

            ModelEntity ret = new ModelEntity()
            {
                Name = model.Name,
                Owner = userEntity,
                Material = materialEntity,
                Shape = sphereEntity,
                PPMEntity = PPMEntity.FromDomain(model.Preview)
            };

            return ret;
        }
    }
}
