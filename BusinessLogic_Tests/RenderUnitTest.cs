using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class RenderUnitTest

    {
        private Model testModel;
        private string modelName;
        private string testNullName;

        private Sphere testSphere;
        private string sphereName;
        private float radius;

        private Lambertian testLambertian;
        private string lambertianName;
        private Color color;

        private Scene testScene;
        private string testName;
        private Vector defaultLookFromVector;
        private Vector defaultLookAtVector;
        int defaultFOV;

        private Vector testPosition;
        private PositionedModel testPositionedModel;

        [TestInitialize]
        public void Initialize()
        {
            defaultLookFromVector = new Vector(0, 2, 0);
            defaultLookAtVector = new Vector(0, 2, 5);
            defaultFOV = 30;
            testName = "Rolling Balls";

            testScene = new Scene()
            {
                Name = testName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
                FOV = defaultFOV
            };


            string sphereName = "Small sized sphere";
            int radius = 5;

            Color color = new Color(133, 94, 66);

            testSphere = new Sphere(sphereName, radius);
            color = new Color(0.5215686274509804, 0.3686274509803922, 0.2588235294117647);
            lambertianName = "Oak color";
            Lambertian testLambertian = new Lambertian(lambertianName, color);

            modelName = "Wooden ball";
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
        public void RenderTestScene()
        {
            //PPM ppm = motor.render(testScene);
            //PPM expected = [];
            Assert.IsNotNull(testScene);
        }
    }
}
