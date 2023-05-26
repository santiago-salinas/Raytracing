using System;
using Services;
using System.Collections.Generic;
using DataTransferObjects;
using Controllers.Interfaces;

namespace Controllers.Controllers
{
    public class ModelManagementController
    {
        private ModelManagementService _modelService;
        private SphereManagementService _sphereService;
        private MaterialManagementService _materialService;

        public ModelManagementController(ModelManagementService modelService, SphereManagementService sphereService, MaterialManagementService materialService)
        {
            _modelService = modelService;
            _sphereService = sphereService;
            _materialService = materialService;
        }

        public void AddModel(ModelDTO modelDTO)
        {
            try
            {
                _modelService.AddModel(modelDTO);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelDTO> GetModelsFromUser(string owner)
        {
            return _modelService.GetModelsFromUser(owner);
        }

        public void RemoveModel(string name, string owner)
        {
            try
            {
                _modelService.RemoveModel(name, owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<LambertianDTO> GetAvailableMaterials(string owner)
        {
            return _materialService.GetLambertiansFromUser(owner);
        }

        public List<SphereDTO> GetAvailableShapes(string owner)
        {
            return _sphereService.GetSpheresFromUser(owner);
        }

    }
}
