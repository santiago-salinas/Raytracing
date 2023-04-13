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

}
