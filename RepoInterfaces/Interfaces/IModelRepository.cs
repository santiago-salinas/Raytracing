using BusinessLogic.DomainObjects;
using System.Collections.Generic;

namespace RepoInterfaces
{
    public interface IModelRepository
    {
        List<Model> GetModelsFromUser(string owner);
        bool ContainsModel(string name, string user);
        bool ExistsModelUsingTheMaterial(string materialName, string materialOwner);
        bool ExistsModelUsingTheSphere(string sphereName, string sphereOwner);
        void AddModel(Model newElement);
        Model GetModel(string name, string owner);
        void RemoveModel(string name, string owner);
    }
}
