using BusinessLogic.Exceptions;
using BusinessLogic.Objects;
using DataTransferObjects;
using RepoInterfaces;
using Services.Exceptions;
using System.Collections.Generic;

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
            try
            {
                if (ContainsScene(newElement.Name, newElement.Owner))
                {
                    throw new Service_ArgumentException("User already owns scene with that name");
                }
                else
                {
                    Scene newScene = SceneMapper.ConvertToScene(newElement);
                    _sceneRepository.AddScene(newScene);
                }
            }
            catch (BusinessLogicException ex)
            {
                throw new Service_ArgumentException(ex.Message);
            }
        }

        public Scene GetScene(string name, string owner)
        {
            return _sceneRepository.GetScene(name, owner);
        }

        public void RemoveScene(string name, string owner)
        {
            _sceneRepository.RemoveScene(name, owner);
        }
    }
}
