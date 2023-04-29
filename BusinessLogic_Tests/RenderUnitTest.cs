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
                Origin = origin
            };


        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene, camera);
            PPM ppm = motor.render();

            Trace.WriteLine((ppm.GetImageAscii()));

            string expectedString = "P3\r\n5 5\r\n255\r\n175 207 255\r\n168 203 255\r\n160 198 255\r\n160 198 255\r\n168 203 255\r\n186 213 255\r\n183 212 255\r\n69 157 237\r\n186 157 237\r\n183 212 255\r\n197 220 255\r\n123 255 125\r\n69 98 237\r\n186 98 237\r\n132 255 125\r\n125 255 128\r\n126 255 128\r\n127 255 128\r\n128 255 128\r\n129 255 128\r\n126 255 128\r\n127 255 128\r\n127 255 128\r\n128 255 128\r\n128 255 128\r\n";
            Assert.IsTrue(expectedString == ppm.GetImageAscii());
        }
    }
}
