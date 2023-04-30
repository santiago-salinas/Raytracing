using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class PositionedModelUnitTest
    {
        private PositionedModel testPositionedModel;
        private Vector testPosition;

        private Model testModel;
        private string modelName;

        private Sphere testSphere;
        private string sphereName;
        private float radius;

        private Lambertian testLambertian;
        private string lambertianName;
        private Color color;

        [TestInitialize]
        public void Initialize()
        {
            modelName = "Wooden ball";

            sphereName = "Small sized sphere";
            radius = 5;
            lambertianName = "Oak color";
            color = new Color((float)133 / 255, (float)94 / 255, (float)66 / 255);

            testSphere = new Sphere(sphereName, radius);
            testLambertian = new Lambertian(lambertianName, color);

            testModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };

            testPosition = new Vector(0, 0, 0);

            testPositionedModel = new PositionedModel()
            {
                PositionedModelModel = testModel,
                PositionedModelPosition = testPosition
            };
        }

        [TestMethod]
        public void PositionedModelCreatedSuccesfullyTest()
        {
            //arrange
            testPosition = new Vector(0, 0, 0);

            //act
            testPositionedModel = new PositionedModel()
            {
                PositionedModelModel = testModel,
                PositionedModelPosition = testPosition
            };
            //assert
            Assert.IsNotNull(testModel);
        }
    }
}
