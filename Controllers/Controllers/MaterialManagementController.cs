using Services;
using System.Collections.Generic;
using System;
using Repositories.Interfaces;
using DataTransferObjects;
using System.Xml.Linq;

namespace Controllers.Controllers
{
    public class MaterialManagementController
    {
        private MaterialManagementService _service;
        
        public MaterialManagementController(MaterialManagementService service)
        {
            _service = service;
        }

        public void AddLambertian(LambertianDTO lambertianDTO)
        {
            try
            {
                _service.AddLambertian(lambertianDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public void RemoveLambertian(string name, string ownerName)
        {
            try
            {
                _service.RemoveLambertian(name, ownerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<LambertianDTO> GetLambertiansFromUser(string owner) 
        {
            return _service.GetLambertiansFromUser(owner);
        }

    }
}
