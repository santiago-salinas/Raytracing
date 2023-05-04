using System.Collections.Generic;
using System.Xml.Linq;

namespace BusinessLogic
{
    public static class LambertianCollection
    {
        static List<Lambertian> _lambertianList = new List<Lambertian>();

        public static void DropCollection()
        {
            _lambertianList.Clear();
        }

        private static Lambertian FindLambertianNamed(string name)
        {
            return _lambertianList.Find(l => l.Name == name);
        }

        public static bool ContainsLambertian(string name)
        {
            Lambertian lambertian = FindLambertianNamed(name);
            return lambertian != null;
        }
        public static void AddLambertian(Lambertian newElement)
        {
            if (FindLambertianNamed(newElement.Name) is null)
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
            Lambertian lamertian = FindLambertianNamed(name);
            if (lamertian == null) throw new BusinessLogicException("Lambertian does not exist in the collection");
            return lamertian;
        }

        public static void RemoveLambertian(string name)
        {
            Lambertian lambertian = _lambertianList.Find(l => l.Name == name);
            if (lambertian == null)
            {
                throw new BusinessLogicException("Lambertian does not exist in the collection");
            }
            else if (ModelCollection.ExistsModelUsingTheLambertian(lambertian))
            {
                throw new BusinessLogicException("Cant delete lambertian used by existing model");
            }
            else
            {
                _lambertianList.Remove(lambertian);
            }
        }
    }
}
