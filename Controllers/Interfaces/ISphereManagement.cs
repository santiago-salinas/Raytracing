using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Controllers.DTOs;

namespace Controllers.Interfaces
{
    public interface ISphereManagement
    {
        List<SphereDTO> GetSpheresFromUser(string owner);
        Sphere GetSphere(string name, string owner);
        SphereDTO ConvertToDTO(Sphere sphere);

    }
}
