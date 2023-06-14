using Controllers.Exceptions;
using DataTransferObjects.DTOs;
using Services;
using Services.Exceptions;
using System;
using System.Collections.Generic;

namespace Controllers
{
    public class SceneManagementController
    {
        private SceneManagementService _sceneManagementService;

        public SceneManagementController(SceneManagementService service)
        {
            _sceneManagementService = service;
        }

        public List<SceneDTO> GetScenesFromUser(string owner)
        {
            return _sceneManagementService.GetScenesFromUser(owner); ;
        }

        public void AddScene(SceneDTO newElement)
        {
            try
            {
                _sceneManagementService.AddScene(newElement);
            }
            catch (Service_ArgumentException ex)
            {
                throw new Controller_ArgumentException(ex.Message);
            }
        }

        public void RemoveScene(string name, string owner)
        {
            _sceneManagementService.RemoveScene(name, owner);
        }

    }
}
