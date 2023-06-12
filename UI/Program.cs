using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using Controllers.Controllers;
using Services;
using RepoInterfaces;
using DataAccess;
using System.Security.Cryptography;
using DataAccess.Repositories;
using System.Threading;
using System.Data.SqlClient;
using Repositories;
using BusinessLogic.Objects;

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
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            //Sphere efSphere = new Sphere("Ef sphere", 0.5f, "Santi");
            EFSphereRepository eFSphereRepository = new EFSphereRepository();
            //eFSphereRepository.AddSphere(efSphere);
            EFUserRepository eFUserRepository = new EFUserRepository();
            EFMaterialRepository eFMaterialRepository = new EFMaterialRepository();
            EFModelRepository eFModelRepository = new EFModelRepository();
            EFSceneRepository eFSceneRepository = new EFSceneRepository();

            //MemoryUserRepository memoryUserRepository = new MemoryUserRepository();
            MemoryModelRepository memoryModelRepository = new MemoryModelRepository(eFSceneRepository);
            MemorySphereRepository memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
            MemoryMaterialRepository memoryMaterialRepository = new MemoryMaterialRepository(memoryModelRepository);

            SphereManagementService sphereManagementService = new SphereManagementService(eFSphereRepository);
            MaterialManagementService materialManagementService = new MaterialManagementService(eFMaterialRepository);
            //ModelManagementService modelManagementService = new ModelManagementService(memoryModelRepository);
            ModelManagementService modelManagementService = new ModelManagementService(eFModelRepository, eFSceneRepository);
            SceneManagementService sceneManagementService = new SceneManagementService(eFSceneRepository);
            //UserService userService = new UserService(memoryUserRepository);
            UserService userService = new UserService(eFUserRepository);
            EditSceneService editSceneService = new EditSceneService(eFSceneRepository);
            RenderingService renderingService = new RenderingService();

            SphereManagementController sphereManagementController = new SphereManagementController(sphereManagementService,modelManagementService);
            MaterialManagementController materialManagementController = new MaterialManagementController(materialManagementService, modelManagementService);
            ModelManagementController modelManagementController = new ModelManagementController();
            modelManagementController.SphereService = sphereManagementService;
            modelManagementController.ModelService = modelManagementService;
            modelManagementController.MaterialService = materialManagementService;
            modelManagementController.RenderingService = renderingService;
            SceneManagementController sceneController = new SceneManagementController(sceneManagementService);
            UserController userController = new UserController(userService);
            EditSceneController editSceneController = new EditSceneController();
            editSceneController.ModelManagementService = modelManagementService;
            editSceneController.EditSceneService = editSceneService;
            editSceneController.RenderingService = renderingService;
            editSceneController.SceneManagementService = sceneManagementService;

            Context context = new Context();
            context.SphereController = sphereManagementController;
            context.MaterialController = materialManagementController;
            context.ModelController = modelManagementController;
            context.SceneController = sceneController;
            context.UserController = userController;
            context.EditSceneController = editSceneController;

            User user1 = new User()
            {
                UserName = "Test",
                Password = "Test1",
                RegisterDate = DateTime.Now,
            };

            //eFUserRepository.AddUser(user1);
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

            memoryMaterialRepository.AddMaterial(lambertian1);
            memoryMaterialRepository.AddMaterial(lambertian2);
            memoryMaterialRepository.AddMaterial(lambertian3);
            memoryMaterialRepository.AddMaterial(lambertian4);


            Model model1 = new Model("Model 1", sphere1, lambertian1, user1.UserName);
            Model model2 = new Model("Model 2", sphere2, lambertian2, user1.UserName);
            Model model3 = new Model("Model 3", sphere3, lambertian3, user1.UserName);
            Model model4 = new Model("Model 4", sphere4, lambertian4, user1.UserName);

            memoryModelRepository.AddModel(model1);
            memoryModelRepository.AddModel(model2);
            memoryModelRepository.AddModel(model3);
            memoryModelRepository.AddModel(model4);


            BLCameraDTO defaultCameraValues = new BLCameraDTO()
            {
                LookFrom = new Vector(4, 2, 8),
                LookAt = new Vector(0, 0.5, -2),
                Up = new Vector(0, 1, 0),
                FieldOfView = 40,
                MaxDepth = 50,
                ResolutionX = 300,
                ResolutionY = 200,
                SamplesPerPixel = 100,

                Aperture = 1.0,
            };

            Scene scene1 = new Scene()
            {
                Name = "Scene 1",                
                Owner = user1.UserName,
                CameraDTO = defaultCameraValues,
            };

            //eFSceneRepository.AddScene(scene1);

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

        static void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            if(e.Exception is SqlException)
            {
                MessageBox.Show("An error ocurred when trying to connect with the database. The application will now close.","Connection Error");
                Application.Exit();
            }
        }
    }
}
