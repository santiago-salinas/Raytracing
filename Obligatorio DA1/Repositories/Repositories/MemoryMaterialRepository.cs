using System.Collections.Generic;
using Repositories;
using Repositories.Interfaces;
using BusinessLogic.Exceptions;


namespace BusinessLogic
{
    public class MemoryMaterialRepository : IMaterialRepository
    {
        private List<Material> _lambertianList = new List<Material>();
        private IModelRepository _modelRepository;

        public MemoryMaterialRepository(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public void Drop()
        {
            _lambertianList.Clear();
        }

        public List<Material> GetMaterialsFromUser(string owner)
        {
            List<Material> ret = new List<Material>();
            foreach (Material s in _lambertianList)
            {
                if (s.Owner == owner)
                {
                    ret.Add(s);
                }
            }
            return ret;
        }

        public bool ContainsMaterial(string name, string user)
        {
            Material lambertian = _lambertianList.Find(l => l.Name == name && l.Owner == user);
            return lambertian != null;
        }
        public void AddMaterial(Material newElement)
        {
            if (!ContainsMaterial(newElement.Name, newElement.Owner))
            {
                _lambertianList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already owns lambertian with that name");
            }

        }

        public Material GetMaterial(string name, string user)
        {
            Material ret = _lambertianList.Find(l => l.Name == name && l.Owner == user);
            if (ret == null) throw new BusinessLogicException("User does not own lambertian with that name");
            return ret;
        }

        public void RemoveMaterial(string name, string owner)
        {
            Material lambertian = GetMaterial(name, owner);

            if (_modelRepository.ExistsModelUsingTheMaterial(lambertian))
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