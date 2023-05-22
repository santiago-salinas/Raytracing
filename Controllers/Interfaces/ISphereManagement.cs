using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Controllers.Interfaces
{
    public interface ISphereManagement
    {
        Sphere GetSphere(string name, string owner);
    }
}
