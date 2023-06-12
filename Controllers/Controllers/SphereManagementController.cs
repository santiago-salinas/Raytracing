using Controllers.Exceptions;
using DataTransferObjects;
using Services;
using Services.Exceptions;
using System.Collections.Generic;

namespace Controllers
{
    public class SphereManagementController
    {
        private SphereManagementService _service;
        private ModelManagementService _modelManagementService;

        public SphereManagementController(SphereManagementService sphereService, ModelManagementService modelService)
        {
            _service = sphereService;
            _modelManagementService = modelService;
        }

        public void AddSphere(SphereDTO sphereDTO)
        {
            try
            {
                _service.AddSphere(sphereDTO);
            }
            catch (Service_ObjectHandlingException exception)
            {
                throw new Controller_ObjectHandlingException(exception.Message);
            }
        }

        public void RemoveSphere(string name, string ownerName)
        {
            if (_modelManagementService.ExistsModelUsingSphere(name, ownerName))
            {
                throw new Controller_ObjectHandlingException("Cannot remove a sphere that is being used by a model");
            }
            else
            {
                _service.RemoveSphere(name, ownerName);
            }
        }

        public List<SphereDTO> GetSpheresFromUser(string owner)
        {
            return _service.GetSpheresFromUser(owner);
        }
    }
}
