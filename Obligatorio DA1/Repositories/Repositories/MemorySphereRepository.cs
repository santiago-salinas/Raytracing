using BusinessLogic.Exceptions;
using BusinessLogic.DomainObjects;
using RepoInterfaces;
using System.Collections.Generic;

namespace Repositories
{
    public class MemorySphereRepository : ISphereRepository
    {
        private List<Sphere> _sphereList = new List<Sphere>();
        private IModelRepository _modelRepository;

        public MemorySphereRepository(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public List<Sphere> GetSpheresFromUser(string ownerName)
        {
            List<Sphere> ret = new List<Sphere>();
            foreach (Sphere s in _sphereList)
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
            _sphereList.Clear();
        }
        public bool ContainsSphere(string name, string ownerName)
        {
            Sphere sphere = _sphereList.Find(s => (s.Name == name && s.Owner == ownerName));
            return sphere != null;
        }
        public void AddSphere(Sphere newElement)
        {
            if (!ContainsSphere(newElement.Name, newElement.Owner))
            {
                _sphereList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already has sphere with the same name");
            }

        }

        public Sphere GetSphere(string name, string ownerName)
        {
            Sphere ret = _sphereList.Find(s => s.Name == name && s.Owner == ownerName);
            bool exists = ret != null;
            if (!exists) throw new BusinessLogicException("Owner does not have a sphere with that name");
            return ret;
        }

        public void RemoveSphere(string name, string ownerName)
        {
            Sphere sphere = _sphereList.Find(s => s.Name == name && s.Owner == ownerName);
            if (!ContainsSphere(name, ownerName))
            {
                throw new BusinessLogicException("Owner does not have a sphere with that name");
            }
            else if (_modelRepository.ExistsModelUsingTheSphere(name, ownerName))
            {
                throw new BusinessLogicException("Cannot delete sphere used by existing model");
            }
            else
            {
                _sphereList.Remove(sphere);
            }
        }
    }
}