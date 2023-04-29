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

        [TestInitialize]
        public void Initialize()
        {
            defaultLookFromVector = new Vector(0, 0, 0);
            defaultLookAtVector = new Vector(-2, -1, -1);
            defaultFOV = 30;
            testSceneName = "Rolling Balls";

            testScene = new Scene()
            {
                Name = testSceneName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
                FOV = defaultFOV
            };


            sphereName = "Red Ball";
            radius = 0.5;
            testSphere = new Sphere(sphereName, radius);

            color = new Color(1, 0, 0);
            lambertianName = "Bright Red";
            testLambertian = new Lambertian(lambertianName, color);

            modelName = "Skydiving Red Ball";
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

            testScene.AddPositionedModel(testPositionedModel);
        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene);
            PPM ppm = motor.render();

            Trace.WriteLine((ppm.GetImageAscii()));

            string expectedString = "P3\r\n5 5\r\n255\r\n175 207 255\r\n168 203 255\r\n160 198 255\r\n160 198 255\r\n168 203 255\r\n186 213 255\r\n183 212 255\r\n255 0 0\r\n255 0 0\r\n183 212 255\r\n197 220 255\r\n199 222 255\r\n255 0 0\r\n255 0 0\r\n199 222 255\r\n208 227 255\r\n214 230 255\r\n222 235 255\r\n222 235 255\r\n214 230 255\r\n217 232 255\r\n226 237 255\r\n235 243 255\r\n235 243 255\r\n226 237 255\r\n";
            Assert.IsTrue(expectedString==ppm.GetImageAscii());
        }
    }
}
