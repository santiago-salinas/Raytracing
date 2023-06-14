using BusinessLogic.DomainObjects;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BusinessLogic.Utilities;
using Controllers.Exceptions;
using DataTransferObjects.DTOs;
using Controllers;
using RepoInterfaces;
using Services;

namespace EntityFrameworkTests
{
    [TestClass]
    public class EFMaterialRepositoryTests
    {
        EFSphereRepository eFSphereRepository;
        EFUserRepository eFUserRepository;
        EFMaterialRepository eFMaterialRepository;
        EFModelRepository eFModelRepository;
        EFSceneRepository eFSceneRepository;

        SphereManagementService sphereManagementService;
        MaterialManagementService materialManagementService;
        ModelManagementService modelManagementService;
        SceneManagementService sceneManagementService;
        UserService userService;
        EditSceneService editSceneService;
        RenderingService renderingService;

        SphereManagementController sphereManagementController;
        MaterialManagementController materialManagementController;
        ModelManagementController modelManagementController;
        SceneManagementController sceneController;
        UserController userController;
        EditSceneController editSceneController;

        Context context;

        [TestInitialize]
        public void TestInitialize()
        {
            eFSphereRepository = new EFSphereRepository();
            eFUserRepository = new EFUserRepository();
            eFMaterialRepository = new EFMaterialRepository();
            eFModelRepository = new EFModelRepository();
            eFSceneRepository = new EFSceneRepository();

            sphereManagementService = new SphereManagementService(eFSphereRepository);
            materialManagementService = new MaterialManagementService(eFMaterialRepository);
            modelManagementService = new ModelManagementService(eFModelRepository, eFSceneRepository);
            sceneManagementService = new SceneManagementService(eFSceneRepository);
            userService = new UserService(eFUserRepository);
            editSceneService = new EditSceneService(eFSceneRepository);
            renderingService = new RenderingService();

            sphereManagementController = new SphereManagementController(sphereManagementService, modelManagementService);
            materialManagementController = new MaterialManagementController(materialManagementService, modelManagementService);
            modelManagementController = new ModelManagementController();
            modelManagementController.SphereService = sphereManagementService;
            modelManagementController.ModelService = modelManagementService;
            modelManagementController.MaterialService = materialManagementService;
            modelManagementController.RenderingService = renderingService;
            sceneController = new SceneManagementController(sceneManagementService);
            userController = new UserController(userService);
            editSceneController = new EditSceneController();
            
            context = new Context();
            context.SphereController = sphereManagementController;
            context.MaterialController = materialManagementController;
            context.ModelController = modelManagementController;
            context.SceneController = sceneController;
            context.UserController = userController;
            context.EditSceneController = editSceneController;

            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now,
            };
            eFUserRepository.AddUser(user);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (EFContext dbContext = new EFContext())
            {
                UserEntity user = dbContext.UserEntities.FirstOrDefault(m => m.Username == "TestUser");
                List<MaterialEntity> materials = dbContext.MaterialEntities
                    .Include(m => m.Metallic)
                    .Where(m => m.OwnerId == user.Username && m.Name.StartsWith("Test Material"))
                    .ToList();

                dbContext.MetallicEntities.RemoveRange(materials.Select(m => m.Metallic));
                dbContext.MaterialEntities.RemoveRange(materials);
                dbContext.UserEntities.Remove(user);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void AddMaterial_ValidMetallic_MetallicAdded()
        {
            ColorDTO colorDTO = new ColorDTO()
            {
                Red = 1,
                Green = 0,
                Blue = 0,
            };
            MaterialDTO NewMaterial = new MaterialDTO()
            {
                Name = "Test Material",
                Color = colorDTO,
                Owner = "TestUser",
                Type = "metallic",
                Roughness = 0.5,
            };

            
            context.MaterialController.AddMaterial(NewMaterial);

            List<Material> materialsFromUser = eFMaterialRepository.GetMaterialsFromUser("TestUser");

            Assert.AreEqual(1, materialsFromUser.Count);
            Assert.IsInstanceOfType(materialsFromUser[0], typeof(Metallic));
            Assert.AreEqual("Test Material", materialsFromUser[0].Name);
            Assert.AreEqual("TestUser", materialsFromUser[0].Owner);
        }

        [TestMethod]
        public void GetMaterial_ExistingMetallic_ReturnsMetallic()
        {
            Metallic metallic = new Metallic
            {
                Name = "Test Material",
                Owner = "TestUser",
                Color = new Color(1, 0, 0),
                Roughness = 0.5
            };

            using (EFContext dbContext = new EFContext())
            {
                MaterialEntity materialEntity = MaterialEntity.FromDomain(metallic, dbContext);
                dbContext.MaterialEntities.Add(materialEntity);
                dbContext.SaveChanges();
            }

            Material retrievedMaterial = eFMaterialRepository.GetMaterial("Test Material", "TestUser");

            Assert.IsNotNull(retrievedMaterial);
            Assert.IsInstanceOfType(retrievedMaterial, typeof(Metallic));
            Assert.AreEqual("Test Material", retrievedMaterial.Name);
            Assert.AreEqual("TestUser", retrievedMaterial.Owner);
        }

        [TestMethod]
        public void RemoveMaterial_ExistingMetallic_MetallicRemoved()
        {
            Metallic metallic = new Metallic
            {
                Name = "Test Material",
                Owner = "TestUser",
                Color = new Color(1, 0, 0),
                Roughness = 0.5
            };

            using (EFContext dbContext = new EFContext())
            {
                MaterialEntity materialEntity = MaterialEntity.FromDomain(metallic, dbContext);
                dbContext.MaterialEntities.Add(materialEntity);
                dbContext.SaveChanges();
            }

            eFMaterialRepository.RemoveMaterial("Test Material", "TestUser");

            using (EFContext dbContext = new EFContext())
            {
                List<MaterialEntity> materials = dbContext.MaterialEntities
                    .Where(m => m.OwnerId == "TestUser")
                    .ToList();

                Assert.AreEqual(0, materials.Count);
            }
        }

        [TestMethod]
        public void ContainsMaterial_Test()
        {
            Metallic metallic = new Metallic
            {
                Name = "Test Material",
                Owner = "TestUser",
                Color = new Color(1, 0, 0),
                Roughness = 0.5
            };

            Metallic metallic2 = new Metallic
            {
                Name = "Test Material2",
                Owner = "TestUser",
                Color = new Color(0, 0.2, 0),
                Roughness = 0.8
            };

            using (EFContext dbContext = new EFContext())
            {
                MaterialEntity materialEntity = MaterialEntity.FromDomain(metallic, dbContext);
                dbContext.MaterialEntities.Add(materialEntity);
                dbContext.SaveChanges();
            }

            bool containsMaterial = eFMaterialRepository.ContainsMaterial("Test Material", "TestUser");
            bool containsMaterial2 = eFMaterialRepository.ContainsMaterial("Test Material2", "TestUser");

            Assert.IsTrue(containsMaterial);
            Assert.IsFalse(containsMaterial2);
        }
    }

}
