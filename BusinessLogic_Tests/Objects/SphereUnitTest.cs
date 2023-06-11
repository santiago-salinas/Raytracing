using BusinessLogic;
using BusinessLogic.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereUnitTest
    {
        private Sphere _testSphere;
        private float _testRadius;
        private float _testNegativeRadius;
        private string _testName;
        private string _testNullName;
        private User _testUser;
        
        private MemorySphereRepository memorySphereRepository;
        private MemorySceneRepository memorySceneRepository;
        private MemoryModelRepository memoryModelRepository;
        [TestInitialize]
        public void Initialize()
        {
            _testName = "Ball";
            _testRadius = 5;
            _testNullName = string.Empty;
            _testNegativeRadius = -5;

            _testSphere = new Sphere()
            {
                Radius = _testRadius,
                Name = _testName
            };
            _testUser = new User()
            {
                UserName = "Username",
                Password = "Password1",
                RegisterDate = DateTime.Now,
            };

            memorySceneRepository = new MemorySceneRepository();
            memoryModelRepository = new MemoryModelRepository(memorySceneRepository);
            memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
        }

        [TestMethod]
        public void SphereCreatedSuccesfullyTest()
        {
            //arrange
            _testRadius = 5;
            _testName = "Ball";
            _testUser = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };
            //act
            _testSphere = new Sphere()
            {
                Radius = _testRadius,
                Name = _testName,
                Owner = _testUser.UserName,
            };
            // Assert
            Assert.AreEqual(_testName, _testSphere.Name);
            Assert.AreEqual(_testRadius, _testSphere.Radius);
            Assert.AreEqual(_testUser.UserName, _testSphere.Owner);
        }

        [TestMethod]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            _testRadius = 5;
            _testName = "Ball";
            _testUser = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };

            // Act
            Sphere sphere = new Sphere(_testName, _testRadius, _testUser.UserName);

            // Assert
            Assert.AreEqual(_testName, sphere.Name);
            Assert.AreEqual(_testRadius, sphere.Radius);
            Assert.AreEqual(_testUser.UserName, sphere.Owner);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Radius must be a value over zero >0")]
        public void RadiusIsOverZeroTest()
        {
            _testSphere.Radius = _testNegativeRadius;
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            _testNullName = string.Empty;
            //act
            _testSphere.Name = _testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + _testName;
            //act
            _testSphere.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(_testSphere.Name, _testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = _testName + " ";
            //act
            _testSphere.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(_testSphere.Name, _testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + _testName + " ";
            //act
            _testSphere.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(_testSphere.Name, _testName);
        }

        [TestMethod]
        public void AddSphereToCollection()
        {
            //arrange
            _testSphere.Owner = _testUser.UserName;
            //act
            memorySphereRepository.AddSphere(_testSphere);
            bool added = memorySphereRepository.ContainsSphere(_testSphere.Name, _testUser.UserName);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testSphere.Owner = testUser.UserName;
            //act
            memorySphereRepository.AddSphere(_testSphere);
            Sphere getSphere = memorySphereRepository.GetSphere(_testName, testUser.UserName);
            //assert
            Assert.ReferenceEquals(_testSphere, getSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void RemoveSphereFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testSphere.Owner = testUser.UserName;
            //arrange
            memorySphereRepository.AddSphere(_testSphere);
            //act
            memorySphereRepository.RemoveSphere(_testName, testUser.UserName);
            memorySphereRepository.GetSphere(_testName, testUser.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void CantRemoveSphereNotInCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testSphere.Owner = testUser.UserName;
            //act   
            memorySphereRepository.RemoveSphere(_testName, testUser.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere with the same name already exists in the collection")]
        public void CantAddSphereWithNameAlreadyInCollection()
        {
            //arrange
            _testUser = new User()
            {
                UserName = "TestUsername"
            };
            _testSphere = new Sphere()
            {
                Name = _testName,
                Owner = _testUser.UserName
            };
            memorySphereRepository.AddSphere(_testSphere);
            Sphere newSphere = new Sphere()
            {
                Name = _testName,
                Owner = _testUser.UserName,
            };
            //act
            memorySphereRepository.AddSphere(newSphere);
        }

        [TestMethod]
        public void GetSpheresFromUser_ShouldReturnSpheresOwnedByUser()
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

            Sphere _sphere1 = new Sphere("sphere1", 1, user1.UserName);
            Sphere _sphere2 = new Sphere("sphere2", 5, user1.UserName);
            Sphere _sphere3 = new Sphere("sphere3", 9, user2.UserName);

            memorySphereRepository.AddSphere(_sphere1);
            memorySphereRepository.AddSphere(_sphere2);
            memorySphereRepository.AddSphere(_sphere3);

            List<Sphere> spheres = memorySphereRepository.GetSpheresFromUser(user1.UserName);

            Assert.AreEqual(2, spheres.Count);
            Assert.IsTrue(spheres.Contains(_sphere1));
            Assert.IsTrue(spheres.Contains(_sphere2));
        }

        [TestMethod]
        public void GetSpheresFromUser_ShouldReturnEmptyListIfNoSpheresOwnedByUser()
        {

            //Arrange
            User emptyUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1"
            };

            List<Sphere> spheres = memorySphereRepository.GetSpheresFromUser(emptyUser.UserName);

            Assert.AreEqual(0, spheres.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            memorySphereRepository.Drop();
        }

    }

}
