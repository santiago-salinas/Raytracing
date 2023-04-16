using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using BusinessLogic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class LambertianUnitTest
    {
        private Lambertian testLambertian;
        //private LambertianCollection testLambertianCollection;
        private Vector testColor;
        private Vector outOfBoundsVector;
        private Vector differentTestColor;
        private string testName;
        private string testNullName;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Wood";
            testColor = new Vector() {
                FstValue = 255,
                SndValue = 255,
                ThrdValue = 255,
            };
            
            differentTestColor = new Vector()
            {
                FstValue = 125,
                SndValue = 0,
                ThrdValue = 230,
            };
            
            outOfBoundsVector = new Vector()
            {
                FstValue = -1,
                SndValue = 0,
                ThrdValue = 230,
            };
            
            testNullName = string.Empty;

            testLambertian = new Lambertian()
            {
                Name = testName,
                Color = testColor
            };
            //testLambertianCollection = new LambertianCollection();
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
            testLambertian.Color = outOfBoundsVector;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values must be natural numbers")]
        public void ValuesForColorAreNaturalNumbers()
        {
            //arrange
            testColor = new Vector
            {
                FstValue = 2.22,
                SndValue = 1.55,
                ThrdValue = 51.5
            };
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
