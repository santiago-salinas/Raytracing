using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace DataAccess.Entities
{
    public class MetallicEntity
    {
        [Key]
        [ForeignKey(nameof(Material))]
        [Column(Order = 1)]
        public string MaterialName { get; set; }

        [Key]
        [ForeignKey(nameof(Material))]
        [Column(Order = 2)]
        public string MaterialOwnerId { get; set; }

        public MaterialEntity Material { get; set; }
        public int RedValue { get; set; }
        public int GreenValue { get; set; }
        public int BlueValue { get; set; }
        public double Roughness { get; set; }

        public static Metallic FromEntity(MetallicEntity entity)
        {
            Color color = new Color()
            {
                Red = (double)entity.RedValue / 255,
                Green = (double)entity.GreenValue / 255,
                Blue = (double)entity.BlueValue / 255
            };
            Metallic ret = new Metallic()
            {
                Name = entity.MaterialName,
                Owner = entity.MaterialOwnerId,
                Color = color,
                Roughness = (double)entity.Roughness,
            };

            return ret;
        }

        public static MetallicEntity FromDomain(Metallic metallic, EFContext efContext)
        {

            string owner = metallic.Owner;
            Color color = metallic.Color;
            UserEntity userEntity = efContext.UserEntities.FirstOrDefault(u => u.Username == owner); ;
            MetallicEntity ret = new MetallicEntity()
            {
                RedValue = (int)color.Red,
                GreenValue = (int)color.Green,
                BlueValue = (int)color.Blue,
                Roughness = metallic.Roughness
            };

            MaterialEntity materialEntity = new MaterialEntity()
            {
                Name = metallic.Name,
                Owner = userEntity,
                Metallic = ret,
            };

            ret.Material = materialEntity;

            return ret;
        }
    }
}
