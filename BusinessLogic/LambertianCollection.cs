using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LambertianCollection
    {
        private List<Lambertian> _lambertianList;
        public LambertianCollection()
        {
            _lambertianList = new List<Lambertian>();
        }
        public bool AddLambertian(Lambertian newElement)
        {
            if (_lambertianList.Find(l => l.Name == newElement.Name) == null)
            {
                _lambertianList.Add(newElement);
                return true;
            }
            else
            {
                throw new BusinessLogicException("Lambertian with the same name already exists in the collection");
            }

        }

        public Lambertian GetLambertian(string name)
        {
            Lambertian ret = _lambertianList.Find(l => l.Name == name);
            if (ret == null) throw new BusinessLogicException("Lambertian does not exist in the collection");
            return ret;
        }

        public bool RemoveLambertian(string name)
        {
            Lambertian lambertian = _lambertianList.Find(l => l.Name == name);
            if (lambertian == null)
            {
                throw new BusinessLogicException("Lambertian does not exist in the collection");
            }
            _lambertianList.Remove(lambertian);
            return true;
        }

    }
}
