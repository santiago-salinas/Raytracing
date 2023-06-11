using BusinessLogic;
using DataAccess.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;
using System.Data.Entity.Infrastructure;
using DataAccess.Exceptions;

namespace DataAccess.Repositories
{
    public class EFModelRepository : IModelRepository
    {

        public EFModelRepository() { }
        public List<Model> GetModelsFromUser(string owner) 
        {
            using (EFContext context = new EFContext())
            {
                List<ModelEntity> models = context.ModelEntities
                    .Include(m => m.Material)
                    .Include(m => m.Material.Lambertian)
                    .Include(m => m.Material.Metallic)
                    .Include(m => m.Shape)
                    .Where(m => m.OwnerId == owner)
                    .ToList();

                return models.Select(m => ModelEntity.FromEntity(m)).ToList();
            }
        }

        public bool ContainsModel(string name, string user) 
        {            
            using (EFContext context = new EFContext())
            {
                return context.ModelEntities
                    .Any(m => m.Name == name && m.OwnerId == user);
            }
        }
        public bool ExistsModelUsingTheMaterial(Material material) 
        {
            string materialName = material.Name;
            string ownerUsername = material.Owner;

            using (EFContext context = new EFContext())
            {
                return context.ModelEntities
                    .Any(m => m.Material.Name == materialName && m.OwnerId == ownerUsername);
            }
        }
        public bool ExistsModelUsingTheSphere(Sphere sphere) 
        {
            string sphereName = sphere.Name;
            string ownerUsername = sphere.Owner;

            using (EFContext context = new EFContext())
            {
                return context.ModelEntities
                    .Any(m => m.Shape.Name == sphereName && m.OwnerId == ownerUsername);
            }
        }
        public void AddModel(Model newElement) 
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    ModelEntity materialEntity = ModelEntity.FromDomain(newElement, context);
                    context.ModelEntities.Add(materialEntity);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                throw new RepositoryException("User already owns model with that name");
            }
        }
        public Model GetModel(string name, string owner) 
        {
            using (EFContext context = new EFContext())
            {
                ModelEntity modelEntity = context.ModelEntities
                    .Include(m => m.Material)
                    .Include(m => m.Material.Lambertian)
                    .Include(m => m.Material.Metallic)
                    .Include(m => m.Shape)
                    .FirstOrDefault(m => m.Name == name && m.OwnerId == owner);

                return ModelEntity.FromEntity(modelEntity);
            }
        }
        public void RemoveModel(string name, string owner) 
        {
            using (EFContext context = new EFContext())
            {
                ModelEntity modelEntity = context.ModelEntities
                    .FirstOrDefault(m => m.Name == name && m.OwnerId == owner);

                if (modelEntity != null)
                {
                    context.ModelEntities.Remove(modelEntity);
                    context.SaveChanges();
                }
            }
        }
    }
}
