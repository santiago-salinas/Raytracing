using Controllers.Exceptions;
using DataTransferObjects;
using Services;
using Services.Exceptions;
using System.Collections.Generic;

namespace Controllers
{
    public class MaterialManagementController
    {
        private MaterialManagementService _service;
        private ModelManagementService _modelManagementService;
        public MaterialManagementController(MaterialManagementService service, ModelManagementService modelManagementService)
        {
            _service = service;
            _modelManagementService = modelManagementService;
        }

        public void AddMaterial(MaterialDTO materialDTO)
        {
            try
            {
                _service.AddMaterial(materialDTO);
            }
            catch (Service_ArgumentException ex)
            {
                throw new Controller_ArgumentException(ex.Message);
            }
        }

        public void RemoveMaterial(string name, string ownerName)
        {
            if (_modelManagementService.ExistsModelUsingMaterial(name, ownerName))
            {
                throw new Controller_ObjectHandlingException("Cannot remove a material that is being used by a model");
            }
            else
            {
                _service.RemoveMaterial(name, ownerName);
            }
        }

        public List<MaterialDTO> GetMaterialsFromUser(string owner)
        {
            return _service.GetMaterialsFromUser(owner);
        }

    }
}
