using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IMaterialManagement
    {
        Lambertian GetLambertian(string name, string owner);
    }
}
