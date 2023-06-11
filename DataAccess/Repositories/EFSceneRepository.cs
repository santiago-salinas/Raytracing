using BusinessLogic;
using DataAccess.Entities;
using DataAccess.Exceptions;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Xml.Linq;


namespace DataAccess.Repositories
{
    public class EFSceneRepository : ISceneRepository
    {
        public EFSceneRepository() { }
        

        public bool ContainsScene(string name, string user)
        {
            using (EFContext context = new EFContext())
            {
                return context.ModelEntities
                    .Any(m => m.Name == name && m.OwnerId == user);
            }
        }
        public void AddScene(Scene newElement)
        {
            try
            {
                using (EFContext context = new EFContext())
                {
                    SceneEntity sceneEntity = SceneEntity.FromDomain(newElement, context);
                    context.SceneEntities.Add(sceneEntity);
                    context.SaveChanges();
                }
            }
            catch (DbUpdateException)
            {
                throw new RepositoryException("User already has a scene with that name");
            }
        }
        public Scene GetScene(string name, string owner)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(m => m.PositionedModels)
                    .Include(m => m.CameraDTO)
                    .FirstOrDefault(m => m.Name == name && m.OwnerId == owner);

                return SceneEntity.FromEntity(sceneEntity);
            }
        }
        public void RemoveScene(string name, string owner)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .FirstOrDefault(m => m.Name == name && m.OwnerId == owner);

                if (sceneEntity != null)
                {
                    context.SceneEntities.Remove(sceneEntity);
                    context.SaveChanges();
                }
            }
        }

        public void Drop()
        {
            throw new NotImplementedException();
        }

        List<Scene> ISceneRepository.GetScenesFromUser(string owner)
        {
            using (EFContext context = new EFContext())
            {
                List<SceneEntity> scene = context.SceneEntities
                    .Include(m => m.PositionedModels)
                    .Include(m => m.CameraDTO)
                    .Where(m => m.OwnerId == owner)
                    .ToList();

                return scene.Select(m => SceneEntity.FromEntity(m)).ToList();
            }
        }


        public void RemoveModelFromScene(Scene scene, PositionedModel model)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(s => s.PositionedModels)
                    .Include(s => s.CameraDTO)
                    .FirstOrDefault(s => s.Name == scene.Name && s.OwnerId == scene.Owner);

                PositionedModelEntity positionedModelEntity = sceneEntity.PositionedModels
                    .FirstOrDefault(pm => pm.Model.Name == model.Model.Name);

                if (positionedModelEntity != null)
                {
                    sceneEntity.PositionedModels.Remove(positionedModelEntity);
                    context.SaveChanges();
                }
            }
        }


        public void AddModelToScene(Scene scene, PositionedModel model)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(s => s.PositionedModels)
                    .Include(s => s.CameraDTO)
                    .FirstOrDefault(s => s.Name == scene.Name && s.OwnerId == scene.Owner);

                if (sceneEntity != null)
                {
                    PositionedModelEntity positionedModelEntity = PositionedModelEntity.FromDomain(model, context);
                    sceneEntity.PositionedModels.Add(positionedModelEntity);
                    context.SaveChanges();
                }
            }
        }


        public bool ExistsSceneUsingModel(Model model)
        {
            using (EFContext context = new EFContext())
            {
                bool exists = context.SceneEntities
                    .Any(s => s.PositionedModels.Any(pm => pm.Model.Name == model.Name));

                return exists;
            }
        }

    }
}
