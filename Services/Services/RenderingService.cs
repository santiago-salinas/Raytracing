using BusinessLogic;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepoInterfaces;
using BusinessLogic.Objects;

namespace Services
{
    public class RenderingService
    {
        public RenderingService() { }

        public PpmDTO RenderModelPreview(MaterialDTO material)
        {            
            Scene previewScene = new Scene();

            Model previewModel = new Model()
            {
                Material = MaterialMapper.ConvertToMaterial(material),
                Shape = new Sphere() { Radius = 1 },
            };

            Vector position = new Vector(1, 1, 1);
            PositionedModel positionedModel = new PositionedModel()
            {
                Model = previewModel,
                Position = position
            };

            previewScene.AddPositionedModel(positionedModel);

            previewScene.CameraDTO = new BLCameraDTO()
            {
                LookFrom = new Vector(0, 5, 0),
                LookAt = new Vector(1, 1, 1),
                Up = new Vector(0, 1, 0),
                FieldOfView = 40,
                ResolutionX = 50,
                ResolutionY = 50,
                SamplesPerPixel = 50,
                MaxDepth = 10,
            };

            ICamera camera = CameraFactory(previewScene);

            Engine renderEngine = new Engine(previewScene, camera);
            PPM preview = renderEngine.Render();

            return PPMMapper.ConvertToDTO(preview);
        }

        public PpmDTO RenderScene(SceneDTO providedScene)
        {
            Scene renderScene = SceneMapper.ConvertToScene(providedScene);

            ICamera camera = CameraFactory(renderScene);
            
            Engine renderEngine = new Engine(renderScene, camera); 
            PPM render = renderEngine.Render();

            return PPMMapper.ConvertToDTO(render);
        }

        public ICamera CameraFactory(Scene scene)
        {
            if (scene.Blur)
            {
                return new CameraBlur(scene.CameraDTO);
            }
            else
            {
                return new Camera(scene.CameraDTO);
            }
        }
    }
}
