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
    public class EFModelRepositoryTests
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
            _sphereDto = SphereMapper.ConvertToDTO(_testSphere);
            _matDto = MaterialMapper.ConvertToDTO(_testMat);
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
        public void GetModelsFromUser_ExistingUser_ReturnsModels()
        {
            string owner = "TestUser";
            ModelDTO model1 = new ModelDTO()
            {
                Name = "Test Model1",
                OwnerName = owner,
                Material = _matDto,
                Shape = _sphereDto,
            };
            ModelDTO model2 = new ModelDTO()
            {
                Name = "Test Model2",
                OwnerName = owner,
                Material = _matDto,
                Shape = _sphereDto,
            };
            modelManagementController.AddModel(model1);
            modelManagementController.AddModel(model2);


            List<ModelDTO> models = modelManagementController.GetModelsFromUser(owner);

            Assert.IsNotNull(models);
            Assert.AreEqual(2, models.Count);
            Assert.IsTrue(models.Any(m => m.Name == "Test Model1"));
            Assert.IsTrue(models.Any(m => m.Name == "Test Model2"));
        }

        [TestMethod]
        public void ContainsModel_ExistingModel_ReturnsTrue()
        {
            string name = "Test Model";
            string owner = "TestUser";
            ModelEntity modelEntity = new ModelEntity()
            {
                Name = name,
                OwnerId = owner,                
                Material = null,
                Shape = null,
                PPMEntity = null
            };
            using (EFContext dbContext = new EFContext())
            {
                dbContext.ModelEntities.Add(modelEntity);
                dbContext.SaveChanges();
            }
            bool containsModel = eFModelRepository.ContainsModel(name, owner);

            Assert.IsTrue(containsModel);
        }

        [TestMethod]
        public void ContainsModel_NonexistentModel_ReturnsFalse()
        {
            string name = "NonexistentModel";
            string owner = "TestUser";

            bool containsModel = eFModelRepository.ContainsModel(name, owner);

            Assert.IsFalse(containsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheMaterial_ModelUsingMaterialExists_ReturnsTrue()
        {
            string materialName = "Test Material2";
            string ownerUsername = "TestUser";
            Metallic materialEntity = new Metallic()
            {
                Name = materialName,
                Owner = ownerUsername,
                Color = new Color(1, 0, 1)
            };
            Model modelEntity = new Model()
            {
                Name = "Test Model",
                Owner = ownerUsername,
                Material = materialEntity,
                Shape = _testSphere
            };
            eFMaterialRepository.AddMaterial(materialEntity);
            eFModelRepository.AddModel(modelEntity);

            bool existsModel = eFModelRepository.ExistsModelUsingTheMaterial(materialName, ownerUsername);

            Assert.IsTrue(existsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheMaterial_NoModelUsingMaterialExists_ReturnsFalse()
        { 
            string materialName = "NonexistentMaterial";
            string ownerUsername = "TestUser";

            bool existsModel = eFModelRepository.ExistsModelUsingTheMaterial(materialName, ownerUsername);

            Assert.IsFalse(existsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheSphere_ModelUsingSphereExists_ReturnsTrue()
        {
            string sphereName = "Test Sphere2";
            string ownerUsername = "TestUser";
            Sphere shape = new Sphere()
            {
                Name = sphereName,
                Owner = ownerUsername,
                Radius = 1
            };
            Model model = new Model()
            {
                Name = "Test Model",
                Owner = ownerUsername,
                Material = _testMat,
                Shape = shape,
            };

            eFSphereRepository.AddSphere(shape);
            eFModelRepository.AddModel(model);

            bool existsModel = eFModelRepository.ExistsModelUsingTheSphere(sphereName, ownerUsername);

            Assert.IsTrue(existsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheSphere_NoModelUsingSphereExists_ReturnsFalse()
        {
            string sphereName = "NonexistentSphere";
            string ownerUsername = "TestUser";

            bool existsModel = eFModelRepository.ExistsModelUsingTheSphere(sphereName, ownerUsername);

            Assert.IsFalse(existsModel);
        }

        [TestMethod]
        [ExpectedException(typeof(Controller_ArgumentException))]
        public void AddModel_ExistingModel_Fails()
        {
            string owner = "TestUser";
            ModelDTO model1 = new ModelDTO()
            {
                Name = "Test Model",
                OwnerName = owner,
                Material = _matDto,
                Shape = _sphereDto,
            };
            ModelDTO model2 = new ModelDTO()
            {
                Name = "Test Model",
                OwnerName = owner,
                Material = _matDto,
                Shape = _sphereDto,
            };

            modelManagementController.AddModel(model1);
            modelManagementController.AddModel(model2);
        }

        [TestMethod]
        public void GetModel_ExistingModel_ReturnsModel()
        {
            string name = "Test Model";
            string owner = "TestUser";
            Model actualModel = new Model()
            {
                Name = name,
                Owner = owner,
                Material = _testMat,
                Shape = _testSphere,
            };
            eFModelRepository.AddModel(actualModel);

            Model model = eFModelRepository.GetModel(name, owner);

            Assert.IsNotNull(model);
            Assert.AreEqual(actualModel, model);
        }

        [TestMethod]
        public void RemoveModel_ExistingModel_RemovesModelFromDatabase()
        {

            string name = "Test Model";
            string owner = "TestUser";
            ModelDTO newModel = new ModelDTO()
            {
                Name = name,
                OwnerName = owner,
                Material = MaterialMapper.ConvertToDTO(_testMat),
                Shape = SphereMapper.ConvertToDTO(_testSphere),
            };

            modelManagementController.AddModel(newModel);

            modelManagementController.RemoveModel(name, owner);

            ModelEntity removedModelEntity;
            using (EFContext dbContext = new EFContext())
            {
                removedModelEntity = dbContext.ModelEntities.FirstOrDefault(m => m.Name == name && m.OwnerId == owner);
            }
            Assert.IsNull(removedModelEntity);
        }

        [TestMethod]
        public void GetAvailableMaterials_ValidOwner_ServiceGetsMaterialsFromUser()
        {
            string owner = "TestUser";
            Metallic metal = new Metallic
            {
                Name = "Test Material1",
                Owner = "TestUser",
                Color = new Color(1, 0, 0),
                Roughness = 0.5,
            };
            Metallic metal2 = new Metallic
            {
                Name = "Test Material2",
                Owner = "TestUser",
                Color = new Color(1, 0.6, 0),
                Roughness = 0.1,
            };

            eFMaterialRepository.AddMaterial(metal);
            eFMaterialRepository.AddMaterial(metal2);

            List<MaterialDTO> materials = modelManagementController.GetAvailableMaterials(owner);

            Assert.IsNotNull(materials);
            Assert.AreEqual(3, materials.Count);           
        }

        [TestMethod]
        public void GetAvailableShapes_ValidOwner_ServiceGetsSpheresFromUser()
        {
            string owner = "TestUser";
            Sphere sphere = new Sphere
            {
                Name = "Test Sphere1",
                Owner = "TestUser",
                Radius = 5,
            };
            Sphere sphere2 = new Sphere
            {
                Name = "Test Sphere2",
                Owner = "TestUser",
                Radius = 3,
            };

            eFSphereRepository.AddSphere(sphere);
            eFSphereRepository.AddSphere(sphere2);

            List<SphereDTO> spheres = modelManagementController.GetAvailableShapes(owner);

            Assert.IsNotNull(spheres);
            Assert.AreEqual(3, spheres.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Controller_ObjectHandlingException))]
        public void RemoveModelUsedByScene_Fails()
        {
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
            SceneDTO scene = new SceneDTO
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

            scene.PositionedModels.Add(PositionedModelMapper.ConvertPositionedModelToDTO(positiondeModel));
            sceneController.AddScene(scene);

            modelManagementController.RemoveModel("Test Model", "TestUser");
        }
    }
}
