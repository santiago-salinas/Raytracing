using Repositories.Interfaces;
using System.Collections.Generic;


namespace BusinessLogic
{
    public class MemoryModelRepository : IModelRepository
    {

        private List<Model> _modelList = new List<Model>();
        private ISceneRepository _sceneRepository;
        public MemoryModelRepository(ISceneRepository sceneRepo) 
        {
            _sceneRepository = sceneRepo;
        }
        public void Drop()
        {
            _modelList.Clear();
        }

        public List<Model> GetModelsFromUser(string owner)
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

        public bool ContainsModel(string name, string user)
        {
            Model ret = _modelList.Find(m => m.Name == name && m.Owner == user);
            return ret != null;
        }

        public bool ExistsModelUsingTheLambertian(Lambertian lambertian)
        {
            Model ret = _modelList.Find(m => m.Material == lambertian);
            return ret != null;
        }
        public bool ExistsModelUsingTheSphere(Sphere sphere)
        {
            Model ret = _modelList.Find(m => m.Shape == sphere);
            return ret != null;
        }
        public void AddModel(Model newElement)
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

        public Model GetModel(string name, string owner)
        {
            Model ret = _modelList.Find(m => m.Name == name && m.Owner == owner);
            if (ret == null) throw new BusinessLogicException("User does not own model with that name");
            return ret;
        }

        public void RemoveModel(string name, string owner)
        {
            Model model = GetModel(name, owner);

            if (_sceneRepository.ExistsSceneUsingModel(model))
            {
                throw new BusinessLogicException("Cannot delete model used by an existing scene");
            }
            _modelList.Remove(model);
        }
    }
}
