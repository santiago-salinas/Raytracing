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

        [TestInitialize] 
        public void Initialize() {
            testSphere = new Sphere()
            {
                Radius = testRadius,
            };
        }

        [TestMethod]
        public void SphereCreatedSuccesfullyTest()
        {
            Assert.IsNotNull(testSphere);
        }
    }
    
}
