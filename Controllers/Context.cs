using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Controllers
{
    public class Context
    {
        public Context(SphereController sphereController)
        {
            SphereController = sphereController;
        }
        public SphereController SphereController { get; set; }
        public User CurrentUser { get; set; }
    }
}
