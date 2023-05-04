using System.Collections.Generic;

namespace BusinessLogic
{
    public static class SceneCollection
    {
        private static List<Scene> _sceneList = new List<Scene>();

        public static void DropCollection()
        {
            _sceneList.Clear();
        }
        public static bool ContainsScene(string name)
        {
            Scene scene = _sceneList.Find(s => s.Name == name);
            return scene != null;
        }
        public static void AddScene(Scene newElement)
        {
            if (_sceneList.Find(s => s.Name == newElement.Name) == null)
            {
                _sceneList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Scene with the same name already exists in the collection");
            }

        }

        public static Scene GetScene(string name)
        {
            Scene ret = _sceneList.Find(s => s.Name == name);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Scene does not exist in the collection");
            return ret;
        }

        public static void RemoveScene(string name)
        {
            Scene scene = _sceneList.Find(s => s.Name == name);
            if (scene == null)
            {
                throw new BusinessLogicException("Scene does not exist in the collection");
            }
            else
            {
                _sceneList.Remove(scene);
            }
        }

        public static bool ExistsSceneUsingModel(Model model)
        {
            Scene ret = _sceneList.Find(m => m.ContainsModel(model.Name));
            return ret != null;
        }
    }
}