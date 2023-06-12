using BusinessLogic.Objects;
using BusinessLogic.Utilities;
using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

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

            PPM ppm = null;
            if (entity.PPMEntity != null)
            {
                ppm = PPMEntity.FromEntity(entity.PPMEntity);
            }

            Model ret = new Model()
            {
                Name = entity.Name,
                Owner = entity.OwnerId,
                Material = material,
                Shape = shape,
                Preview = ppm,
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


            PPMEntity ppm = null;
            if (model.Preview != null)
            {
                ppm = PPMEntity.FromDomain(model.Preview);
            }

            ModelEntity ret = new ModelEntity()
            {
                Name = model.Name,
                Owner = userEntity,
                Material = materialEntity,
                Shape = sphereEntity,
                PPMEntity = ppm,
            };

            return ret;
        }
    }
}
