using System.Collections.Generic;

namespace BusinessLogic
{
    public class LambertianRepository
    {
        private List<Lambertian> s_lambertianList = new List<Lambertian>();

        public void Drop()
        {
            s_lambertianList.Clear();
        }

        public List<Lambertian> GetLambertiansFromUser(string owner)
        {
            List<Lambertian> ret = new List<Lambertian>();
            foreach (Lambertian s in s_lambertianList)
            {
                if (s.Owner == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public bool ContainsLambertian(string name, string user)
        {
            Lambertian lambertian = s_lambertianList.Find(l => l.Name == name && l.Owner == user);
            return lambertian != null;
        }
        public void AddLambertian(Lambertian newElement)
        {
            if (!ContainsLambertian(newElement.Name, newElement.Owner))
            {
                s_lambertianList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already owns lambertian with that name");
            }

        }

        public Lambertian GetLambertian(string name, string user)
        {
            Lambertian ret = s_lambertianList.Find(l => l.Name == name && l.Owner == user);
            if (ret == null) throw new BusinessLogicException("User does not own lambertian with that name");
            return ret;
        }

        public void RemoveLambertian(string name, string owner)
        {
            Lambertian lambertian = GetLambertian(name, owner);

            if (ModelRepository.ExistsModelUsingTheLambertian(lambertian))
            {
                throw new BusinessLogicException("Cant delete lambertian used by existing model");
            }
            else
            {
                s_lambertianList.Remove(lambertian);
            }
        }
    }
}