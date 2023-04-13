using BusinessLogic;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{

    namespace BusinessLogic
    {
        public class SphereCollection
        {
            private List<Sphere> sphereList;
            public SphereCollection() {
            }

            public bool AddSphere(string name, float radius)
            {
                return false;
            }

            public Sphere GetSphere(string name)
            {
                return new Sphere();
            }

            public bool RemoveSphere(string element)
            {
                return false;
            }
        }
    }
}