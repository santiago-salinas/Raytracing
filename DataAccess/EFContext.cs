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
    }
}
