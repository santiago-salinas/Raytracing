using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using DataAccess.Entities;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataAccess.Repositories
{
    public class EFSceneRepository : ISceneRepository
    {
        public EFSceneRepository() { }


        public bool ContainsScene(string name, string user)
        {
            using (EFContext context = new EFContext())
            {
                return context.SceneEntities
                    .Any(m => m.Name == name && m.OwnerId == user);
            }
        }
        public void AddScene(Scene newElement)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = SceneEntity.FromDomain(newElement, context);
                context.SceneEntities.Add(sceneEntity);
                context.SaveChanges();
            }
        }
        public Scene GetScene(string name, string owner)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(m => m.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Owner))
                    .Include(m => m.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Lambertian))
                    .Include(m => m.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Metallic))
                    .Include(m => m.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Shape))
                    .Include(m => m.PositionedModels.Select(pm => pm.Model).Select(pm => pm.PPMEntity))
                    .Include(s => s.PPMEntity)
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
                    .Include(s => s.PositionedModels)
                    .Include(s => s.CameraDTO)
                    .Include(s => s.PPMEntity)
                    .FirstOrDefault(s => s.Name == name && s.OwnerId == owner);

                if (sceneEntity != null)
                {
                    foreach (var positionedModel in sceneEntity.PositionedModels.ToList())
                    {
                        context.PositionedModelEntities.Remove(positionedModel);
                    }

                    if (sceneEntity.PPMEntity != null)
                    {
                        context.PPMEntities.Remove(sceneEntity.PPMEntity);
                    }

                    context.Set<CameraEntity>().Remove(sceneEntity.CameraDTO);
                    context.SceneEntities.Remove(sceneEntity);
                    context.SaveChanges();
                }
            }
        }

        public List<Scene> GetScenesFromUser(string owner)
        {
            using (EFContext context = new EFContext())
            {
                List<SceneEntity> scene = context.SceneEntities
                    .Include(s => s.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Owner))
                    .Include(s => s.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Lambertian))
                    .Include(s => s.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Material).Select(pm => pm.Metallic))
                    .Include(s => s.PositionedModels.Select(pm => pm.Model).Select(pm => pm.Shape))
                    .Include(s => s.PositionedModels.Select(pm => pm.Model).Select(pm => pm.PPMEntity))
                    .Include(s => s.PPMEntity)
                    .Include(s => s.CameraDTO)
                    .Where(s => s.OwnerId == owner)
                    .ToList();

                return scene.Select(m => SceneEntity.FromEntity(m)).ToList();
            }
        }


        public void RemoveModelFromScene(Scene scene, PositionedModel model)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(s => s.PositionedModels.Select(pm => pm.Model))
                    .FirstOrDefault(s => s.Name == scene.Name && s.OwnerId == scene.Owner);

                PositionedModelEntity positionedModelEntity = sceneEntity.PositionedModels
                    .FirstOrDefault(pm => pm.Model.Name == model.Model.Name);

                if (positionedModelEntity != null)
                {
                    sceneEntity.PositionedModels.Remove(positionedModelEntity);
                    context.PositionedModelEntities.Remove(positionedModelEntity);
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
                    .FirstOrDefault(s => s.Name == scene.Name && s.OwnerId == scene.Owner);

                if (sceneEntity != null)
                {
                    PositionedModelEntity positionedModelEntity = PositionedModelEntity.FromDomain(model, context);
                    sceneEntity.PositionedModels.Add(positionedModelEntity);
                    context.SaveChanges();
                }
            }
        }


        public bool ExistsSceneUsingModel(string modelName, string owner)
        {
            using (EFContext context = new EFContext())
            {
                bool exists = context.SceneEntities
                    .Any(s => s.PositionedModels.Any(pm => pm.Model.Name == modelName && pm.Model.OwnerId == owner));

                return exists;
            }
        }

        public void UpdateRenderDate(string sceneName, string owner, DateTime date)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities.Find(sceneName, owner);

                if (sceneEntity != null)
                {
                    sceneEntity.LastRenderDate = date;
                    context.SaveChanges();
                }
            }

        }
        public void UpdateModificationDate(string sceneName, string owner, DateTime date)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities.Find(sceneName, owner);

                if (sceneEntity != null)
                {
                    sceneEntity.LastModificationDate = date;
                    context.SaveChanges();
                }
            }
        }
        public void UpdateCamera(string sceneName, string owner, BLCameraDTO camera)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(s => s.CameraDTO)
                    .FirstOrDefault(s => s.Name == sceneName && s.OwnerId == owner);
                CameraEntity oldCamera = sceneEntity.CameraDTO;

                if (sceneEntity != null)
                {
                    sceneEntity.CameraDTO = CameraEntity.FromDomain(camera);
                    context.Set<CameraEntity>().Remove(oldCamera);
                    context.SaveChanges();
                }
            }
        }

        public void UpdatePreview(string sceneName, string owner, PPM preview)
        {
            using (EFContext context = new EFContext())
            {
                SceneEntity sceneEntity = context.SceneEntities
                    .Include(s => s.PPMEntity)
                    .FirstOrDefault(s => s.Name == sceneName && s.OwnerId == owner);
                PPMEntity oldPreview = sceneEntity.PPMEntity;

                if (sceneEntity != null)
                {
                    sceneEntity.PPMEntity = PPMEntity.FromDomain(preview);
                    if (oldPreview != null)
                    {
                        context.PPMEntities.Remove(oldPreview);
                    }
                    context.SaveChanges();
                }
            }
        }

    }
}
