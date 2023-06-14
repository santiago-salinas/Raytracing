using BusinessLogic.DomainObjects;
using Controllers;
using DataTransferObjects.DTOs;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using DataTransferObjects.Mappers;
using BusinessLogic.Exceptions;
using Controllers.Exceptions;

namespace EntityFrameworkTests
{
    [TestClass]
    public class EFSphereRepositoryTests
    {
        private EFSphereRepository _repository;
        private EFUserRepository _userRepository;
        private SphereManagementController _controller;
        private SphereManagementService _service;

        private EFSceneRepository _sceneRepository;
        private EFModelRepository _modelRepository;
        private EFMaterialRepository _materialRepository;
        private ModelManagementService _modelManagementService;
        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new EFSphereRepository();
            _userRepository = new EFUserRepository();
            _modelRepository = new EFModelRepository();
            _materialRepository = new EFMaterialRepository();
            _service = new SphereManagementService(_repository);
            _sceneRepository = new EFSceneRepository();

            _modelManagementService = new ModelManagementService(_modelRepository,_sceneRepository);
            _controller = new SphereManagementController(_service,_modelManagementService);
            User user = new User()
            {
                UserName = "TestUser",
                Password = "Password1",
                RegisterDate = DateTime.Now,
            };
            _userRepository.AddUser(user);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            using (EFContext dbContext = new EFContext())
            {
                UserEntity user = dbContext.UserEntities.FirstOrDefault(m => m.Username == "TestUser");
                List<SphereEntity> spheres = dbContext.SphereEntities
                    .Where(s => s.OwnerId == "TestUser" && s.Name.StartsWith("Test Sphere"))
                    .ToList();

                dbContext.SphereEntities.RemoveRange(spheres);
                dbContext.UserEntities.Remove(user);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void AddSphere_ValidSphere_SphereAdded()
        {
            Sphere sphere = new Sphere
            {
                Name = "Test Sphere",
                Owner = "TestUser",
                Radius = 10,
            };
            SphereDTO sphereDto = SphereMapper.ConvertToDTO(sphere);
            _controller.AddSphere(sphereDto);

            List<Sphere> spheresFromUser = _repository.GetSpheresFromUser("TestUser");

            Assert.AreEqual(1, spheresFromUser.Count);
            Assert.AreEqual("Test Sphere", spheresFromUser[0].Name);
            Assert.AreEqual("TestUser", spheresFromUser[0].Owner);
        }

        [TestMethod]
        public void GetSphere_ExistingSphere_ReturnsSphere()
        {
            Sphere sphere = new Sphere
            {
                Name = "Test Sphere",
                Owner = "TestUser",
                Radius = 10,
            };

            using (EFContext dbContext = new EFContext())
            {
                SphereEntity sphereEntity = SphereEntity.FromDomain(sphere, dbContext);
                dbContext.SphereEntities.Add(sphereEntity);
                dbContext.SaveChanges();
            }

            List<SphereDTO> retrievedSphere = _controller.GetSpheresFromUser("TestUser");

            Assert.AreEqual("Test Sphere", retrievedSphere[0].Name);
            Assert.AreEqual("TestUser", retrievedSphere[0].OwnerName);
            Assert.AreEqual(10, retrievedSphere[0].Radius);
        }

        [TestMethod]
        public void RemoveSphere_ExistingSphere_SphereRemoved()
        {
            Sphere sphere = new Sphere
            {
                Name = "Test Sphere",
                Owner = "TestUser",
                Radius = 10,
            };

            using (EFContext dbContext = new EFContext())
            {
                SphereEntity sphereEntity = SphereEntity.FromDomain(sphere, dbContext);
                dbContext.SphereEntities.Add(sphereEntity);
                dbContext.SaveChanges();
            }

            _controller.RemoveSphere("Test Sphere", "TestUser");

            using (EFContext dbContext = new EFContext())
            {
                List<SphereEntity> spheres = dbContext.SphereEntities.
                    Where(s => s.OwnerId == "TestUser")
                    .ToList();

                Assert.AreEqual(0, spheres.Count);
            }
        }

        [TestMethod]
        public void ContainsSphere_Test()
        {
            Sphere sphere = new Sphere
            {
                Name = "Test Sphere",
                Owner = "TestUser",
                Radius = 10,
            };
            Sphere sphere2 = new Sphere
            {
                Name = "Test Sphere2",
                Owner = "TestUser",
                Radius = 10,
            };

            using (EFContext dbContext = new EFContext())
            {
                SphereEntity sphereEntity = SphereEntity.FromDomain(sphere, dbContext);
                dbContext.SphereEntities.Add(sphereEntity);
                dbContext.SaveChanges();
            }

            bool containsSphere = _repository.ContainsSphere("Test Sphere", "TestUser");
            bool containsSphere2 = _repository.ContainsSphere("Test Sphere2", "TestUser");

            Assert.IsTrue(containsSphere);
            Assert.IsFalse(containsSphere2);
        }

        [TestMethod]
        [ExpectedException(typeof(Controller_ObjectHandlingException),"Cannot remove a sphere that is being used by a model")]

        public void RemoveSphereUsedByModel_Fails()
        {
            SphereDTO sphere = new SphereDTO
            {
                Name = "Test Sphere",
                OwnerName = "TestUser",
                Radius = 10,
            };
            MaterialDTO material = new MaterialDTO
            {
                Color = new ColorDTO(0, 0, 0),
                Name = "Material",
                Owner = "TestUser",
                Type = "lambertian"
            };
            ModelDTO model = new ModelDTO
            {
                OwnerName = "TestUser",
                Name = "Model",
                Shape = sphere,
                Material = material,
            };

            _materialRepository.AddMaterial(MaterialMapper.ConvertToMaterial(material));
            _controller.AddSphere(sphere);
            _modelRepository.AddModel(ModelMapper.ConvertToModel(model));

            _controller.RemoveSphere("Test Sphere", "TestUser");
        }
    }


}
