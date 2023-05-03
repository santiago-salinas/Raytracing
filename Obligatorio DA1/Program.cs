using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace Obligatorio_DA1
{
    internal class Program
    {
        // Sphere 1
        static Model model1;
        static string model1Name;

        static Sphere sphere1;
        static string sphere1Name;
        static double sphere1Radius;

        static Lambertian lambertian1;
        static string lambertian1Name;
        static Color color1;

        static Vector position1;
        static PositionedModel positionedModel1;

        // Sphere 2
        static Model model2;
        static string model2Name;

        static Sphere sphere2;
        static string sphere2Name;
        static double sphere2Radius;

        static Lambertian lambertian2;
        static string lambertian2Name;
        static Color color2;

        static Vector position2;
        static PositionedModel positionedModel2;

        // Sphere 3
        static Model model3;
        static string model3Name;

        static Sphere sphere3;
        static string sphere3Name;
        static double sphere3Radius;

        static Lambertian lambertian3;
        static string lambertian3Name;
        static Color color3;

        static Vector position3;
        static PositionedModel positionedModel3;

        // Terrain 4
        static Model model4;
        static string model4Name;

        static Sphere sphere4;
        static string sphere4Name;
        static double sphere4Radius;

        static Lambertian lambertian4;
        static string lambertian4Name;
        static Color color4;

        static Vector position4;
        static PositionedModel positionedModel4;

        // Scene
        static Scene testScene;
        static string testSceneName;

        static Vector defaultLookFromVector;
        static Vector defaultLookAtVector;
        static int defaultFOV;

        static Camera camera;
        static void Main(string[] args)
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

            defaultLookFromVector = new Vector(-10, -10, -10);
            defaultLookAtVector = new Vector(-40, -1, -1);
            defaultFOV = 30;

            Motor motor = new Motor(testScene, camera);
            //motor.RandomOff();
            PPM ppm = motor.render();

            File.WriteAllText("image.ppm", ppm.GetImageAscii());
        }
    }
}
