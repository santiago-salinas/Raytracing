using BusinessLogic;
using DataAccess.Entities;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EFModelRepository : IModelRepository
    {
        public List<Model> GetModelsFromUser(string owner) {
            return null;
        }
        public bool ContainsModel(string name, string user) {
            return true;
        }
        public bool ExistsModelUsingTheMaterial(Material material) {
            return false;
        }
        public bool ExistsModelUsingTheSphere(Sphere sphere) {
            return false;
        }
        public void AddModel(Model newElement) { }
        public Model GetModel(string name, string owner) {
            return null;
        }
        public void RemoveModel(string name, string owner) { }
    }
}
