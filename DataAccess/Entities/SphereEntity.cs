using BusinessLogic.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccess.Entities
{
    public class SphereEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [ForeignKey(nameof(Owner))]
        [Column(Order = 2)]
        public string OwnerId { get; set; }

        public UserEntity Owner { get; set; }
        public double Radius { get; set; }


        public static SphereEntity FromDomain(Sphere sphere, EFContext efContext)
        {
            string owner = sphere.Owner;
            UserEntity userEntity;

            userEntity = efContext.UserEntities.FirstOrDefault(u => u.Username == owner);

            SphereEntity ret = new SphereEntity()
            {
                Name = sphere.Name,
                Radius = sphere.Radius,
                Owner = userEntity,
            };

            return ret;
        }

        public static Sphere FromEntity(SphereEntity entity)
        {
            Sphere ret = new Sphere()
            {
                Name = entity.Name,
                Owner = entity.OwnerId,
                Radius = entity.Radius,
            };
            return ret;
        }
    }
}
