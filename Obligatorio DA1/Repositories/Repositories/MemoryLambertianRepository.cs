using System.Collections.Generic;
using Repositories;
using Repositories.Interfaces;

namespace BusinessLogic
{
    public class MemoryLambertianRepository : IMaterialRepository
    {
        private List<Lambertian> _lambertianList = new List<Lambertian>();
        private IModelRepository _modelRepository;

        public MemoryLambertianRepository(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }
        public void Drop()
        {
            _lambertianList.Clear();
        }

        public List<Lambertian> GetLambertiansFromUser(string owner)
        {
            List<Lambertian> ret = new List<Lambertian>();
            foreach (Lambertian s in _lambertianList)
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
            Lambertian lambertian = _lambertianList.Find(l => l.Name == name && l.Owner == user);
            return lambertian != null;
        }
        public void AddLambertian(Lambertian newElement)
        {
            if (!ContainsLambertian(newElement.Name, newElement.Owner))
            {
                _lambertianList.Add(newElement);
            }
            else
            {
                throw new BusinessLogicException("User already owns lambertian with that name");
            }

        }

        public Lambertian GetLambertian(string name, string user)
        {
            Lambertian ret = _lambertianList.Find(l => l.Name == name && l.Owner == user);
            if (ret == null) throw new BusinessLogicException("User does not own lambertian with that name");
            return ret;
        }

        public void RemoveLambertian(string name, string owner)
        {
            Lambertian lambertian = GetLambertian(name, owner);

            if (_modelRepository.ExistsModelUsingTheLambertian(lambertian))
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