using BusinessLogic;
using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class RenderUnitTest

    {
        // Sphere 1
        private Model model1;
        private string model1Name;

        private Sphere sphere1;
        private string sphere1Name;
        private double sphere1Radius;

        private Lambertian lambertian1;
        private string lambertian1Name;
        private Color color1;

        private Vector position1;
        private PositionedModel positionedModel1;

        // Sphere 2
        private Model model2;
        private string model2Name;

        private Sphere sphere2;
        private string sphere2Name;
        private double sphere2Radius;

        private Lambertian lambertian2;
        private string lambertian2Name;
        private Color color2;

        private Vector position2;
        private PositionedModel positionedModel2;

        // Sphere 3
        private Model model3;
        private string model3Name;

        private Sphere sphere3;
        private string sphere3Name;
        private double sphere3Radius;

        private Lambertian lambertian3;
        private string lambertian3Name;
        private Color color3;

        private Vector position3;
        private PositionedModel positionedModel3;

        // Terrain 4
        private Model model4;
        private string model4Name;

        private Sphere sphere4;
        private string sphere4Name;
        private double sphere4Radius;

        private Lambertian lambertian4;
        private string lambertian4Name;
        private Color color4;

        private Vector position4;
        private PositionedModel positionedModel4;

        // Scene
        private Scene testScene;
        private string testSceneName;

        private Vector defaultLookFromVector;
        private Vector defaultLookAtVector;
        private int defaultFOV;

        private Camera camera;

        [TestInitialize]
        public void Initialize()
        {
            // Sphere 1
            testSceneName = "Render Cliche";

            testScene = new Scene()
            {
                Name = testSceneName
            };

            sphere1Name = "Spehere1";
            sphere1Radius = 0.5;
            sphere1 = new Sphere(sphere1Name, sphere1Radius);

            color1 = new Color(0.1, 0.2, 0.5);
            lambertian1Name = "Color1";
            lambertian1 = new Lambertian(lambertian1Name, color1);

            model1Name = "Model1";
            model1 = new Model()
            {
                Name = model1Name,
                ModelShape = sphere1,
                ModelColor = lambertian1
            };

            position1 = new Vector(0, 0.5, -2);
            positionedModel1 = new PositionedModel()
            {
                PositionedModelModel = model1,
                PositionedModelPosition = position1
            };

            testScene.AddPositionedModel(positionedModel1);

            // Sphere 2

            sphere2Name = "Spehere2";
            sphere2Radius = 0.5;
            sphere2 = new Sphere(sphere2Name, sphere2Radius);

            color2 = new Color(0.8, 0.2, 0.5);
            lambertian2Name = "Color2";
            lambertian2 = new Lambertian(lambertian2Name, color2);

            model2Name = "Model2";
            model2 = new Model()
            {
                Name = model2Name,
                ModelShape = sphere2,
                ModelColor = lambertian2
            };

            position2 = new Vector(-1, 0.5, -2);
            positionedModel2 = new PositionedModel()
            {
                PositionedModelModel = model2,
                PositionedModelPosition = position2
            };

            testScene.AddPositionedModel(positionedModel2);

            // Sphere 3

            sphere3Name = "Spehere3";
            sphere3Radius = 2;
            sphere3 = new Sphere(sphere3Name, sphere3Radius);

            color3 = new Color(0.8, 0.25, 0.05);
            lambertian3Name = "Color3";
            lambertian3 = new Lambertian(lambertian3Name, color3);

            model3Name = "Model3";
            model3 = new Model()
            {
                Name = model3Name,
                ModelShape = sphere3,
                ModelColor = lambertian3
            };

            position3 = new Vector(-1, 2, -10);
            positionedModel3 = new PositionedModel()
            {
                PositionedModelModel = model3,
                PositionedModelPosition = position3
            };

            testScene.AddPositionedModel(positionedModel3);

            // Terrain 4

            sphere4Name = "Spehere4";
            sphere4Radius = 2000;
            sphere4 = new Sphere(sphere4Name, sphere4Radius);

            color4 = new Color(0.7, 0.7, 0.1);
            lambertian4Name = "Color4";
            lambertian4 = new Lambertian(lambertian4Name, color4);

            model4Name = "Model4";
            model4 = new Model()
            {
                Name = model4Name,
                ModelShape = sphere4,
                ModelColor = lambertian4
            };

            position4 = new Vector(0, -2000, -1);
            positionedModel4 = new PositionedModel()
            {
                PositionedModelModel = model4,
                PositionedModelPosition = position4
            };

            testScene.AddPositionedModel(positionedModel4);


            Vector origin = new Vector(4, 2, 8);

            Vector lookAt = new Vector(0, 0.5, -2);
            Vector vectorUp = new Vector(0, 1, 0);

            int samplesPerPixel = 100;
            int depth = 50;

            camera = new Camera(origin, lookAt, vectorUp, 40, 500, 500, samplesPerPixel, depth);

            defaultLookFromVector = new Vector(-10,-10 , -10);
            defaultLookAtVector = new Vector(-40, -1, -1);
            defaultFOV = 30;
           

        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene, camera);
            //motor.RandomOff();
            PPM ppm = motor.render();

            Trace.WriteLine((ppm.GetImageAscii()));

            string expectedString = "P3\r\n5 5\r\n255\r\n166 202 255\r\n157 196 255\r\n151 193 255\r\n157 196 255\r\n166 202 255\r\n178 209 255\r\n172 205 255\r\n17 40 128\r\n172 205 255\r\n178 209 255\r\n191 217 255\r\n191 217 255\r\n19 43 128\r\n191 217 255\r\n191 217 255\r\n102 143 0\r\n102 143 0\r\n10 29 0\r\n102 143 0\r\n102 143 0\r\n102 143 0\r\n102 143 0\r\n8 23 0\r\n102 143 0\r\n102 143 0\r\n";
            Assert.IsTrue(expectedString == ppm.GetImageAscii());
        }
    }
}
