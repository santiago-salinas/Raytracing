﻿using BusinessLogic.DomainObjects;
using DataAccess.Entities;
using RepoInterfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            using (EFContext context = new EFContext())
            {
                UserEntity owner = context.UserEntities.FirstOrDefault(u => u.Username == newElement.Owner);

                MaterialEntity materialEntity = MaterialEntity.FromDomain(newElement, context);
                context.MaterialEntities.Add(materialEntity);
                context.SaveChanges();
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
                    .Include(m => m.Lambertian).Include(m => m.Metallic)
                    .FirstOrDefault(m => m.Name == name && m.Owner.Username == owner);

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
