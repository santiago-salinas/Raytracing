using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using BusinessLogic;
using DataAccess;
using DataAccess.Entities;
using System.Linq;
using System.Collections.Generic;
using BusinessLogic.Objects;
using BusinessLogic.Utilities;

namespace EntityFrameworkTests
{
    [TestClass]
    public class UnitTest1
    {
        // Sphere 1
        private Model _model1;
        private string _model1Name;

        private Sphere _sphere1;
        private string _sphere1Name;
        private double _sphere1Radius;

        private Material _material1;
        private string _material1Name;
        private Color _color1;

        private Vector _position1;
        private PositionedModel _positionedModel1;

        // Sphere 2
        private Model model2;
        private string model2Name;

        private Sphere sphere2;
        private string sphere2Name;
        private double sphere2Radius;

        private Material material2;
        private string material2Name;
        private Color color2;

        private Vector position2;
        private PositionedModel positionedModel2;

        // Sphere 3
        private Model model3;
        private string model3Name;

        private Sphere sphere3;
        private string sphere3Name;
        private double sphere3Radius;

        private Material lambertian3;
        private string lambertian3Name;
        private Color color3;

        private Vector position3;
        private PositionedModel positionedModel3;

        // Sphere 4
        private Model model4;
        private string model4Name;

        private Sphere sphere4;
        private string sphere4Name;
        private double sphere4Radius;

        private Material lambertian4;
        private string lambertian4Name;
        private Color color4;

        private Vector position4;
        private PositionedModel positionedModel4;


        // Scene
        private Scene testScene;
        private string testSceneName;


        [TestInitialize]
        public void Initialize()
        {

        }

        [TestMethod]
        public void RenderTestScene()
        {// Sphere 1
            testSceneName = "Render Cliche";

            testScene = new Scene()
            {
                Name = testSceneName
            };

            _sphere1Name = "Spehere1";
            _sphere1Radius = 0.5;
            _sphere1 = new Sphere() { Name = _sphere1Name, Radius = _sphere1Radius };

            _color1 = new Color(0.1, 0.2, 0.5);
            _material1Name = "Color1";
            _material1 = new Lambertian() { Name = _material1Name, Color = _color1 };

            _model1Name = "Model1";
            _model1 = new Model()
            {
                Name = _model1Name,
                Shape = _sphere1,
                Material = _material1
            };

            _position1 = new Vector(0, 0.5, -2);
            _positionedModel1 = new PositionedModel()
            {
                Model = _model1,
                Position = _position1
            };

            testScene.AddPositionedModel(_positionedModel1);

            // Sphere 2

            sphere2Name = "Spehere2";
            sphere2Radius = 0.5;
            sphere2 = new Sphere() { Name = sphere2Name, Radius = sphere2Radius };


            color2 = new Color(0.8, 0.2, 0.5);
            material2Name = "Color2";
            material2 = new Lambertian() { Name = material2Name, Color = color2 };

            model2Name = "Model2";
            model2 = new Model()
            {
                Name = model2Name,
                Shape = sphere2,
                Material = material2
            };

            position2 = new Vector(-1, 0.5, -2);
            positionedModel2 = new PositionedModel()
            {
                Model = model2,
                Position = position2
            };

            testScene.AddPositionedModel(positionedModel2);

            // Sphere 3

            sphere3Name = "Spehere3";
            sphere3Radius = 2;
            sphere3 = new Sphere() { Name = sphere3Name, Radius = sphere3Radius };

            color3 = new Color(0.8, 0.25, 0.05);
            lambertian3Name = "Color3";
            lambertian3 = new Lambertian() { Name = lambertian3Name, Color = color3 };

            model3Name = "Model3";
            model3 = new Model()
            {
                Name = model3Name,
                Shape = sphere3,
                Material = lambertian3
            };

            position3 = new Vector(-1, 2, -10);
            positionedModel3 = new PositionedModel()
            {
                Model = model3,
                Position = position3
            };

            testScene.AddPositionedModel(positionedModel3);

            // Terrain 4

            sphere4Name = "Spehere4";
            sphere4Radius = 2000;
            sphere4 = new Sphere() { Name = sphere4Name, Radius = sphere4Radius };

            color4 = new Color(0.7, 0.7, 0.1);
            lambertian4Name = "Color4";
            lambertian4 = new Lambertian() { Name = lambertian4Name, Color = color4 };

            model4Name = "Model4";
            model4 = new Model()
            {
                Name = model4Name,
                Shape = sphere4,
                Material = lambertian4
            };

            position4 = new Vector(0, -2000, -1);
            positionedModel4 = new PositionedModel()
            {
                Model = model4,
                Position = position4
            };

            testScene.AddPositionedModel(positionedModel4);

            Vector origin = new Vector(4, 2, 8);

            Vector lookAt = new Vector(0, 0.5, -2);
            Vector vectorUp = new Vector(0, 1, 0);

            int samplesPerPixel = 100;
            int depth = 50;

            BLCameraDTO dto = new BLCameraDTO()
            {
                LookFrom = origin,
                LookAt = lookAt,
                Up = vectorUp,
                FieldOfView = 40,
                ResolutionX = 5,
                ResolutionY = 5,
                SamplesPerPixel = samplesPerPixel,
                MaxDepth = depth,
            };

            testScene.CameraDTO = dto;

            Engine motor = new Engine(testScene, new Camera(testScene.CameraDTO));
            motor.RandomOff();
            PPM ppm = motor.Render();

            //Save
            Guid id;
           using (EFContext dbContext = new EFContext())
           {
                PPMEntity entity = PPMEntity.FromDomain(ppm);
                id = entity.Id;
                dbContext.PPMEntities.Add(entity);
                dbContext.SaveChanges();
           }

           //Get
           PPM domainPPM = null;

            using (EFContext dbContext = new EFContext())
            {
                PPMEntity entityPPM = dbContext.PPMEntities.FirstOrDefault(entity => entity.Id == id);

                if (entityPPM != null)
                {
                    domainPPM = PPMEntity.FromEntity(entityPPM);
                }
            }
            Trace.WriteLine((domainPPM.GetImageAscii()));
            Assert.IsTrue(domainPPM.GetImageAscii() == ppm.GetImageAscii());

            
        }
    }
}
