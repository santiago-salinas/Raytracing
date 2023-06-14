using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using DataTransferObjects.DTOs;
using DataTransferObjects.Mappers;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Controllers;
using Services;
using Services.Exceptions;
using Controllers.Exceptions;
using System.Runtime.InteropServices;

namespace EntityFrameworkTests
{
    [TestClass]
    public class SceneEntityTest
    {
        private EFSphereRepository eFSphereRepository = new EFSphereRepository();
        private EFUserRepository eFUserRepository = new EFUserRepository();
        private EFMaterialRepository eFMaterialRepository = new EFMaterialRepository();
        private EFModelRepository eFModelRepository = new EFModelRepository();
        private EFSceneRepository eFSceneRepository = new EFSceneRepository();

        private SphereManagementService sphereManagementService;
        private MaterialManagementService materialManagementService;
        private ModelManagementService modelManagementService;
        private SceneManagementService sceneManagementService;
        private UserService userService;
        private EditSceneService editSceneService;
        private RenderingService renderingService;

        private SphereManagementController sphereManagementController;
        private MaterialManagementController materialManagementController;
        private ModelManagementController modelManagementController;
        private SceneManagementController sceneController;
        private UserController userController;
        private EditSceneController editSceneController;

        private SceneDTO _testScene;
        private PositionedModelDTO _testPosModel;
        private Metallic _testMat;
        private MaterialEntity _testMatEntity;
        private Sphere _testSphere;
        private SphereEntity _testSphereEntity;
        private User _testUser;
        private SphereDTO _sphereDto;
        private MaterialDTO _matDto;

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
            editSceneController.ModelManagementService = modelManagementService;
            editSceneController.EditSceneService = editSceneService;
            editSceneController.RenderingService = renderingService;
            editSceneController.SceneManagementService = sceneManagementService;

            _testUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now,
            };
            User _testUser2 = new User()
            {
                UserName = "TestUser2",
                Password = "Password1",
                RegisterDate = DateTime.Now,
            };
            _testMat = new Metallic
            {
                Name = "Test Material",
                Owner = "TestUser",
                Color = new Color(1, 0, 0),
                Roughness = 0.5,
            };
            _testSphere = new Sphere
            {
                Name = "Test Sphere",
                Owner = "TestUser",
                Radius = 10,
            };
            Model testModel = new Model()
            {
                Name = "Test Model",
                Shape = _testSphere,
                Material = _testMat,
                Owner = "TestUser"
            };

            PositionedModel positiondeModel = new PositionedModel()
            {
                Model = testModel,
                Position = new Vector(0, 0.5, -2)
            };

            VectorDTO origin = new VectorDTO(4, 2, 8);
            VectorDTO lookAt = new VectorDTO(0, 1, -2);
            VectorDTO vectorUp = new VectorDTO(0, 1, 0);
            int samplesPerPixel = 100;
            int depth = 50;
            UICameraDTO dto = new UICameraDTO()
            {
                LookFrom = origin,
                LookAt = lookAt,
                Up = vectorUp,
                FieldOfView = 30,
                ResolutionX = 50,
                ResolutionY = 50,
                SamplesPerPixel = samplesPerPixel,
                MaxDepth = depth,
                Aperture = 0.2,
            };

            DateTime validDate = new DateTime(2023, 1, 1);
            _testScene = new SceneDTO
            {
                Name = "TestScene",
                Owner = "TestUser",
                CreationDate = validDate,
                Blur = false,
                CameraDTO = dto,
                LastModificationDate = validDate,
                LastRenderDate = validDate,
                PositionedModels = new List<PositionedModelDTO>(),
                Preview = null
            };

