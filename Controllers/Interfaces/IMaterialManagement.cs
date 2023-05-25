using BusinessLogic;
using System.Collections.Generic;
using DataTransferObjects;

namespace Controllers.Interfaces
{
    public interface IMaterialManagement
    {
        List<LambertianDTO> GetLambertiansFromUser(string owner);
        Lambertian GetLambertian(string name, string owner);
        LambertianDTO ConvertToDTO(Lambertian lambertian);
    }
}
