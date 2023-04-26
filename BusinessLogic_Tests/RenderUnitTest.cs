using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class RenderUnitTest

    {
        [TestMethod]
        public void TestRenderImage()
        {
            private Scene testScene = new Scene();
            defaultLookFromVector = new Vector(0, 2, 0);
            defaultLookAtVector = new Vector(0, 2, 5);
            defaultFOV = 30;

            testScene = new Scene()
            {
                Name = testName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
                FOV = defaultFOV
            };

            
            sphereName = "Small sized sphere";
            radius = 5;
            
            color = new Color(133, 94, 66);

            testSphere = new Sphere(sphereName, radius);
            color = new Color(0.5215686274509804, 0,3686274509803922, 0,2588235294117647);
            lambertianName = "Oak color";
            testLambertian = new Lambertian(lambertianName, color);

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

            private Motor motor = new Motor();
            private Resolution = {10,10};
            private PPM ppm = motor.render(testScene);
            private PPM expected = [];

            Assert.IsEqual(expected,ppm);

        }
    }
}
