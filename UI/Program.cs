﻿using BusinessLogic;
using System;
using System.Windows.Forms;
using Controllers;
using Controllers.Controllers;
using Services;
using Repositories;
using DataAccess;
using System.Security.Cryptography;
using DataAccess.Repositories;

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

            //Sphere efSphere = new Sphere("Ef sphere", 0.5f, "Santi");
            EFSphereRepository eFSphereRepository = new EFSphereRepository();
            //eFSphereRepository.AddSphere(efSphere);
            EFUserRepository eFUserRepository = new EFUserRepository();

            //MemoryUserRepository memoryUserRepository = new MemoryUserRepository();
            MemorySceneRepository memorySceneRepository = new MemorySceneRepository();
            MemoryModelRepository memoryModelRepository = new MemoryModelRepository(memorySceneRepository);
            MemorySphereRepository memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
            MemoryLambertianRepository memoryLambertianRepository = new MemoryLambertianRepository(memoryModelRepository);

            //SphereManagementService sphereManagementService = new SphereManagementService(memorySphereRepository);
            SphereManagementService sphereManagementService = new SphereManagementService(eFSphereRepository);
            MaterialManagementService materialManagementService = new MaterialManagementService(memoryLambertianRepository);
            ModelManagementService modelManagementService = new ModelManagementService(memoryModelRepository);
            SceneManagementService sceneManagementService = new SceneManagementService(memorySceneRepository);
            //UserService userService = new UserService(memoryUserRepository);
            UserService userService = new UserService(eFUserRepository);
            EditSceneService editSceneService = new EditSceneService(memorySceneRepository);
            RenderingService renderingService = new RenderingService();

            SphereManagementController sphereManagementController = new SphereManagementController(sphereManagementService,modelManagementService);
            MaterialManagementController materialManagementController = new MaterialManagementController(materialManagementService);
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
            context.LambertianController = materialManagementController;
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
