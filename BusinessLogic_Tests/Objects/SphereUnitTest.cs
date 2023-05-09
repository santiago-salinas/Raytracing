using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereUnitTest
    {
        private Sphere testSphere;
        private float testRadius;
        private float testNegativeRadius;        
        private string testName;
        private string testNullName;
        public User testUser;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Ball";
            testRadius = 5;            
            testNullName = string.Empty;
            testNegativeRadius = -5;

            testSphere = new Sphere()
            {
                Radius = testRadius,
                Name = testName
            };
            testUser = new User()
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
            testRadius = 5;
            testName = "Ball";
            testUser = new User()
            {
                UserName= "User1",
                Password = "Password1"
            };
            //act
            testSphere = new Sphere()
            {
                Radius = testRadius,
                Name = testName,
                Owner = testUser,
            };
            // Assert
            Assert.AreEqual(testName, testSphere.Name);
            Assert.AreEqual(testRadius, testSphere.Radius);
            Assert.AreEqual(testUser, testSphere.Owner);
        }

        [TestMethod]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            testRadius = 5;
            testName = "Ball";
            testUser = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };

            // Act
            Sphere sphere = new Sphere(testName, testRadius, testUser);

            // Assert
            Assert.AreEqual(testName, sphere.Name);
            Assert.AreEqual(testRadius, sphere.Radius);
            Assert.AreEqual(testUser, sphere.Owner);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Radius must be a value over zero >0")]
        public void RadiusIsOverZeroTest()
        {
            testSphere.Radius = testNegativeRadius;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            testNullName = string.Empty;
            //act
            testSphere.Name = testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + testName;
            //act
            testSphere.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testSphere.Name, testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = testName + " ";
            //act
            testSphere.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(testSphere.Name, testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testName + " ";
            //act
            testSphere.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testSphere.Name, testName);
        }

        [TestMethod]
        public void AddSphereToCollection()
        {
            //arrange
            testSphere.Owner = testUser;
            //act
            Spheres.AddSphere(testSphere);
            bool added = Spheres.ContainsSphere(testSphere.Name, testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testSphere.Owner = testUser;
            //act
            Spheres.AddSphere(testSphere);
            Sphere getSphere = Spheres.GetSphere(testName, testUser);
            //assert
            Assert.ReferenceEquals(testSphere, getSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void RemoveSphereFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testSphere.Owner = testUser;
            //arrange
            Spheres.AddSphere(testSphere);
            //act
            Spheres.RemoveSphere(testName, testUser);
            Spheres.GetSphere(testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void CantRemoveSphereNotInCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testSphere.Owner = testUser;
            //act   
            Spheres.RemoveSphere(testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere with the same name already exists in the collection")]
        public void CantAddSphereWithNameAlreadyInCollection()
        {
            //arrange
            testUser = new User()
            {
                UserName = "TestUsername"
            };
            testSphere = new Sphere()
            {
                Name = testName,
                Owner = testUser
            };
            Spheres.AddSphere(testSphere);
            Sphere newSphere = new Sphere()
            {
                Name = testName,
                Owner = testUser,
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
                Password= "Password1"
            };
            User user2 = new User()
            {
                UserName = "User2",
                Password = "Password1"
            };

            Sphere _sphere1 = new Sphere("sphere1",1, user1);
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
