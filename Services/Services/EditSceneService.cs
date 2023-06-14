﻿using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using DataTransferObjects.DTOs;
using DataTransferObjects.Mappers;
using RepoInterfaces;
using System;
using System.Collections.Generic;

namespace Services
{
    public class EditSceneService
    {
        private ISceneRepository _sceneRepository;
        public EditSceneService(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public SceneDTO CreateNewScene(string owner, string name)
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
                SamplesPerPixel = 50,
                Aperture = 1.0,
            };

            SceneDTO newScene = new SceneDTO()
            {
                Owner = owner,
                Name = name,
                CameraDTO = defaultCameraValues,
                PositionedModels = new List<PositionedModelDTO>(),
                CreationDate = DateTimeProvider.Now,
                LastRenderDate = DateTimeProvider.Now,
                LastModificationDate = DateTimeProvider.Now,
                Blur = false,
            };

            return newScene;
        }

        public void UpdateLastRenderDate(SceneDTO sceneDTO)
        {
            DateTime newDate = DateTimeProvider.Now;
            sceneDTO.LastRenderDate = newDate;
            sceneDTO.LastModificationDate = newDate;
            string sceneName = sceneDTO.Name;
            string owner = sceneDTO.Owner;
            _sceneRepository.UpdateModificationDate(sceneName, owner, newDate);
            _sceneRepository.UpdateRenderDate(sceneName, owner, newDate);
        }

        public void UpdateBlurSetting(SceneDTO sceneDTO)
        {
            bool newState = sceneDTO.Blur;
            string sceneName = sceneDTO.Name;
            string owner = sceneDTO.Owner;
            _sceneRepository.UpdateBlurSetting(sceneName, owner, newState);
        }

        public void UpdateLastModificationDate(SceneDTO sceneDTO)
        {
            string sceneName = sceneDTO.Name;
            string owner = sceneDTO.Owner;
            DateTime newDate = DateTimeProvider.Now;
            sceneDTO.LastModificationDate = newDate;
            _sceneRepository.UpdateModificationDate(sceneName, owner, newDate);
        }

        public void UpdateCamera(SceneDTO sceneDTO)
        {
            BLCameraDTO camera = CameraMapper.ConvertToDomainCamDTO(sceneDTO.CameraDTO);
            _sceneRepository.UpdateCamera(sceneDTO.Name, sceneDTO.Owner, camera);
        }

        public void UpdateBlur(SceneDTO sceneDTO)
        {
            bool newBlurConfig = sceneDTO.Blur;
            string sceneName = sceneDTO.Name;
            string owner = sceneDTO.Owner;
            _sceneRepository.UpdateBlur(sceneName, owner, newBlurConfig);
        }

        public void UpdatePreview(SceneDTO sceneDTO)
        {
            PPM ppm = PPMMapper.ConvertToPPM(sceneDTO.Preview);
            _sceneRepository.UpdatePreview(sceneDTO.Name, sceneDTO.Owner, ppm);
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
