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
        List<Lambertian> GetLambertiansFromUser(string owner);
        bool ContainsLambertian(string name, string user);
        void AddLambertian(Lambertian newElement);
        Lambertian GetLambertian(string name, string user);
        void RemoveLambertian(string name, string owner);
    }
}
