using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BusinessLogic.Objects;

namespace BusinessLogic
{
    public static class SceneCollection
    {
        private static List<Scene> _sceneList = new List<Scene>();

        public static void DropCollection()
        {
            _sceneList.Clear();
        }
        public static bool ContainsScene(string name, User owner)
        {
            Scene scene = _sceneList.Find(s => s.Name == name && s.Owner == owner);
            return scene != null;
        }
        public static void AddScene(Scene newElement)
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

        public static Scene GetScene(string name, User owner)
        {
            Scene ret = _sceneList.Find(s => s.Name == name && s.Owner == owner);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a scene with that name");
            return ret;
        }

        public static void RemoveScene(string name, User owner)
        {
            Scene scene = _sceneList.Find(s => s.Name == name && s.Owner == owner);
            if (scene == null)
            {
                throw new BusinessLogicException("Owner does not have a scene with that name");
            }
            else
            {
                _sceneList.Remove(scene);
            }
        }

        public static bool ExistsSceneUsingModel(Model model)
        {
            Scene ret = _sceneList.Find(s => s.ContainsModel(model));
            return ret != null;
        }
    }
}