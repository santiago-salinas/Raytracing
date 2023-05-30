using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Controllers.Interfaces;

namespace DataAccess.Repositories
{
    public class EFSphereRepository : ISphereRepository
    {
        public EFSphereRepository() { }

        public List<Sphere> GetSpheresFromUser(string username)
        {
            return new List<Sphere>();
        }

        public bool ContainsSphere(string name, string owner)
        {
            return false;
        }

        public void AddSphere(Sphere sphere) 
        {
            using (EFContext dbContext = new EFContext())
            {
                SphereEntity entity = SphereEntity.FromDomain(sphere);
                dbContext.SphereEntities.Add(entity);
                dbContext.SaveChanges();
            }
        }

        public void RemoveSphere(string name, string owner) { }

        public Sphere GetSphere(string name, string owner) 
        {
          /*  using(EFContext dbContext = new EFContext())
            {
                SphereEntity entity = dbContext.SphereEntities.
                Sphere sphere;

            }*/

            return null;
        }


    }
}
