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
using System.Data.Entity.Core.Metadata.Edm;

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
        private Model _testModel;

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
            _testModel = new Model()
            {
                Name = "Test Model",
                Shape = _testSphere,
                Material = _testMat,
                Owner = "TestUser"
            };

            PositionedModel positiondeModel = new PositionedModel()
            {
                Model = _testModel,
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
                ResolutionX = 5,
                ResolutionY = 5,
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
            eFModelRepository.AddModel(_testModel);
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
                List<PPMEntity> previews = dbContext.PPMEntities.ToList();

                dbContext.PositionedModelEntities.RemoveRange(positionedModels);
                dbContext.SceneEntities.RemoveRange(scenes);
                dbContext.PPMEntities.RemoveRange(previews);
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

            Assert.AreEqual(scene.PositionedModels.Count, 0);
        }

        [TestMethod]
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
            editSceneController.AddPositionedModel(_testPosModel, _testScene);
            List<SceneDTO> scenes = sceneController.GetScenesFromUser("TestUser");
            Assert.AreEqual(scenes.Count, 1);

            sceneController.RemoveScene(_testScene.Name, _testScene.Owner);
            scenes = sceneController.GetScenesFromUser("TestUser");
            Assert.AreEqual(scenes.Count, 0);
        }


        [TestMethod]
        [ExpectedException(typeof(Controller_ArgumentException))]
        public void CantAddSceneWithNameAlreadyInCollection()
        {
            sceneController.AddScene(_testScene);
            sceneController.AddScene(_testScene);
        }

        [TestMethod]
        [ExpectedException(typeof(Controller_ObjectHandlingException))]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            sceneController.AddScene(_testScene);
            editSceneController.AddPositionedModel(_testPosModel, _testScene);

            modelManagementController.RemoveModel(_testModel.Name,_testModel.Owner);
        }

        [TestMethod]
       public void UpdatePreviewTest()
       {
            sceneController.AddScene(_testScene);
            editSceneController.AddPositionedModel(_testPosModel, _testScene);
            SceneDTO sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];
            Assert.IsNull(sceneDTO.Preview);
            editSceneController.RenderScene(sceneDTO);
            sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];
            PPM previewFromDB = PPMMapper.ConvertToPPM(sceneDTO.Preview);

            Assert.IsNotNull(previewFromDB);
       }

        [TestMethod]
        public void UpdateDates()
        {
            sceneController.AddScene(_testScene);
            SceneDTO sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];

            DateTime previuosRenDate = sceneDTO.LastRenderDate;
            DateTime previuosModDate = sceneDTO.LastModificationDate;
            DateTimeProvider.Now = DateTime.Now.AddDays(1);
            editSceneController.UpdateRenderDate(sceneDTO);
            editSceneController.UpdateLastModificationDate(sceneDTO);

            sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];

            Assert.AreNotEqual(previuosModDate, sceneDTO.LastModificationDate);
            Assert.AreNotEqual(previuosRenDate, sceneDTO.LastRenderDate);
        }

        [TestMethod]
        public void UpdateCamera()
        {
            editSceneController.AddNewScene(_testScene);
            SceneDTO sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];
            UICameraDTO oldCam = sceneDTO.CameraDTO;

            sceneDTO.CameraDTO.SamplesPerPixel = 10;
            editSceneController.UpdateCamera(sceneDTO);

            sceneDTO = sceneController.GetScenesFromUser("TestUser")[0];

            Assert.AreNotEqual(sceneDTO.CameraDTO, oldCam);

        }

        [TestMethod]
        public void CreateNewScene()
        {
            SceneDTO scene = editSceneController.CreateNewScene("TestUser", "Test Scene");
            Assert.IsNotNull(scene);
        }

        [TestMethod]
        public void RenderModelPreview()
        {
            PpmDTO preview = renderingService.RenderModelPreview(MaterialMapper.ConvertToDTO(_testMat));
            Assert.IsNotNull(preview);
        }

        [TestMethod]
        public void GetAvailableModels()
        {
            ModelDTO model1 = new ModelDTO()
            {
                Material = _matDto,
                Name = "Test Model2",
                OwnerName = "TestUser",
                Shape = _sphereDto,
            };

            ModelDTO model2 = new ModelDTO()
            {
                Material = _matDto,
                Name = "Test Model3",
                OwnerName = "TestUser",
                Shape = _sphereDto,
            };

            modelManagementController.AddModel(model2);
            modelManagementController.AddModel(model1);

            List<ModelDTO> models = editSceneController.GetAvailableModels("TestUser");

            Assert.AreEqual(models.Count, 3);
        }

        
    }
}
