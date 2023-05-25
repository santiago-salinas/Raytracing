
using System.Collections.Generic;
using DataTransferObjects;
using BusinessLogic;


namespace Controllers.Interfaces
{
    public interface ISphereManagement
    {
        List<SphereDTO> GetSpheresFromUser(string owner);
        Sphere GetSphere(string name, string owner);
        SphereDTO ConvertToDTO(Sphere sphere);

    }
}
