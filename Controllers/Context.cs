using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Controllers.Controllers;

namespace Controllers
{
    public class Context
    {
        public Context() { }
        public SphereController SphereController { get; set; }
        public LambertianController LambertianController { get; set; }
        public string CurrentUser { get; set; }
    }
}
