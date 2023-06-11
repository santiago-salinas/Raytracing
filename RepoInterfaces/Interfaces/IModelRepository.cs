using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoInterfaces
{
    public interface IModelRepository
    {
        List<Model> GetModelsFromUser(string owner);
        bool ContainsModel(string name, string user);
        bool ExistsModelUsingTheMaterial(Material material);
        bool ExistsModelUsingTheSphere(Sphere sphere);
        void AddModel(Model newElement);
        Model GetModel(string name, string owner);
        void RemoveModel(string name, string owner);
    }
}
