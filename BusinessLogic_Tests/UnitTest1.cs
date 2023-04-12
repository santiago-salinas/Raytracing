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
        [ExpectedException(typeof(BusinessLogicException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //act
            testSphere.Name = testNullName;
        }
    }

}
