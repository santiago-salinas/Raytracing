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

            Color color = new Color((float)133/255, (float)94 / 255, (float)66 / 255);

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

            testScene.AddPositionedModel(testPositionedModel);
        }

        [TestMethod]
        public void RenderTestScene()
        {
            Motor motor = new Motor(testScene);
            PPM ppm = motor.render();

            PPM expected = new PPM(5, 5);

            Color color = new Color(0, 0.8, 0.2);
            Color color2 = new Color(0.2, 0.8, 0.2);
            Color color3 = new Color(0.4, 0.8, 0.2);
            Color color4 = new Color(0.6, 0.8, 0.2);
            Color color5 = new Color(0.8, 0.8, 0.2);
            Color color6 = new Color(0, 0.6, 0.2);
            Color color7 = new Color(0.2, 0.6, 0.2);
            Color color8 = new Color(0.4, 0.6, 0.2);
            Color color9 = new Color(0.6, 0.6, 0.2);
            Color color10 = new Color(0.8, 0.6, 0.2);
            Color color11 = new Color(0, 0.4, 0.2);
            Color color12 = new Color(0.2, 0.4, 0.2);
            Color color13 = new Color(0.4, 0.4, 0.2);
            Color color14 = new Color(0.6, 0.4, 0.2);
            Color color15 = new Color(0.8, 0.4, 0.2);
            Color color16 = new Color(0, 0.2, 0.2);
            Color color17 = new Color(0.2, 0.2, 0.2);
            Color color18 = new Color(0.4, 0.2, 0.2);
            Color color19 = new Color(0.6, 0.2, 0.2);
            Color color20 = new Color(0.8, 0.2, 0.2);
            Color color21 = new Color(0, 0, 0.2);
            Color color22 = new Color(0.2, 0, 0.2);
            Color color23 = new Color(0.4, 0, 0.2);
            Color color24 = new Color(0.6, 0, 0.2);
            Color color25 = new Color(0.8, 0, 0.2);

            expected.SavePixel(4,0,color);
            expected.SavePixel(4, 1, color2);
            expected.SavePixel(4, 2, color3);
            expected.SavePixel(4, 3, color4);
            expected.SavePixel(4, 4, color5);

            expected.SavePixel(3, 0, color6);
            expected.SavePixel(3, 1, color7);
            expected.SavePixel(3, 2, color8);
            expected.SavePixel(3, 3, color9);
            expected.SavePixel(3, 4, color10);

            expected.SavePixel(2, 0, color11);
            expected.SavePixel(2, 1, color12);
            expected.SavePixel(2, 2, color13);
            expected.SavePixel(2, 3, color14);
            expected.SavePixel(2, 4, color15);

            expected.SavePixel(1, 0, color16);
            expected.SavePixel(1, 1, color17);
            expected.SavePixel(1, 2, color18);
            expected.SavePixel(1, 3, color19);
            expected.SavePixel(1, 4, color20);

            expected.SavePixel(0, 0, color21);
            expected.SavePixel(0, 1, color22);
            expected.SavePixel(0, 2, color23);
            expected.SavePixel(0, 3, color24);
            expected.SavePixel(0, 4, color25);

            Trace.WriteLine((ppm.GetImageAscii()));
            Trace.WriteLine((expected.GetImageAscii()));

            Assert.IsTrue(ppm.GetImageAscii()==expected.GetImageAscii());
        }
    }
}
