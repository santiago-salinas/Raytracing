using BusinessLogic;
using Controllers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IMaterialManagement
    {
        List<LambertianDTO> GetLambertiansFromUser(string owner);
        Lambertian GetLambertian(string name, string owner);
        LambertianDTO ConvertToDTO(Lambertian lambertian);
    }
}
