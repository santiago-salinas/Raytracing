﻿using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public static class Scenes
    {
        private static List<Scene> s_sceneList = new List<Scene>();

        public static void Drop()
        {
            s_sceneList.Clear();
        }

        public static List<Scene> GetScenesFromUser(User owner)
        {
            List<Scene> ret = new List<Scene>();
            foreach (Scene scene in s_sceneList)
            {
                if (scene.Owner == owner)
                {
                    ret.Add(scene);
                }
            }
            ret = ret.OrderByDescending(scene => scene.LastModificationDate).ToList();
            return ret;
        }
        public static bool ContainsScene(string name, User owner)
        {
            Scene scene = s_sceneList.Find(s => s.Name == name && s.Owner == owner);
            return scene != null;
        }
        public static void AddScene(Scene newElement)
        {
            if (!ContainsScene(newElement.Name, newElement.Owner))
            {
                s_sceneList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Owner already has scene with that name");
            }

        }

        public static Scene GetScene(string name, User owner)
        {
            Scene ret = s_sceneList.Find(s => s.Name == name && s.Owner == owner);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a scene with that name");
            return ret;
        }

        public static void RemoveScene(string name, User owner)
        {
            Scene scene = GetScene(name, owner);
            s_sceneList.Remove(scene);
        }

        public static bool ExistsSceneUsingModel(Model model)
        {
            Scene ret = s_sceneList.Find(s => s.ContainsModel(model));
            return ret != null;
        }
    }
}