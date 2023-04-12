using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SphereTests
    {
        private Sphere testSphere;
        private float testRadius = -5;

        [TestInitialize] 
        public void Initialize() {
            
        }

        [TestMethod]
        public void SphereCreatedSuccesfullyTest()
        {
            testSphere = new Sphere()
            {
                Radius = testRadius,
            };
            Assert.IsNotNull(testSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Radius must be a value over zero >0")]
        public void RadiusIsOverZeroTest()
        {
            testSphere = new Sphere()
            {
                Radius = testRadius,
            };
        }
    }
    
}
