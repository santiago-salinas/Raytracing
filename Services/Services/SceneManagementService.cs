﻿using BusinessLogic;
using DataTransferObjects;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SceneManagementService
    {
        private ISceneRepository _sceneRepository;

        public SceneManagementService(ISceneRepository sceneRepository)
        {
            _sceneRepository = sceneRepository;
        }

        public List<SceneDTO> GetScenesFromUser(string owner)
        {
            List<Scene> scenes = _sceneRepository.GetScenesFromUser(owner);
            List<SceneDTO> sceneDTOs = new List<SceneDTO>();

            foreach (Scene scene in scenes)
            {
                SceneDTO sceneDTO = SceneMapper.ConvertSceneToDTO(scene);
                sceneDTOs.Add(sceneDTO);
            }

            return sceneDTOs;
        }

        public bool ContainsScene(string name, string owner)
        {
            return _sceneRepository.ContainsScene(name, owner);
        }

        public void AddScene(SceneDTO newElement)
        {
            Scene newScene = SceneMapper.ConvertToScene(newElement);
            _sceneRepository.AddScene(newScene);
        }

        public Scene GetScene(string name, string owner)
        {
            return _sceneRepository.GetScene(name, owner);
        }

        /*public void UpdateScene(SceneDTO sceneDTO) 
        {
            Scene scene = SceneMapper.ConvertToScene(sceneDTO);
            _sceneRepository.UpdateScene(scene);
        }*/

        public void RemoveScene(string name, string owner)
        {
            _sceneRepository.RemoveScene(name, owner);
        }
    }
}
