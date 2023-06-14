using BusinessLogic.DomainObjects;
using DataAccess;
using DataAccess.Entities;
using DataAccess.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace EntityFrameworkTests
{
    [TestClass]
    public class EFSphereRepositoryTests
    {
        private EFSphereRepository _repository;
        private EFUserRepository _userRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            _repository = new EFSphereRepository();
            _userRepository = new EFUserRepository();

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

            _repository.AddSphere(sphere);

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

            Sphere retrievedSphere = _repository.GetSphere("Test Sphere", "TestUser");

            Assert.IsNotNull(retrievedSphere);
            Assert.AreEqual("Test Sphere", retrievedSphere.Name);
            Assert.AreEqual("TestUser", retrievedSphere.Owner);
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

            _repository.RemoveSphere("Test Sphere", "TestUser");

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
    }
}
