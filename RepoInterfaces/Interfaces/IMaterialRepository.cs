using BusinessLogic.Objects;
using System.Collections.Generic;

namespace RepoInterfaces
{
    public interface IMaterialRepository
    {
        List<Material> GetMaterialsFromUser(string owner);
        bool ContainsMaterial(string name, string user);
        void AddMaterial(Material newElement);
        Material GetMaterial(string name, string user);
        void RemoveMaterial(string name, string owner);
    }
}
