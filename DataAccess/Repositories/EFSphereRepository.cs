using BusinessLogic.Objects;
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
            List<Sphere> spheres = new List<Sphere>();

            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM SphereEntities " +
                            $"WHERE OwnerId = '{username}'";

                List<SphereEntity> entities = dbContext.SphereEntities.SqlQuery(query).ToList();

                foreach (SphereEntity entity in entities)
                {
                    Sphere domainSphere = SphereEntity.FromEntity(entity);
                    spheres.Add(domainSphere);
                }
            }
            return spheres;
        }

        public bool ContainsSphere(string name, string owner)
        {
            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM SphereEntities " +
                            $"WHERE Name = '{name}' AND OwnerId = '{owner}'";
                SphereEntity entitySphere = dbContext.SphereEntities.SqlQuery(query).FirstOrDefault();
                return entitySphere != null;
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
                var query = $"SELECT * " +
                            $"FROM SphereEntities " +
                            $"WHERE Name = '{name}' AND OwnerId = '{owner}'";
                SphereEntity sphere = dbContext.SphereEntities.SqlQuery(query).FirstOrDefault();

                if (sphere != null)
                {
                    dbContext.SphereEntities.Remove(sphere);
                    dbContext.SaveChanges();
                }
            }
        }

        public Sphere GetSphere(string name, string owner)
        {
            Sphere domainSphere = null;

            using (EFContext dbContext = new EFContext())
            {
                var query = $"SELECT * " +
                            $"FROM SphereEntities " +
                            $"WHERE Name = '{name}' AND OwnerId = '{owner}'";
                SphereEntity entitySphere = dbContext.SphereEntities.SqlQuery(query).FirstOrDefault();

                if (entitySphere != null)
                {
                    domainSphere = SphereEntity.FromEntity(entitySphere);
                }
            }
            return domainSphere;
        }
    }
}
