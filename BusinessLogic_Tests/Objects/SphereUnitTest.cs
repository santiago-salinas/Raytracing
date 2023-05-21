using BusinessLogic;
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
        private SphereRepository _testSphereRepository;

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

            _testSphereRepository = new SphereRepository();
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
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
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
            _testSphereRepository.AddSphere(_testSphere);
            bool added = _testSphereRepository.ContainsSphere(_testSphere.Name, _testUser.UserName);
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
            _testSphereRepository.AddSphere(_testSphere);
            Sphere getSphere = _testSphereRepository.GetSphere(_testName, testUser.UserName);
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
            _testSphereRepository.AddSphere(_testSphere);
            //act
            _testSphereRepository.RemoveSphere(_testName, testUser.UserName);
            _testSphereRepository.GetSphere(_testName, testUser.UserName);
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
            _testSphereRepository.RemoveSphere(_testName, testUser.UserName);
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
            _testSphereRepository.AddSphere(_testSphere);
            Sphere newSphere = new Sphere()
            {
                Name = _testName,
                Owner = _testUser.UserName,
            };
            //act
            _testSphereRepository.AddSphere(newSphere);
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

            _testSphereRepository.AddSphere(_sphere1);
            _testSphereRepository.AddSphere(_sphere2);
            _testSphereRepository.AddSphere(_sphere3);

            List<Sphere> spheres = _testSphereRepository.GetSpheresFromUser(user1.UserName);

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

            List<Sphere> spheres = _testSphereRepository.GetSpheresFromUser(emptyUser.UserName);

            Assert.AreEqual(0, spheres.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testSphereRepository.Drop();
        }

    }

}
