using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic_Tests
{

    namespace BusinessLogic
    {
        public class SphereCollection
        {
            private List<Sphere> _sphereList;
            public SphereCollection() {
                _sphereList = new List<Sphere>();
            }
            public bool AddSphere(Sphere newElement)
            {
                if(_sphereList.Find(s => s.Name == newElement.Name) == null)
                {
                    _sphereList.Add(newElement);
                    return true;
                }
                else
                {
                    throw new BusinessLogicException("Sphere with the same name already exists in the collection");
                }
               
            }

            public Sphere GetSphere(string name)
            {
                Sphere ret = _sphereList.Find(s => s.Name == name);
                if(ret == null) throw new BusinessLogicException("Sphere does not exist in the collection");
                return ret;
            }

            public bool RemoveSphere(string name)
            {
                Sphere sphere = _sphereList.Find(s => s.Name == name);
                if(sphere == null)
                {
                    throw new BusinessLogicException("Sphere does not exist in the collection");
                }
                _sphereList.Remove(sphere);
                return true;
            }
        }
    }
}