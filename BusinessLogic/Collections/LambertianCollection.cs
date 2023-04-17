using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class LambertianCollection
    {
        static List<Lambertian> _lambertianList = new List<Lambertian>();
        
        public static void DropCollection()
        {
            _lambertianList.Clear();
        }

        public static bool ContainsLambertian(string name)
        {
            Lambertian lambertian = _lambertianList.Find(l => l.Name == name);
            return lambertian != null;           
        }
        public static void AddLambertian(Lambertian newElement)
        {
            if (_lambertianList.Find(l => l.Name == newElement.Name) == null)
            {
                _lambertianList.Add(newElement);               
            }
            else
            {
                throw new BusinessLogicException("Lambertian with the same name already exists in the collection");
            }

        }

        public static Lambertian GetLambertian(string name)
        {
            Lambertian ret = _lambertianList.Find(l => l.Name == name);
            if (ret == null) throw new BusinessLogicException("Lambertian does not exist in the collection");
            return ret;
        }

        public static void RemoveLambertian(string name)
        {
            Lambertian lambertian = _lambertianList.Find(l => l.Name == name);
            if (lambertian == null)
            {
                throw new BusinessLogicException("Lambertian does not exist in the collection");
            }
            _lambertianList.Remove(lambertian);            
        }

    }
}
