using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IModelRepository
    {
        void Drop();
        List<Model> GetModelsFromUser(string owner);
        bool ContainsModel(string name, string user);
        bool ExistsModelUsingTheLambertian(Lambertian lambertian);
        bool ExistsModelUsingTheSphere(Sphere sphere);
        void AddModel(Model newElement);
        Model GetModel(string name, string owner);
        void RemoveModel(string name, string owner);
    }
}
