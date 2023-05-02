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
        private Model testModel;
        private string modelName;

        private Sphere testSphere;
        private string sphereName;
        private double radius;

        private Lambertian testLambertian;
        private string lambertianName;
        private Color color;

        private Scene testScene;
        private string testSceneName;
        private Vector defaultLookFromVector;
        private Vector defaultLookAtVector;
        int defaultFOV;

        private Vector testPosition;
        private PositionedModel testPositionedModel;

        private Sphere testSphereFloor;
        private Vector testPositionFloor;
        private Model testModelFloor;
        private PositionedModel testPositionedModelFloor;

        private Camera camera;

        [TestInitialize]
        public void Initialize()
        {
            defaultLookFromVector = new Vector(0, 0, 0);
            defaultLookAtVector = new Vector(-2, -1, -1);
            defaultFOV = 30;
            testSceneName = "Skydiving Red Ball";

            testScene = new Scene()
            {
                Name = testSceneName
            };


            sphereName = "Ball";
            radius = 0.5;
            testSphere = new Sphere(sphereName, radius);

            color = new Color(1, 0, 0);
            lambertianName = "Bright Red";
            testLambertian = new Lambertian(lambertianName, color);

            modelName = "Red Ball";
            testModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };

            testPosition = new Vector(0, 0, -1);
            testPositionedModel = new PositionedModel()
            {
                PositionedModelModel = testModel,
                PositionedModelPosition = testPosition
            };


            sphereName = "Floor";
            radius = 100;
            testSphereFloor = new Sphere(sphereName, radius);

            modelName = "Green Floor";
            testModelFloor = new Model()
            {
                Name = modelName,
                ModelShape = testSphereFloor,
                ModelColor = testLambertian
            };

            testPositionFloor = new Vector(0, -100.5, -1);
            testPositionedModelFloor = new PositionedModel()
            {
                PositionedModelModel = testModelFloor,
                PositionedModelPosition = testPositionFloor
            };

            testScene.AddPositionedModel(testPositionedModel);
            testScene.AddPositionedModel(testPositionedModelFloor);


            Vector vectorLowerLeftCorner = new Vector(-2, -1, -1);
            Vector vectorHorizontal = new Vector(4, 0, 0);
            Vector vectorVertical = new Vector(0, 2, 0);
            Vector origin = new Vector(0, 0, 0);

            camera = new Camera
            {
                LowerLeftCorner = vectorLowerLeftCorner,
                Horizontal = vectorHorizontal,
                Vertical = vectorVertical,
                Origin = origin,

                ResolutionX = 5,
                ResolutionY = 5,

                SamplesPerPixel = 10,
            };


        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene, camera);
            motor.RandomOff();
            PPM ppm = motor.render();

            Trace.WriteLine((ppm.GetImageAscii()));

            string expectedString = "P3\r\n5 5\r\n255\r\n166 202 255\r\n157 196 255\r\n151 193 255\r\n157 196 255\r\n166 202 255\r\n178 209 255\r\n172 205 255\r\n82 100 128\r\n172 205 255\r\n178 209 255\r\n191 217 255\r\n191 217 255\r\n96 108 128\r\n191 217 255\r\n191 217 255\r\n64 89 128\r\n64 89 128\r\n32 45 64\r\n64 89 128\r\n64 89 128\r\n64 89 128\r\n64 89 128\r\n16 22 32\r\n64 89 128\r\n64 89 128\r\n";
            Assert.IsTrue(expectedString == ppm.GetImageAscii());
        }
    }
}
