using BusinessLogic.Exceptions;
using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class MemorySceneRepository : ISceneRepository
    {
        private List<Scene> _sceneList = new List<Scene>();

        public void Drop()
        {
            _sceneList.Clear();
        }

        public List<Scene> GetScenesFromUser(string owner)
        {
            List<Scene> ret = new List<Scene>();
            foreach (Scene scene in _sceneList)
            {
                if (scene.Owner == owner)
                {
                    ret.Add(scene);
                }
            }
            ret = ret.OrderByDescending(scene => scene.LastModificationDate).ToList();
            return ret;
        }
        public bool ContainsScene(string name, string owner)
        {
            Scene scene = _sceneList.Find(s => s.Name == name && s.Owner == owner);
            return scene != null;
        }
        public void AddScene(Scene newElement)
        {
            if (!ContainsScene(newElement.Name, newElement.Owner))
            {
                _sceneList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Owner already has scene with that name");
            }

        }

        public Scene GetScene(string name, string owner)
        {
            Scene ret = _sceneList.Find(s => s.Name == name && s.Owner == owner);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a scene with that name");
            return ret;
        }

        public void RemoveScene(string name, string owner)
        {
            Scene scene = GetScene(name, owner);
            _sceneList.Remove(scene);
        }

        public bool ExistsSceneUsingModel(string modelName, string owner)
        {
            Model model = new Model()
            {
                Name = modelName,
                Owner = owner
            };
            Scene ret = _sceneList.Find(s => s.ContainsModel(model));
            return ret != null;
        }

        public void AddModelToScene(Scene scene, PositionedModel model)
        {
            scene.AddPositionedModel(model);
        }

        public void RemoveModelFromScene(Scene scene, PositionedModel model)
        {
            scene.RemovePositionedModel(model);
        }

        public void UpdateRenderDate(string sceneName, string owner, DateTime date)
        {
            Scene scene = GetScene(sceneName, owner);
            scene.UpdateLastRenderDate();
        }
        public void UpdateModificationDate(string sceneName, string owner, DateTime date)
        {
            Scene scene = GetScene(sceneName, owner);
            scene.UpdateLastModificationDate();
        }
        public void UpdateCamera(string sceneName, string owner, BLCameraDTO camera)
        {
            Scene scene = GetScene(sceneName, owner);
            scene.CameraDTO = camera;
        }

        public void UpdatePreview(string sceneName, string owner, PPM ppm)
        {
            Scene scene = GetScene(sceneName, owner);
            scene.Preview = ppm;
        }

        public void UpdateBlur(string sceneName, string owner, bool blurConfig)
        {
            Scene scene = GetScene(sceneName, owner);
            scene.Blur = blurConfig;
        }
    }
}