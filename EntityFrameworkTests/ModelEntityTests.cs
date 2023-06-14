using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using DataAccess.Entities;
using DataAccess.Repositories;
using DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace EntityFrameworkTests
{
    [TestClass]
    public class EFModelRepositoryTests
    {
        private EFModelRepository _repository = new EFModelRepository();
        private EFMaterialRepository _materialRepository = new EFMaterialRepository();
        private EFSphereRepository _sphereRepository = new EFSphereRepository();
        private EFUserRepository _userRepository = new EFUserRepository();
        private Metallic _testMat;
        private MaterialEntity _testMatEntity;
        private Sphere _testSphere;
        private SphereEntity _testSphereEntity;
        private User _testUser;

        [TestInitialize]
        public void TestInitialize()
        {
            
            _testUser = new User()
            {
                UserName = "TestUser",
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
            _userRepository.AddUser(_testUser);
            _materialRepository.AddMaterial(_testMat);
            _sphereRepository.AddSphere(_testSphere);
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
                List<MaterialEntity> materials = dbContext.MaterialEntities
                    .Include(m => m.Metallic)
                    .Where(m => m.OwnerId == user.Username && m.Name.StartsWith("Test Material"))
                    .ToList();
                List<SphereEntity> spheres = dbContext.SphereEntities
                    .Where(m => m.OwnerId == user.Username && m.Name.StartsWith("Test Sphere"))
                    .ToList();
                List<ModelEntity> models = dbContext.ModelEntities
                    .Where(m => m.OwnerId == user.Username && m.Name.StartsWith("Test Model"))
                    .ToList();
                dbContext.ModelEntities.RemoveRange(models);
                dbContext.SphereEntities.RemoveRange(spheres);
                dbContext.MetallicEntities.RemoveRange(materials.Select(m => m.Metallic));
                dbContext.MaterialEntities.RemoveRange(materials);
                dbContext.UserEntities.Remove(user);
                dbContext.SaveChanges();
            }
        }

        [TestMethod]
        public void GetModelsFromUser_ExistingUser_ReturnsModels()
        {
            // Arrange
            string owner = "TestUser";
            Model model1 = new Model()
            {
                Name = "Test Model1",
                Owner = owner,
                Material = _testMat,
                Shape = _testSphere,
            };
            Model model2 = new Model()
            {
                Name = "Test Model2",
                Owner = owner,
                Material = _testMat,
                Shape = _testSphere,
            };
            _repository.AddModel(model1);
            _repository.AddModel(model2);


            List<Model> models = _repository.GetModelsFromUser(owner);

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
            bool containsModel = _repository.ContainsModel(name, owner);

            Assert.IsTrue(containsModel);
        }

        [TestMethod]
        public void ContainsModel_NonexistentModel_ReturnsFalse()
        {

            string name = "NonexistentModel";
            string owner = "TestUser";

            bool containsModel = _repository.ContainsModel(name, owner);

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
            _materialRepository.AddMaterial(materialEntity);
            _repository.AddModel(modelEntity);

            bool existsModel = _repository.ExistsModelUsingTheMaterial(materialName, ownerUsername);

            Assert.IsTrue(existsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheMaterial_NoModelUsingMaterialExists_ReturnsFalse()
        { 
            string materialName = "NonexistentMaterial";
            string ownerUsername = "TestUser";

            bool existsModel = _repository.ExistsModelUsingTheMaterial(materialName, ownerUsername);

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

            _sphereRepository.AddSphere(shape);
            _repository.AddModel(model);

            bool existsModel = _repository.ExistsModelUsingTheSphere(sphereName, ownerUsername);

            Assert.IsTrue(existsModel);
        }

        [TestMethod]
        public void ExistsModelUsingTheSphere_NoModelUsingSphereExists_ReturnsFalse()
        {
            string sphereName = "NonexistentSphere";
            string ownerUsername = "TestUser";

            bool existsModel = _repository.ExistsModelUsingTheSphere(sphereName, ownerUsername);

            Assert.IsFalse(existsModel);
        }

        [TestMethod]
        public void AddModel_ValidModel_AddsModelToDatabase()
        {
            string owner = "TestUser";
            Model newModel = new Model()
            {
                Name = "Test Model",
                Owner = owner,
                Material = _testMat,
                Shape = _testSphere,
            };

            _repository.AddModel(newModel);
            ModelEntity addedModelEntity;
            using (EFContext dbContext = new EFContext())
            {
                addedModelEntity = dbContext.ModelEntities.FirstOrDefault(m => m.Name == "Test Model" && m.OwnerId == owner);
            }
            Assert.IsNotNull(addedModelEntity);
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
            _repository.AddModel(actualModel);

            Model model = _repository.GetModel(name, owner);

            Assert.IsNotNull(model);
            Assert.AreEqual(actualModel, model);
        }

        [TestMethod]
        public void RemoveModel_ExistingModel_RemovesModelFromDatabase()
        {

            string name = "Test Model";
            string owner = "TestUser";
            Model newModel = new Model()
            {
                Name = name,
                Owner = owner,
                Material = _testMat,
                Shape = _testSphere,
                Preview = null
            };

            _repository.AddModel(newModel);

            _repository.RemoveModel(name, owner);

            ModelEntity removedModelEntity;
            using (EFContext dbContext = new EFContext())
            {
                removedModelEntity = dbContext.ModelEntities.FirstOrDefault(m => m.Name == name && m.OwnerId == owner);
            }
            Assert.IsNull(removedModelEntity);
        }
    }

}
