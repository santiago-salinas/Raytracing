﻿using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereUnitTest
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
            //act
            testSphereCollection.AddSphere(testSphere);
            bool added = testSphereCollection.ContainsSphere(testSphere.Name);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //act
            testSphereCollection.AddSphere(testSphere);
            Sphere getSphere = testSphereCollection.GetSphere(testName);
            //assert
            Assert.ReferenceEquals(testSphere, getSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void RemoveSphereFromCollection()
        {
            //arrange
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
            //act
            testSphereCollection.RemoveSphere(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere with the same name already exists in the collection")]
        public void CantAddSphereWithNameAlreadyInCollection()
        {
            //arrange
            testSphereCollection.AddSphere(testSphere);
            Sphere newSphere = new Sphere();
            newSphere.Name = testName;
            newSphere.Radius = differentTestRadius;

            //act
            testSphereCollection.AddSphere(newSphere);    
        }

        [TestCleanup]
        public void TearDown()
        {
            testSphereCollection.DropCollection();
        }

    }

}
