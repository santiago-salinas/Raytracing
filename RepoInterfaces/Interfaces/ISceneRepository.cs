using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using System;
using System.Collections.Generic;

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
        void UpdateBlurSetting(string sceneName, string owner, bool blurState);

        void UpdateModificationDate(string sceneName, string owner, DateTime date);
        void UpdateBlur(string sceneName, string owner, bool BlurConfig);
        void UpdateCamera(string sceneName, string owner, BLCameraDTO camera);
        void UpdatePreview(string sceneName, string owner, PPM ppm);

    }

}
