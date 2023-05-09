using BusinessLogic;
using System;
using System.Windows.Forms;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            User user1 = new User()
            {
                UserName = "Test",
                Password = "Test1",
                RegisterDate = DateTime.Now,

            };

            Users.AddUser(user1);

            Sphere sphere1 = new Sphere("Sphere 1", 0.5f, user1);
            Sphere sphere2 = new Sphere("Sphere 2", 0.5f, user1);
            Sphere sphere3 = new Sphere("Sphere 3", 2f, user1);
            Sphere sphere4 = new Sphere("Floor", 2000f, user1);


            Spheres.AddSphere(sphere1);
            Spheres.AddSphere(sphere2);
            Spheres.AddSphere(sphere3);
            Spheres.AddSphere(sphere4);


            Color color1 = new Color(0.1, 0.2, 0.5);
            Color color2 = new Color(0.8, 0.2, 0.5);
            Color color3 = new Color(0.8, 0.25, 0.05);
            Color color4 = new Color(0.7, 0.7, 0.1);
            Lambertian lambertian1 = new Lambertian("Lambertian 1", color1, user1);
            Lambertian lambertian2 = new Lambertian("Lambertian 2", color2, user1);
            Lambertian lambertian3 = new Lambertian("Lambertian 3", color3, user1);
            Lambertian lambertian4 = new Lambertian("Lambertian 4", color4, user1);

            Lambertians.AddLambertian(lambertian1);
            Lambertians.AddLambertian(lambertian2);
            Lambertians.AddLambertian(lambertian3);
            Lambertians.AddLambertian(lambertian4);


            Model model1 = new Model("Model 1", sphere1, lambertian1, user1);
            Model model2 = new Model("Model 2", sphere2, lambertian2, user1);
            Model model3 = new Model("Model 3", sphere3, lambertian3, user1);
            Model model4 = new Model("Model 4", sphere4, lambertian4, user1);

            Models.AddModel(model1);
            Models.AddModel(model2);
            Models.AddModel(model3);
            Models.AddModel(model4);


            CameraDTO defaultCameraValues = new CameraDTO()
            {
                LookFrom = new Vector(4, 2, 8),
                LookAt = new Vector(0, 0.5, -2),
                Up = new Vector(0, 1, 0),
                FieldOfView = 40,
                MaxDepth = 50,
                ResolutionX = 300,
                ResolutionY = 200,
                SamplesPerPixel = 100
            };

            Scene scene1 = new Scene()
            {
                Name = "Scene 1",
                LastModificationDate = DateTime.Now,
                LastRenderDate = DateTime.Now,
                Owner = user1,
                CameraDTO = defaultCameraValues,
            };

            Scenes.AddScene(scene1);

            scene1.AddPositionedModel(new PositionedModel()
            {
                Model = model1,
                Position = new Vector(0, 0.5, -2)
            });

            scene1.AddPositionedModel(new PositionedModel()
            {
                Model = model2,
                Position = new Vector(-1, 0.5, -2)
            });

            scene1.AddPositionedModel(new PositionedModel()
            {
                Model = model3,
                Position = new Vector(-1, 2, -10)
            });

            scene1.AddPositionedModel(new PositionedModel()
            {
                Model = model4,
                Position = new Vector(0, -2000, -1)
            });

            Application.Run(new LogInPage());

            Application.Exit();
        }
    }
}
