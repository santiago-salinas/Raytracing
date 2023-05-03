using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BusinessLogic.Objects;

namespace BusinessLogic
{
        public static class SphereCollection
        {
            private static List<Sphere> _sphereList = new List<Sphere>();

            public static List<Sphere> SphereList { get { return _sphereList; } }

            public static List<Sphere> GetSpheresFromUser(User owner)
            {
                List<Sphere> ret = new List<Sphere>();
                foreach (Sphere s in _sphereList)
                {
                    if (s.Owner == owner)
                    {
                        ret.Add(s);
                    }
                }
                return ret;
            }
            public static void DropCollection()
            {
                _sphereList.Clear();
            }
            public static bool ContainsSphere(string name, User owner)
            {
                Sphere sphere = _sphereList.Find(s => (s.Name == name && s.Owner == owner));
                return sphere != null;
            }
            public static void AddSphere(Sphere newElement)
            {
                if(!ContainsSphere(newElement.Name, newElement.Owner))
                {
                    _sphereList.Add(newElement);
                }
                else
                {
                    throw new BusinessLogicException("Sphere with the same name already exists in the collection");
                }
               
            }

            public static Sphere GetSphere(string name, User owner)
            {
                Sphere ret = _sphereList.Find(s => s.Name == name && s.Owner == owner);
                bool exists =  ret != null;
                if(!exists) throw new BusinessLogicException("Owner does not have a sphere with that name");
                return ret;
            }

            public static void RemoveSphere(string name, User owner)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name && s.Owner == owner);
                if(!ContainsSphere(name,owner))
                {
                    throw new BusinessLogicException("Owner does not have a sphere with that name");
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