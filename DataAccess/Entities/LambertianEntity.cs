using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccess.Entities;
using BusinessLogic;
using BusinessLogic.Objects;
using BusinessLogic.Utilities;

namespace DataAccess
{
    public class LambertianEntity
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

        public static LambertianEntity FromDomain(Lambertian lambertian, EFContext efContext)
        {
           
            string owner = lambertian.Owner;
            Color color = lambertian.Color;
            UserEntity userEntity = efContext.UserEntities.FirstOrDefault(u => u.Username == owner);
            LambertianEntity ret = new LambertianEntity()
            {
                RedValue = (int)color.Red,
                GreenValue = (int)color.Green,
                BlueValue = (int)color.Blue,
            };

            MaterialEntity materialEntity = new MaterialEntity()
            {
                Name = lambertian.Name,
                Owner = userEntity,
                Lambertian = ret,
            };

            ret.Material = materialEntity;

            return ret;
        }

        public static Lambertian FromEntity(LambertianEntity entity)
        {
            Color color = new Color()
            {
                Red = (double)entity.RedValue/255,
                Green = (double)entity.GreenValue/255,
                Blue = (double)entity.BlueValue/255
            };
            Lambertian ret = new Lambertian()
            {
                Name = entity.MaterialName,
                Owner = entity.MaterialOwnerId,
                Color = color,
            };

            return ret;
        }
    }
}
