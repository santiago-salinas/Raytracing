using System;
using Services;
using System.Collections.Generic;
using DataTransferObjects;
using Controllers.Interfaces;

namespace Controllers.Controllers
{
    public class ModelManagementController
    {
        public ModelManagementService ModelService { get; set; }
        public SphereManagementService SphereService { get; set; }
        public MaterialManagementService MaterialService { get; set; }
        public RenderingService RenderingService { get; set; }

        public ModelManagementController()
        {

        }

        public void AddModel(ModelDTO modelDTO)
        {
            try
            {
                ModelService.AddModel(modelDTO);

            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ModelDTO> GetModelsFromUser(string owner)
        {
            return ModelService.GetModelsFromUser(owner);
        }

        public void RemoveModel(string name, string owner)
        {
            try
            {
                ModelService.RemoveModel(name, owner);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<MaterialDTO> GetAvailableMaterials(string owner)
        {
            return MaterialService.GetMaterialsFromUser(owner);
        }

        public List<SphereDTO> GetAvailableShapes(string owner)
        {
            return SphereService.GetSpheresFromUser(owner);
        }

        public PpmDTO RenderPreview(ModelDTO modelDTO)
        {            
            return RenderingService.RenderModelPreview(modelDTO.Material);
        }
    }
}
