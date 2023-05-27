using System.Collections.Generic;

namespace BusinessLogic
{
    public static class Materials
    {
        private static List<Material> s_MaterialList = new List<Material>();

        public static void Drop()
        {
            s_MaterialList.Clear();
        }

        public static List<Material> GetMaterialsFromUser(User owner)
        {
            List<Material> ret = new List<Material>();
            foreach (Material s in s_MaterialList)
            {
                if (s.Owner == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public static bool ContainsMaterial(string name, User user)
        {
            Material Material = s_MaterialList.Find(l => l.Name == name && l.Owner == user);
            return Material != null;
        }
        public static void AddMaterial(Material newElement)
        {
            if (!ContainsMaterial(newElement.Name, newElement.Owner))
            {
                s_MaterialList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already owns Material with that name");
            }

        }

        public static Material GetMaterial(string name, User user)
        {
            Material ret = s_MaterialList.Find(l => l.Name == name && l.Owner == user);
            if (ret == null) throw new BusinessLogicException("User does not own Material with that name");
            return ret;
        }

        public static void RemoveMaterial(string name, User owner)
        {
            Material Material = GetMaterial(name, owner);

            if (Models.ExistsModelUsingTheMaterial(Material))
            {
                throw new BusinessLogicException("Cant delete Material used by existing model");
            }
            else
            {
                s_MaterialList.Remove(Material);
            }
        }
    }
}