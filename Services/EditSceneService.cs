﻿using BusinessLogic;
using DataTransferObjects;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Services
{
    public class EditSceneService
    {
        private ISceneRepository _sceneRepository;
        public EditSceneService(ISceneRepository sceneRepository) 
        {
            _sceneRepository = sceneRepository;
        }

        public SceneDTO CreateNewScene(string owner)
        {
            UICameraDTO defaultCameraValues = new UICameraDTO()
            {
                LookFrom = new VectorDTO(0, 2, 0),
                LookAt = new VectorDTO(0, 2, 5),
                Up = new VectorDTO(0, 1, 0),
                FieldOfView = 30,
                MaxDepth = 20,
                ResolutionX = 300,
                ResolutionY = 200,
                SamplesPerPixel = 50
            };

            SceneDTO newScene = new SceneDTO()
            {
                Owner = owner,
                Name = "Empty scene",
                CameraDTO = defaultCameraValues,
                PositionedModels = new List<PositionedModelDTO>(),
                CreationDate = DateTimeProvider.Now,
                LastModificationDate = DateTimeProvider.Now,
            };
 
            return newScene;
        }

        public void UpdateLastRenderDate(SceneDTO sceneDTO)
        {
            sceneDTO.LastRenderDate = DateTimeProvider.Now;
        }

        public void UpdateLastModificationDate(SceneDTO sceneDTO)
        {
            sceneDTO.LastModificationDate = DateTimeProvider.Now;
        }

        public void RemovePositionedModel(PositionedModelDTO posModelDTO, SceneDTO sceneDTO)
        {
            Scene scene = GetScene(sceneDTO.Name, sceneDTO.Owner);
            PositionedModel positionedModel = PositionedModelMapper.ConvertToPositionedModel(posModelDTO);
            _sceneRepository.RemoveModelFromScene(scene, positionedModel);
            sceneDTO.PositionedModels.Remove(posModelDTO);
        }

        public void AddPositionedModel(PositionedModelDTO posModelDTO, SceneDTO sceneDTO)
        {
            Scene scene = GetScene(sceneDTO.Name, sceneDTO.Owner);
            PositionedModel positionedModel = PositionedModelMapper.ConvertToPositionedModel(posModelDTO);
            _sceneRepository.AddModelToScene(scene, positionedModel);
            sceneDTO.PositionedModels.Add(posModelDTO);
        }

        public Scene GetScene(string name, string owner)
        {
            return _sceneRepository.GetScene(name, owner);
        }


    }
}
