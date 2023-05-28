
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Interfaces;
using Controllers;
using Services;
using DataTransferObjects;

namespace Controllers
{
    public class SphereManagementController
    {
        private SphereManagementService _service;

        public SphereManagementController(SphereManagementService service)
        {
            _service = service;
        }

        public void AddSphere(SphereDTO sphereDTO)
        {
            try
            {
                _service.AddSphere(sphereDTO);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public void RemoveSphere(string name, string ownerName)
        {
            try
            {
                _service.RemoveSphere(name, ownerName);
            }
            catch (Exception exception) 
            {
                throw new Exception(exception.Message);
            }
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {
            return _service.GetSpheresFromUser(owner);
        }    
    }
}
