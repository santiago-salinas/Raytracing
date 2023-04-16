using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic
{
        public class SphereCollection
        {
            static List<Sphere> _sphereList;

            public List<Sphere> SphereList
            {
                get { return _sphereList; }
                set { _sphereList = value; }
            }

            static SphereCollection()
            {
                _sphereList = new List<Sphere>();
            }

            public SphereCollection() {
            }

        public void DropCollection()
        {
            _sphereList.Clear();
        }
        public bool ContainsSphere(string name)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name);
                return sphere != null;
            }
            public void AddSphere(Sphere newElement)
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

            public Sphere GetSphere(string name)
            {
                Sphere ret = _sphereList.Find(s => s.Name == name);
                bool exists =  ret != null;
                if(!exists) throw new BusinessLogicException("Sphere does not exist in the collection");
                return ret;
            }

            public void RemoveSphere(string name)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name);
                if(sphere == null)
                {
                    throw new BusinessLogicException("Sphere does not exist in the collection");
                }
                else
                {
                    _sphereList.Remove(sphere);
                }                                  
            }    
        }
    }