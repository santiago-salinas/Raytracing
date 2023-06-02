using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IMaterialRepository
    {
        void Drop();
        List<Material> GetLambertiansFromUser(string owner);
        bool ContainsLambertian(string name, string user);
        void AddLambertian(Material newElement);
        Material GetLambertian(string name, string user);
        void RemoveLambertian(string name, string owner);
    }
}
