using System.Collections.Generic;

namespace BusinessLogic
{
    public static class Lambertians
    {
        private static List<Lambertian> s_lambertianList = new List<Lambertian>();

        public static void Drop()
        {
            s_lambertianList.Clear();
        }

        public static List<Lambertian> GetLambertiansFromUser(User owner)
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

        public static bool ContainsLambertian(string name, User user)
        {
            Lambertian lambertian = s_lambertianList.Find(l => l.Name == name && l.Owner == user);
            return lambertian != null;
        }
        public static void AddLambertian(Lambertian newElement)
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

        public static Lambertian GetLambertian(string name, User user)
        {
            Lambertian ret = s_lambertianList.Find(l => l.Name == name && l.Owner == user);
            if (ret == null) throw new BusinessLogicException("User does not own lambertian with that name");
            return ret;
        }

        public static void RemoveLambertian(string name, User owner)
        {
            Lambertian lambertian = GetLambertian(name, owner);

            if (Models.ExistsModelUsingTheLambertian(lambertian))
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