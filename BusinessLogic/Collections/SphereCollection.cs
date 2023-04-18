using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic
{
        public static class SphereCollection
        {
            private static List<Sphere> _sphereList = new List<Sphere>();

            public static void DropCollection()
            {
                _sphereList.Clear();
            }
            public static bool ContainsSphere(string name)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name);
                return sphere != null;
            }
            public static void AddSphere(Sphere newElement)
            {
                if(_sphereList.Find(s => s.Name == newElement.Name) == null)
                {
                    _sphereList.Add(newElement);
                }
                else
                {
                    throw new BusinessLogicException("Sphere with the same name already exists in the collection");
                }
               
            }

            public static Sphere GetSphere(string name)
            {
                Sphere ret = _sphereList.Find(s => s.Name == name);
                bool exists =  ret != null;
                if(!exists) throw new BusinessLogicException("Sphere does not exist in the collection");
                return ret;
            }

            public static void RemoveSphere(string name)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name);
                if(sphere == null)
                {
                    throw new BusinessLogicException("Sphere does not exist in the collection");
                }//cant remove sphere used in a existing model
                else if(ModelCollection.ExistsModelUsingTheSphere(sphere))
                {
                    throw new BusinessLogicException("Cant delete sphere used by existing model");
                }
                else
                {
                    _sphereList.Remove(sphere);
                }                                  
            }    
        }
    }