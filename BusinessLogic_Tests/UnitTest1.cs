using BusinessLogic;
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
        [ExpectedException(typeof(BusinessLogicException), "Name cant have space padding")]
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
        [ExpectedException(typeof(BusinessLogicException), "Name cant have space padding")]
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
        [ExpectedException(typeof(BusinessLogicException), "Name cant have space padding")]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testName + " ";
            //act
            testSphere.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testSphere.Name, testName);
        }
    }

}
