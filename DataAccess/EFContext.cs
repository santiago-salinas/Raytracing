using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class EFContext : DbContext
    {
        public EFContext(): base("name=EFDatabase") { }

        public DbSet<SphereEntity> SphereEntities { get; set; }
        public DbSet<LambertianEntity> LambertianEntities { get;set; }
        public DbSet<MaterialEntity> MaterialEntities { get; set; }
        public DbSet<MetallicEntity> MetallicEntities { get; set; }
        public DbSet<ModelEntity> ModelEntities { get; set; }
        public DbSet<UserEntity> UserEntities { get; set; }
        public DbSet<PPMEntity> PPMEntities { get; set; }
        public DbSet<PositionedModelEntity> PositionedModelEntities { get; set; }

    }
}
