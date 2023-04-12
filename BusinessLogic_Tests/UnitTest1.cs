using BusinessLogic;
using BusinessLogic_Tests.BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereTests
    {
        private Sphere testSphere;

        private float testRadius = 5;
        private float testNegativeRadius = -5;
        private string testName = "Ball";
        private string testNullName = "";

        [TestInitialize]
        public void Initialize()
        {
            testSphere = new Sphere()
            {
                Radius = testRadius,
                Name = testName
            };
        }

        [TestMethod]
        public void SphereCreatedSuccesfullyTest()
        {
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
            SphereCollection sphereCollection = new SphereCollection();
            //act
            bool state = sphereCollection.AddSphere(testName, testRadius);
            //assert
            Assert.IsTrue(state);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            SphereCollection sphereCollection = new SphereCollection();
            //act
            bool state = sphereCollection.AddSphere(testName, testRadius);
            //assert
            Sphere getSphere = sphereCollection.GetSphere(testName);
            Assert.IsTrue(state);
            Assert.AreEqual(testSphere, getSphere);
        }
    }

}
