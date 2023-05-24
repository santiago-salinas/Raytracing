using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using Controllers.Controllers;
using Repositories;
using Controllers.Converter;
using System.Security.Cryptography;

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

            ColorConverter colorConverter = new ColorConverter();
            PPMConverter ppmConverter = new PPMConverter(colorConverter);

            MemoryUserRepository memoryUserRepository = new MemoryUserRepository();
            MemorySceneRepository memorySceneRepository = new MemorySceneRepository();
            MemoryModelRepository memoryModelRepository = new MemoryModelRepository(memorySceneRepository);
            MemorySphereRepository memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
            MemoryLambertianRepository memoryLambertianRepository = new MemoryLambertianRepository(memoryModelRepository);

            SphereManagementController sphereController = new SphereManagementController(memorySphereRepository);
            MaterialManagementController lambertianController = new MaterialManagementController(memoryLambertianRepository, colorConverter);
            ModelManagementController modelController = new ModelManagementController()
            {
                MaterialController = lambertianController,
                ModelRepository = memoryModelRepository,
                PpmConverter = ppmConverter,
                SphereController = sphereController
            };
            SceneManagementController sceneController = new SceneManagementController(memorySceneRepository, modelController);

            Context context = new Context();
            context.SphereController = sphereController;
            context.LambertianController = lambertianController;
            context.ModelController = modelController;
            context.UserRepository = memoryUserRepository;
            context.SceneController = sceneController;
            

            User user1 = new User()
            {
                UserName = "Test",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };

            memoryUserRepository.AddUser(user1);
            string userName = user1.UserName;

            Sphere sphere1 = new Sphere("Sphere 1", 0.5f, userName);
            Sphere sphere2 = new Sphere("Sphere 2", 0.5f, userName);
            Sphere sphere3 = new Sphere("Sphere 3", 2f, userName);
            Sphere sphere4 = new Sphere("Floor", 2000f, userName);


            memorySphereRepository.AddSphere(sphere1);
            memorySphereRepository.AddSphere(sphere2);
            memorySphereRepository.AddSphere(sphere3);
            memorySphereRepository.AddSphere(sphere4);


            Color color1 = new Color(0.1, 0.2, 0.5);
            Color color2 = new Color(0.8, 0.2, 0.5);
            Color color3 = new Color(0.8, 0.25, 0.05);
            Color color4 = new Color(0.7, 0.7, 0.1);
            Lambertian lambertian1 = new Lambertian("Lambertian 1", color1, user1.UserName);
            Lambertian lambertian2 = new Lambertian("Lambertian 2", color2, user1.UserName);
            Lambertian lambertian3 = new Lambertian("Lambertian 3", color3, user1.UserName);
            Lambertian lambertian4 = new Lambertian("Lambertian 4", color4, user1.UserName);

            memoryLambertianRepository.AddLambertian(lambertian1);
            memoryLambertianRepository.AddLambertian(lambertian2);
            memoryLambertianRepository.AddLambertian(lambertian3);
            memoryLambertianRepository.AddLambertian(lambertian4);


            Model model1 = new Model("Model 1", sphere1, lambertian1, user1.UserName);
            Model model2 = new Model("Model 2", sphere2, lambertian2, user1.UserName);
            Model model3 = new Model("Model 3", sphere3, lambertian3, user1.UserName);
            Model model4 = new Model("Model 4", sphere4, lambertian4, user1.UserName);

            memoryModelRepository.AddModel(model1);
            memoryModelRepository.AddModel(model2);
            memoryModelRepository.AddModel(model3);
            memoryModelRepository.AddModel(model4);


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
                Owner = user1.UserName,
                CameraDTO = defaultCameraValues,
            };

            memorySceneRepository.AddScene(scene1);

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

            Application.Run(new LogInPage(context));

            Application.Exit();
        }
    }
}
