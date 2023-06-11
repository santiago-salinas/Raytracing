using Services;
using System.Collections.Generic;
using System;
using DataTransferObjects;
using System.Xml.Linq;

namespace Controllers
{
    public class MaterialManagementController
    {
        private MaterialManagementService _service;
        
        public MaterialManagementController(MaterialManagementService service)
        {
            _service = service;
        }

        public void AddMaterial(MaterialDTO materialDTO)
        {
            try
            {
                _service.AddMaterial(materialDTO);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public void RemoveMaterial(string name, string ownerName)
        {
            try
            {
                _service.RemoveMaterial(name, ownerName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MaterialDTO> GetMaterialsFromUser(string owner) 
        {
            return _service.GetMaterialsFromUser(owner);
        }

    }
}
