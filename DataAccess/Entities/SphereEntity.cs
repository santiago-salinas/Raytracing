using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessLogic;

namespace DataAccess
{
    public class SphereEntity
    {
        [Key]
        [Column(Order = 1)]
        public string Name { get; set; }
        [Key]
        [Column(Order = 2)]
        public string Owner { get; set; }
        public double Radius { get; set; }

        public static SphereEntity FromDomain (Sphere sphere)
        {
            SphereEntity ret = new SphereEntity()
            {
                Name = sphere.Name,
                Owner = sphere.Owner,
                Radius = sphere.Radius,
            };
            return ret;
        }

        public static Sphere FromEntity(SphereEntity entity)
        {
            Sphere ret = new Sphere()
            {
                Name = entity.Name,
                Owner = entity.Owner,
                Radius = entity.Radius,
            };
            return ret;
        }
    }
}
