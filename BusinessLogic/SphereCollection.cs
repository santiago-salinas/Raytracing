using BusinessLogic;
using System;
using System.Collections.Generic;

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
                
                _sphereList.Add(newElement);

                return true;
            }

            public Sphere GetSphere(string name)
            {
                Sphere ret = _sphereList.Find(s => s.Name == name);
                return ret;
            }

            public bool RemoveSphere(string element)
            {
                return false;
            }
        }
    }
}