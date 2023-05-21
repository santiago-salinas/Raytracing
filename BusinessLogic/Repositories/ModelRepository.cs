using System.Collections.Generic;


namespace BusinessLogic
{
    public static class ModelRepository
    {
        private static List<Model> s_modelList = new List<Model>();

        public static void Drop()
        {
            s_modelList.Clear();
        }

        public static List<Model> GetModelsFromUser(string owner)
        {
            List<Model> ret = new List<Model>();
            foreach (Model s in s_modelList)
            {
                if (s.Owner.UserName == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public static bool ContainsModel(string name, string user)
        {
            Model ret = s_modelList.Find(m => m.Name == name && m.Owner.UserName == user);
            return ret != null;
        }

        public static bool ExistsModelUsingTheLambertian(Lambertian lambertian)
        {
            Model ret = s_modelList.Find(m => m.Material == lambertian);
            return ret != null;
        }
        public static bool ExistsModelUsingTheSphere(Sphere sphere)
        {
            Model ret = s_modelList.Find(m => m.Shape == sphere);
            return ret != null;
        }
        public static void AddModel(Model newElement)
        {
            if (!ContainsModel(newElement.Name, newElement.Owner.UserName))
            {
                s_modelList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already has model with the same name");
            }
        }

        public static Model GetModel(string name, User owner)
        {
            Model ret = s_modelList.Find(m => m.Name == name && m.Owner == owner);
            if (ret == null) throw new BusinessLogicException("User does not own model with that name");
            return ret;
        }

        public static void RemoveModel(string name, User owner)
        {
            Model model = GetModel(name, owner);

            if (SceneRepository.ExistsSceneUsingModel(model))
            {
                throw new BusinessLogicException("Cant delete sphere used by existing model");
            }
            s_modelList.Remove(model);
        }
    }
}
