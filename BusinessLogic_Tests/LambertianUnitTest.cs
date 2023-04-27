using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class LambertianUnitTest
    {
        private Lambertian testLambertian;
        private Color testColor;
        private Color outOfBoundsColor;
        private Color differentTestColor;
        private string testName;
        private string testNullName;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Wood";
            testColor = new Color(255,255,255);
            
            differentTestColor = new Color(125,0,230);
            
            outOfBoundsColor = new Color(-1,0,230);
            
            testNullName = string.Empty;

            testLambertian = new Lambertian()
            {
                Name = testName,
                Color = testColor
            };
        }

        [TestMethod]
        public void LambertianCreatedSuccesfullyTest()
        {
            //arrange           
            testName = "Wood";
            //act
            testLambertian = new Lambertian()
            {
                Name = testName,
                Color = testColor
            };
            //Assert
            Assert.IsNotNull(testLambertian);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),"Values must be between 0 and 255")]
        public void ValuesForVectorMustBeBetweenBounds()
        {
            testLambertian.Color = outOfBoundsColor;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values must be natural numbers")]
        public void ValuesForColorAreNaturalNumbers()
        {
            //arrange
            testColor = new Color(2.22,1.55,51.5);
            //assert
            testLambertian.Color = testColor;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //act
            testLambertian.Name = testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + testName;
            //act
            testLambertian.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testLambertian.Name, testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = testName + " ";
            //act
            testLambertian.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(testLambertian.Name, testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testName + " ";
            //act
            testLambertian.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testLambertian.Name, testName);
        }

        [TestMethod]
        public void AddLambertianToCollection()
        {
            //act
            LambertianCollection.AddLambertian(testLambertian);
            bool added = LambertianCollection.ContainsLambertian(testLambertian.Name);
            //assert
            Assert.IsTrue(added);

        }

        [TestMethod]
        public void GetLambertianFromCollection()
        {
            //arrange
            //act
            LambertianCollection.AddLambertian(testLambertian);
            Lambertian getLambertian = LambertianCollection.GetLambertian(testName);
            //assert
            Assert.ReferenceEquals(testLambertian, getLambertian);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void RemoveLambertianFromCollection()
        {
            //arrange
            LambertianCollection.AddLambertian(testLambertian);
            //act
            LambertianCollection.RemoveLambertian(testName);
            LambertianCollection.GetLambertian(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void CantRemoveLambertianNotInCollection()
        {
            //act
            LambertianCollection.RemoveLambertian(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian with the same name already exists in the collection")]
        public void CantAddLambertianWithNameAlreadyInCollection()
        {
            //arrange
            LambertianCollection.AddLambertian(testLambertian);
            Lambertian newLambertian = new Lambertian();
            newLambertian.Name = testName;
            newLambertian.Color = differentTestColor;

            //act
            LambertianCollection.AddLambertian(newLambertian);
        }

        [TestCleanup]
        public void TearDown()
        {
            LambertianCollection.DropCollection();
        }
    }
}
