using System.Collections.Generic;

namespace BusinessLogic
{
    public static class Spheres
    {
        private static List<Sphere> s_sphereList = new List<Sphere>();

        public static List<Sphere> GetSpheresFromUser(User owner)
        {
            List<Sphere> ret = new List<Sphere>();
            foreach (Sphere s in s_sphereList)
            {
                if (s.Owner == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }
        public static void Drop()
        {
            s_sphereList.Clear();
        }
        public static bool ContainsSphere(string name, User owner)
        {
            Sphere sphere = s_sphereList.Find(s => (s.Name == name && s.Owner == owner));
            return sphere != null;
        }
        public static void AddSphere(Sphere newElement)
        {
            if (!ContainsSphere(newElement.Name, newElement.Owner))
            {
                s_sphereList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Sphere with the same name already exists in the collection");
            }

        }

        public static Sphere GetSphere(string name, User owner)
        {
            Sphere ret = s_sphereList.Find(s => s.Name == name && s.Owner == owner);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a sphere with that name");
            return ret;
        }

        public static void RemoveSphere(string name, User owner)
        {
            Sphere sphere = s_sphereList.Find(s => s.Name == name && s.Owner == owner);
            if (!ContainsSphere(name, owner))
            {
                throw new BusinessLogicException("Owner does not have a sphere with that name");
            }
            else if (Models.ExistsModelUsingTheSphere(sphere))
            {
                throw new BusinessLogicException("Cant delete sphere used by existing model");
            }
            else
            {
                s_sphereList.Remove(sphere);
            }
        }
    }
}