            _sphereDto = SphereMapper.ConvertToDTO(_testSphere);
            _matDto = MaterialMapper.ConvertToDTO(_testMat);
            _testPosModel = PositionedModelMapper.ConvertPositionedModelToDTO(positiondeModel);
            eFUserRepository.AddUser(_testUser);
            eFUserRepository.AddUser(_testUser2);
            eFMaterialRepository.AddMaterial(_testMat);
            eFSphereRepository.AddSphere(_testSphere);
            using (EFContext dbContext = new EFContext())
            {
                _testSphereEntity = dbContext.SphereEntities
                    .FirstOrDefault(m => m.Name == "Test Sphere" && m.OwnerId == "TestUser");
                _testMatEntity = dbContext.MaterialEntities
                        .FirstOrDefault(m => m.Name == "Test Material" && m.OwnerId == "TestUser");
            }
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (EFContext dbContext = new EFContext())
            {
                UserEntity user = dbContext.UserEntities.FirstOrDefault(m => m.Username == "TestUser");
                UserEntity user2 = dbContext.UserEntities.FirstOrDefault(m => m.Username == "TestUser2");
                List<MaterialEntity> materials = dbContext.MaterialEntities
                    .Include(m => m.Metallic)
                    .ToList();
                List<SphereEntity> spheres = dbContext.SphereEntities
                    .ToList();
                List<ModelEntity> models = dbContext.ModelEntities
                    .ToList();
                List<PositionedModelEntity> positionedModels = dbContext.PositionedModelEntities
                    .ToList();
                List<SceneEntity> scenes = dbContext.SceneEntities
                    .ToList();
                List<CameraEntity> cameras = dbContext.Set<CameraEntity>().ToList();
                dbContext.PositionedModelEntities.RemoveRange(positionedModels);
                dbContext.SceneEntities.RemoveRange(scenes);
                dbContext.Set<CameraEntity>().RemoveRange(cameras);
                dbContext.ModelEntities.RemoveRange(models);
                dbContext.SphereEntities.RemoveRange(spheres);
                dbContext.MetallicEntities.RemoveRange(materials.Select(m => m.Metallic));
                dbContext.MaterialEntities.RemoveRange(materials);
                dbContext.UserEntities.Remove(user);
                dbContext.UserEntities.Remove(user2);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void AddPositionedModelToScene()
        {
            sceneController.AddScene(_testScene);
            SceneDTO scene = sceneController.GetScenesFromUser("TestUser")[0];
            Assert.AreEqual(scene.PositionedModels.Count, 0);

            editSceneController.AddPositionedModel(_testPosModel,_testScene);
            scene = sceneController.GetScenesFromUser("TestUser")[0];

            Assert.AreEqual(scene.PositionedModels.Count, 1);
        }



        [TestMethod]
        public void RemovePositionedModelFromScene()
        {
            sceneController.AddScene(_testScene);
            SceneDTO scene = sceneController.GetScenesFromUser("TestUser")[0];
            Assert.AreEqual(scene.PositionedModels.Count, 0);

            editSceneController.AddPositionedModel(_testPosModel, _testScene);
            editSceneController.RemovePositionedModel(_testPosModel, _testScene);
            scene = sceneController.GetScenesFromUser("TestUser")[0];

            Assert.AreEqual(scene.PositionedModels.Count, 1);
        }

        public void AddSceneToCollection()
        {
            sceneController.AddScene(_testScene);
            bool added = eFSceneRepository.ContainsScene(_testScene.Name, "TestUser");

            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSceneFromCollection()
        {                       
            sceneController.AddScene(_testScene);
            Scene getScene = sceneManagementService.GetScene(_testScene.Name, "TestUser");
            
            Assert.AreEqual(SceneMapper.ConvertToScene(_testScene), getScene);
        }

        [TestMethod]
        public void RemoveSceneFromCollection()
        {
            sceneController.AddScene(_testScene);
            List<SceneDTO> scenes = sceneController.GetScenesFromUser("TestUser");
            Assert.AreEqual(scenes.Count, 1);

            sceneController.RemoveScene(_testScene.Name, _testScene.Owner);
            Assert.AreEqual(scenes.Count, 0);
        }


        /*[TestMethod]
        public void RemoveScene_ThrowsBusinessLogicException_WhenOwnerDoesNotHaveSceneWithGivenName()
        {
            // Arrange
            User user1 = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };
            User user2 = new User()
            {
                UserName = "User2",
                Password = "Password1"
            };
            Scene scene1 = new Scene()
            {
                Name = "scene1",
                Owner = user1.UserName,
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user2.UserName,
            };
            memorySceneRepository.AddScene(scene1);
            memorySceneRepository.AddScene(scene2);

            // Act
            Action act = () => memorySceneRepository.RemoveScene("scene1", user2.UserName);

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Owner does not have a scene with that name", exception.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene with the same name already exists in the collection")]
        public void CantAddSceneWithNameAlreadyInCollection()
        {
            //arrange
            User testUser = new User()
            {
                UserName = "Username1"
            };

            _testScene = new Scene()
            {
                Name = _testName,
                Owner = testUser.UserName
            };
            memorySceneRepository.AddScene(_testScene);

            //act
            Scene newScene = new Scene()
            {
                Name = _testName,
                Owner = testUser.UserName
            };
            memorySceneRepository.AddScene(newScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete model used by active scene")]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            //arrange
            memoryModelRepository.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            memorySceneRepository.AddScene(_testScene);

            //act
            memoryModelRepository.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void DeleteModelAfterDeletingScene()
        {
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser.UserName;
            _testScene.CameraDTO = _testCamera;
            memoryModelRepository.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            memorySceneRepository.AddScene(_testScene);

            memorySceneRepository.RemoveScene(_testScene.Name, testUser.UserName);
            memoryModelRepository.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void ModelIsUsedByScene()
        {

            _testUser = "Username";
            _testScene.Owner = _testUser;
            _testScene.CameraDTO = _testCamera;
            Assert.IsFalse(_testScene.ContainsModel(_testModel));
            _testModel.Owner = _testUser;
            memoryModelRepository.AddModel(_testModel);

            _testScene.AddPositionedModel(_testPositionedModel);

            Assert.IsTrue(_testScene.ContainsModel(_testModel));
            _testScene.RemovePositionedModel(_testPositionedModel);
            Assert.IsFalse(_testScene.ContainsModel(_testModel));
        }

        [TestMethod]
        public void GetScenesFromUser_ShouldReturnScenesOwnedByUser()
        {
            User user1 = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };
            User user2 = new User()
            {
                UserName = "User2",
                Password = "Password1"
            };

            Scene scene1 = new Scene()
            {
                Name = "scene1",
                Owner = user1.UserName,
                CameraDTO = _testCamera
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user1.UserName,
                CameraDTO = _testCamera
            };
            Scene scene3 = new Scene()
            {
                Name = "scene3",
                Owner = user2.UserName,
                CameraDTO = _testCamera
            };

            memorySceneRepository.AddScene(scene1);
            memorySceneRepository.AddScene(scene2);
            memorySceneRepository.AddScene(scene3);

            List<Scene> scenes = memorySceneRepository.GetScenesFromUser(user1.UserName);

            Assert.AreEqual(2, scenes.Count);
            Assert.IsTrue(scenes.Contains(scene1));
            Assert.IsTrue(scenes.Contains(scene2));
        }

        [TestMethod]
        public void GetScenesFromUser_ShouldReturnEmptyListIfNoScenesOwnedByUser()
        {

            User emptyUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1"
            };

            List<Scene> scenes = memorySceneRepository.GetScenesFromUser(emptyUser.UserName);

            Assert.AreEqual(0, scenes.Count);
        }*/
    }
}
