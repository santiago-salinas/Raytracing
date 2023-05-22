using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
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

        public bool ExistsSceneUsingModel(Model model)
        {
            Scene ret = _sceneList.Find(s => s.ContainsModel(model));
            return ret != null;
        }
    }
}