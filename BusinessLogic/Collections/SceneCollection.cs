using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic
{
        public static class SceneCollection
        {
            private static List<Scene> _sceneList = new List<Scene>();

            public static void DropCollection()
            {
            
            }
            public static bool ContainsScene(string name)
            {
            Random gen = new Random();
            return gen.Next(100) < 50 ? true : false;
        }
            public static void AddScene(Scene newElement)
            {
                
            }

            public static Scene GetScene(string name)
            {
            return null;
            }

            public static void RemoveScene(string name)
            {
                                                
            }    
        }
    }