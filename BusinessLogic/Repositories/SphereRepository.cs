using System.Collections.Generic;

namespace BusinessLogic
{
    public class SphereRepository
    {
        private List<Sphere> s_sphereList = new List<Sphere>();

        public List<Sphere> GetSpheresFromUser(string ownerName)
        {
            List<Sphere> ret = new List<Sphere>();
            foreach (Sphere s in s_sphereList)
            {
                if (s.Owner == ownerName)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }
        public void Drop()
        {
            s_sphereList.Clear();
        }
        public bool ContainsSphere(string name, string ownerName)
        {
            Sphere sphere = s_sphereList.Find(s => (s.Name == name && s.Owner == ownerName));
            return sphere != null;
        }
        public void AddSphere(Sphere newElement)
        {
            if (!ContainsSphere(newElement.Name, newElement.Owner))
            {
                s_sphereList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already has sphere with the same name");
            }

        }

        public Sphere GetSphere(string name, string ownerName)
        {
            Sphere ret = s_sphereList.Find(s => s.Name == name && s.Owner == ownerName);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a sphere with that name");
            return ret;
        }

        public void RemoveSphere(string name, string ownerName)
        {
            Sphere sphere = s_sphereList.Find(s => s.Name == name && s.Owner == ownerName);
            if (!ContainsSphere(name, ownerName))
            {
                throw new BusinessLogicException("Owner does not have a sphere with that name");
            }
            else if (ModelRepository.ExistsModelUsingTheSphere(sphere))
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