using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;
using BusinessLogic;
using RepoInterfaces;
using DataAccess.Entities;
using System.Data.Entity.Infrastructure;
using DataAccess.Exceptions;


namespace DataAccess.Repositories
{
    public class EFMaterialRepository : IMaterialRepository
    {
        public EFMaterialRepository() { }

        public List<Material> GetMaterialsFromUser(string username)
        {
            using (EFContext context = new EFContext())
            {
                List<MaterialEntity> materials = context.MaterialEntities
                    .Include(m => m.Lambertian)
                    .Include(m => m.Metallic)
                    .Where(m => m.Owner.Username == username)
                    .ToList();

                return materials.Select(m => MaterialEntity.FromEntity(m)).ToList();
            }
        }

        public bool ContainsMaterial(string name, string user)
        {
            using (EFContext context = new EFContext())
            {
                return context.MaterialEntities
                    .Any(m => m.Name == name && m.Owner.Username == user);
            }
        }

        public void AddMaterial(Material newElement)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    UserEntity owner = context.UserEntities.FirstOrDefault(u => u.Username == newElement.Owner);

                    MaterialEntity materialEntity = MaterialEntity.FromDomain(newElement, context);
                    context.MaterialEntities.Add(materialEntity);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException ex)
            {
                throw new RepositoryException("User already owns material with that name");
            }            
        }

        public Material GetMaterial(string name, string user)
        {
            using (EFContext context = new EFContext())
            {
                MaterialEntity materialEntity = context.MaterialEntities
                    .Include(m => m.Lambertian)
                    .Include(m => m.Metallic)
                    .FirstOrDefault(m => m.Name == name && m.Owner.Username == user);

                return MaterialEntity.FromEntity(materialEntity);
            }
        }

        public void RemoveMaterial(string name, string owner)
        {
            using (EFContext context = new EFContext())
            {
                MaterialEntity materialEntity = context.MaterialEntities
                    .Include (m => m.Lambertian) .Include(m => m.Metallic)
                    .FirstOrDefault(m => m.Name == name && m.Owner.Username == owner);

                if (materialEntity != null)
                {
                    LambertianEntity lambertianEntity = materialEntity.Lambertian;
                    MetallicEntity metallicEntity = materialEntity.Metallic;
                    if (lambertianEntity != null)
                    {
                        context.LambertianEntities.Remove(lambertianEntity);
                    }
                    else
                    {
                        context.MetallicEntities.Remove(metallicEntity);
                    }
                    context.MaterialEntities.Remove(materialEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
