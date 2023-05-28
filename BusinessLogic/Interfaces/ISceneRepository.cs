using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISceneRepository
    {
        void Drop();
        List<Scene> GetScenesFromUser(string owner);
        bool ContainsScene(string name, string owner);
        void AddScene(Scene newElement);
        Scene GetScene(string name, string owner);
        void RemoveScene(string name, string owner);
        void RemoveModelFromScene(Scene scene, PositionedModel model);
        void AddModelToScene(Scene scene, PositionedModel model);
        bool ExistsSceneUsingModel(Model model);
    }

}
