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
        private int defaultFOV;

        private Vector testPosition;
        private PositionedModel testPositionedModel;

        private Sphere testSphereFloor;
        private Vector testPositionFloor;
        private Model testModelFloor;
        private Color colorFloor;
        private string lambertianNameFloor;
        private Lambertian testLambertianFloor;
        private PositionedModel testPositionedModelFloor;

        private Camera camera;

        [TestInitialize]
        public void Initialize()
        {
            
            testSceneName = "Standing Blue Ball";

            testScene = new Scene()
            {
                Name = testSceneName
            };


            sphereName = "Ball";
            radius = 0.5;
            testSphere = new Sphere(sphereName, radius);

            color = new Color(0.1, 0.2, 0.5);
            lambertianName = "Bloo passport";
            testLambertian = new Lambertian(lambertianName, color);

            modelName = "Blue Ball";
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
            colorFloor = new Color(0.8, 0.8, 0.0);
            lambertianNameFloor = "Touch Grass Green";
            testLambertianFloor = new Lambertian(lambertianNameFloor, colorFloor);

            modelName = "Green Floor";
            testModelFloor = new Model()
            {
                Name = modelName,
                ModelShape = testSphereFloor,
                ModelColor = testLambertianFloor
            };

            testPositionFloor = new Vector(0, -100.5, -1);
            testPositionedModelFloor = new PositionedModel()
            {
                PositionedModelModel = testModelFloor,
                PositionedModelPosition = testPositionFloor
            };

            testScene.AddPositionedModel(testPositionedModel);
            testScene.AddPositionedModel(testPositionedModelFloor);


            Vector origin = new Vector(0, 0, 0);

            Vector lookAt = new Vector(0, 0.5, -2);
            Vector vectorUp = new Vector(0, 1, 0);

            int samplesPerPixel = 10;
            int depth = 50;

            camera = new Camera(origin, lookAt, vectorUp, 40, 5, 5, samplesPerPixel, depth);

            defaultLookFromVector = new Vector(-10,-10 , -10);
            defaultLookAtVector = new Vector(-40, -1, -1);
            defaultFOV = 30;
           

        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene, camera);
            motor.RandomOff();
            PPM ppm = motor.render();

            Trace.WriteLine((ppm.GetImageAscii()));

            string expectedString = "P3\r\n5 5\r\n255\r\n166 202 255\r\n157 196 255\r\n151 193 255\r\n157 196 255\r\n166 202 255\r\n178 209 255\r\n172 205 255\r\n17 40 128\r\n172 205 255\r\n178 209 255\r\n191 217 255\r\n191 217 255\r\n19 43 128\r\n191 217 255\r\n191 217 255\r\n102 143 0\r\n102 143 0\r\n10 29 0\r\n102 143 0\r\n102 143 0\r\n102 143 0\r\n102 143 0\r\n8 23 0\r\n102 143 0\r\n102 143 0\r\n";
            Assert.IsTrue(expectedString == ppm.GetImageAscii());
        }
    }
}
