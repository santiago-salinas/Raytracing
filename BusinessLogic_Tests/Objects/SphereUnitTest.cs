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
        public User _testUser;


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
                Owner = _testUser,
            };
            // Assert
            Assert.AreEqual(_testName, _testSphere.Name);
            Assert.AreEqual(_testRadius, _testSphere.Radius);
            Assert.AreEqual(_testUser, _testSphere.Owner);
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
            Sphere sphere = new Sphere(_testName, _testRadius, _testUser);

            // Assert
            Assert.AreEqual(_testName, sphere.Name);
            Assert.AreEqual(_testRadius, sphere.Radius);
            Assert.AreEqual(_testUser, sphere.Owner);
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
            _testSphere.Owner = _testUser;
            //act
            Spheres.AddSphere(_testSphere);
            bool added = Spheres.ContainsSphere(_testSphere.Name, _testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testSphere.Owner = testUser;
            //act
            Spheres.AddSphere(_testSphere);
            Sphere getSphere = Spheres.GetSphere(_testName, testUser);
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
            _testSphere.Owner = testUser;
            //arrange
            Spheres.AddSphere(_testSphere);
            //act
            Spheres.RemoveSphere(_testName, testUser);
            Spheres.GetSphere(_testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void CantRemoveSphereNotInCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testSphere.Owner = testUser;
            //act   
            Spheres.RemoveSphere(_testName, testUser);
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
                Owner = _testUser
            };
            Spheres.AddSphere(_testSphere);
            Sphere newSphere = new Sphere()
            {
                Name = _testName,
                Owner = _testUser,
            };
            //act
            Spheres.AddSphere(newSphere);
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

            Sphere _sphere1 = new Sphere("sphere1", 1, user1);
            Sphere _sphere2 = new Sphere("sphere2", 5, user1);
            Sphere _sphere3 = new Sphere("sphere3", 9, user2);

            Spheres.AddSphere(_sphere1);
            Spheres.AddSphere(_sphere2);
            Spheres.AddSphere(_sphere3);

            List<Sphere> spheres = Spheres.GetSpheresFromUser(user1);

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

            List<Sphere> spheres = Spheres.GetSpheresFromUser(emptyUser);

            Assert.AreEqual(0, spheres.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            Spheres.Drop();
        }

    }

}
