using BusinessLogic.DomainObjects;
using System.Collections.Generic;


namespace RepoInterfaces
{
    public interface ISphereRepository
    {
        List<Sphere> GetSpheresFromUser(string ownerName);
        bool ContainsSphere(string name, string ownerName);
        void AddSphere(Sphere newElement);
        void RemoveSphere(string name, string ownerName);
    }
}
