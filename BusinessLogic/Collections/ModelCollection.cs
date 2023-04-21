using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public static class ModelCollection
    {
        private static List<Model> _modelList = new List<Model>();

        public static void DropCollection()
        {
            _modelList.Clear();
        }

        public static bool ContainsModel(string name)
        {
            Model ret = _modelList.Find(m => m.Name == name);
            return ret != null;
        }

        public static bool ExistsModelUsingTheLambertian(Lambertian lambertian)
        {
            Model ret = _modelList.Find(m => m.ModelColor == lambertian);
            return ret != null;
        }
        public static bool ExistsModelUsingTheSphere(Sphere sphere)
        {
            Model ret = _modelList.Find(m => m.ModelShape == sphere);
            return ret != null;
        }
        public static void AddModel(Model newElement)
        {
            if (!ContainsModel(newElement.Name))
            {
                _modelList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("Model with the same name already exists in the collection");
            }
        }

        public static Model GetModel(string name)
        {
            Model ret = _modelList.Find(m => m.Name == name);
            if (ret == null) throw new BusinessLogicException("Model does not exist in the collection");
            return ret;
        }

        public static void RemoveModel(string name)
        {
            Model model = _modelList.Find(s => s.Name == name);
            if (model == null)
            {
                throw new BusinessLogicException("Model does not exist in the collection");
            }
            else if (SceneCollection.ExistsSceneUsingModel(model))
            {
                throw new BusinessLogicException("Cant delete sphere used by existing model");
            }
            _modelList.Remove(model);           
        }
    }
}
