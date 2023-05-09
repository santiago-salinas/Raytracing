using System.Collections.Generic;


namespace BusinessLogic
{
    public static class Models
    {
        private static List<Model> _modelList = new List<Model>();

        public static void Drop()
        {
            _modelList.Clear();
        }

        public static List<Model> GetModelsFromUser(User owner)
        {
            List<Model> ret = new List<Model>();
            foreach (Model s in _modelList)
            {
                if (s.Owner == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public static bool ContainsModel(string name, User user)
        {
            Model ret = _modelList.Find(m => m.Name == name && m.Owner == user);
            return ret != null;
        }

        public static bool ExistsModelUsingTheLambertian(Lambertian lambertian)
        {
            Model ret = _modelList.Find(m => m.Material == lambertian);
            return ret != null;
        }
        public static bool ExistsModelUsingTheSphere(Sphere sphere)
        {
            Model ret = _modelList.Find(m => m.Shape == sphere);
            return ret != null;
        }
        public static void AddModel(Model newElement)
        {
            if (!ContainsModel(newElement.Name, newElement.Owner))
            {
                _modelList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already has model with the same name");
            }
        }

        public static Model GetModel(string name, User owner)
        {
            Model ret = _modelList.Find(m => m.Name == name && m.Owner == owner);
            if (ret == null) throw new BusinessLogicException("User does not own model with that name");
            return ret;
        }

        public static void RemoveModel(string name, User owner)
        {
            Model model = GetModel(name, owner);

            if (Scenes.ExistsSceneUsingModel(model))
            {
                throw new BusinessLogicException("Cant delete sphere used by existing model");
            }
            _modelList.Remove(model);
        }
    }
}
