using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface ISphereRepository
    {
        List<Sphere> GetSpheresFromUser(string ownerName);
        bool ContainsSphere(string name, string ownerName);
        void AddSphere(Sphere newElement);
        Sphere GetSphere(string name, string ownerName);
        void RemoveSphere(string name, string ownerName);
    }
}
