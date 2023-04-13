﻿using BusinessLogic;
using BusinessLogic_Tests.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereTests
    {
        private Sphere testSphere;
        private SphereCollection testSphereCollection;
        private float testRadius;
        private float testNegativeRadius;
        private float differentTestRadius;
        private string testName;
        private string testNullName;
        

        [TestInitialize]
        public void Initialize()
        {
            testName = "Ball";
            testRadius = 5;
            differentTestRadius = 10;
            testNullName = string.Empty;
            testNegativeRadius = -5;

            testSphere = new Sphere()
            {
                Radius = testRadius,
                Name = testName
            };
            testSphereCollection = new SphereCollection();
        }

        [TestMethod]
        public void SphereCreatedSuccesfullyTest()
        {
            //arrange
            testRadius = 5;
            testName = "Ball";
            //act
            testSphere = new Sphere()
            {
                Radius = testRadius,
                Name = testName
            };
            //Assert
            Assert.IsNotNull(testSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Radius must be a value over zero >0")]
        public void RadiusIsOverZeroTest()
        {
            testSphere.Radius = testNegativeRadius;
        }

        [TestMethod]
        public void AddSphereToCollection()
        {
            //act
            bool state = testSphereCollection.AddSphere(testSphere);
            //assert
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            testSphereCollection = new SphereCollection();
            //act
            testSphereCollection.AddSphere(testSphere);
            Sphere getSphere = testSphereCollection.GetSphere(testName);
            //assert
            Assert.AreEqual(testSphere, getSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void RemoveSphereFromCollection()
        {
            //arrange
            testSphereCollection = new SphereCollection();
            testSphereCollection.AddSphere(testSphere);
            //act
            testSphereCollection.RemoveSphere(testName);
            testSphereCollection.GetSphere(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void CantRemoveSphereNotInCollection()
        {
            //arrange
            testSphereCollection = new SphereCollection();
            //act
            testSphereCollection.RemoveSphere(testName);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere with the same name already exists in the collection")]
        public void CantAddSphereWithNameAlreadyInCollection()
        {
            //arrange
            testSphereCollection = new SphereCollection();
            testSphereCollection.AddSphere(testSphere);
            Sphere newSphere = new Sphere();
            newSphere.Name = testName;
            newSphere.Radius = differentTestRadius;

            //act
            testSphereCollection.AddSphere(newSphere);    
        }

        
    }

    [TestClass]
    public class UserObjectTests
    {
        private UserObject testUserObject;
        private string testName;
        private string testNullName;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Ball";
            testNullName = string.Empty;

            testUserObject = new UniTestClassForUserObject()
            {
                Name = testName
            };
        }

        [TestMethod]
        public void UserObjectCreatedSuccesfullyTest()
        {
            //arrange
            testName = "Ball";
            //act
            testUserObject = new UniTestClassForUserObject()
            {
                Name = testName
            };
            //Assert
            Assert.IsNotNull(testUserObject);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            testNullName = string.Empty;
            //act
            testUserObject.Name = testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + testName;
            //act
            testUserObject.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testUserObject.Name, testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = testName + " ";
            //act
            testUserObject.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(testUserObject.Name, testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testName + " ";
            //act
            testUserObject.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testUserObject.Name, testName);
        }
    }

    [TestClass]
    public class UserObjectsCollectionTests
    {
        private UserObjectsCollection testCollection;
        private UserObject testUserObject;
        private string testName;


        [TestInitialize]
        public void Initialize()
        {
            testName = "TestObject";

            testUserObject = new UniTestClassForUserObject()
            {
                Name = testName
            };
            testCollection = new UserObjectsCollection();
        }

        [TestMethod]
        public void UserObjectsCollectionsCreatedSuccesfullyTest()
        {
            //Assert
            Assert.IsNotNull(testCollection);
        }

        [TestMethod]
        public void AddUserObjectToCollection()
        {
            //act
            bool state = testCollection.AddUserObject(testUserObject);
            //assert
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void GetUserObjectFromCollection()
        {
            //arrange
            testCollection = new UserObjectsCollection();
            //act
            testCollection.AddUserObject(testUserObject);
            UserObject getUserObject = testCollection.GetUserObject(testName);
            //assert
            Assert.AreEqual(testUserObject, getUserObject);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "UserObject does not exist in the collection")]
        public void RemoveUserObjectFromCollection()
        {
            //arrange
            testCollection = new UserObjectsCollection();
            testCollection.AddUserObject(testUserObject);
            //act
            testCollection.RemoveUserObject(testName);
            testCollection.GetUserObject(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "UserObject does not exist in the collection")]
        public void CantRemoveUserObjectNotInCollection()
        {
            //arrange
            testCollection = new UserObjectsCollection();
            //act
            testCollection.RemoveUserObject(testName);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "UserObject with the same name already exists in the collection")]
        public void CantAddUserObjectWithNameAlreadyInCollection()
        {
            //arrange
            testCollection = new UserObjectsCollection();
            testCollection.AddUserObject(testUserObject);
            UserObject newUserObject = new UniTestClassForUserObject();
            newUserObject.Name = testName;

            //act
            testCollection.AddUserObject(newUserObject);
        }
    }
 }
