using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Objects;
using BusinessLogic.Utilities;

namespace RepoInterfaces
{
    public interface ISceneRepository
    {
        List<Scene> GetScenesFromUser(string owner);
        bool ContainsScene(string name, string owner);
        void AddScene(Scene newElement);
        Scene GetScene(string name, string owner);
        void RemoveScene(string name, string owner);
        void RemoveModelFromScene(Scene scene, PositionedModel model);
        void AddModelToScene(Scene scene, PositionedModel model);
        bool ExistsSceneUsingModel(string modelName, string modelOwner);
        void UpdateRenderDate(string sceneName, string owner, DateTime date);
        void UpdateModificationDate(string sceneName, string owner, DateTime date);
        void UpdateCamera(string sceneName, string owner, BLCameraDTO camera);
        void UpdatePreview(string sceneName, string owner, PPM ppm);

    }

}
