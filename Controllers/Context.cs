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
        public SphereManagementController SphereController { get; set; }
        public MaterialManagementController LambertianController { get; set; }
        public ModelManagementController ModelController { get; set; }
        public MemoryUserRepository UserRepository { get; set; }        
        public SceneManagementController SceneController { get; set; }
        public string CurrentUser { get; set; }
    }
}
