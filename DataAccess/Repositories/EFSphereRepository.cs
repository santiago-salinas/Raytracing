using BusinessLogic.Objects;
using DataAccess.Entities;
using RepoInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EFSphereRepository : ISphereRepository
    {
        public EFSphereRepository() { }

        public List<Sphere> GetSpheresFromUser(string username)
        {
            using (EFContext dbContext = new EFContext())
            {
                List<SphereEntity> spheres = dbContext.SphereEntities
                    .Where(s => s.OwnerId == username)
                    .ToList();

                return spheres.Select(s => SphereEntity.FromEntity(s)).ToList();
            }
        }

        public bool ContainsSphere(string name, string owner)
        {
            using (EFContext dbContext = new EFContext())
            {
                return dbContext.SphereEntities
                   .Any(s => s.Name == name && s.OwnerId == owner);
            }
        }

        public void AddSphere(Sphere sphere)
        {
            using (EFContext dbContext = new EFContext())
            {
                SphereEntity entity = SphereEntity.FromDomain(sphere, dbContext);
                dbContext.SphereEntities.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void RemoveSphere(string name, string owner)
        {
            using (EFContext dbContext = new EFContext())
            {
                SphereEntity sphereEntity = dbContext.SphereEntities
                    .FirstOrDefault(m => m.Name == name && m.Owner.Username == owner);

                dbContext.SphereEntities.Remove(sphereEntity);                    
                dbContext.SaveChanges();                
            }
        }

        public Sphere GetSphere(string name, string owner)
        {
            using (EFContext context = new EFContext())
            {
                SphereEntity sphereEntity = context.SphereEntities
                    .FirstOrDefault(m => m.Name == name && m.OwnerId == owner);

                return SphereEntity.FromEntity(sphereEntity);
            }
        }
    }
}
