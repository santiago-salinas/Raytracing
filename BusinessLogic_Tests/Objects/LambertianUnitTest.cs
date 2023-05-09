using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
        private User testUser;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Wood";
            testColor = new Color(1, 1, 1);

            differentTestColor = new Color((float)125 / 255, 0, (float)230 / 255);

            testNullName = string.Empty;

            testUser = new User()
            {
                UserName = "Username"
            };

            testLambertian = new Lambertian()
            {
                Name = testName,
                Color = testColor,
                Owner = testUser,
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
        [ExpectedException(typeof(ArgumentException), "Values must be between 0 and 255")]
        public void ValuesForVectorMustBeBetweenBounds()
        {
          outOfBoundsColor = new Color((float)-1 / 255, 0, (float)230 / 255);
          testLambertian.Color = outOfBoundsColor;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values must be natural numbers")]
        public void ValuesForColorAreNaturalNumbers()
        {
            //arrange
            testColor = new Color(2.22, 1.55, 51.5);
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
            //arrange

            //act
            Lambertians.AddLambertian(testLambertian);
            bool added = Lambertians.ContainsLambertian(testLambertian.Name, testLambertian.Owner);
            //assert
            Assert.IsTrue(added);

        }

        [TestMethod]
        public void GetLambertianFromCollection()
        {
            //arrange
            //act
            Lambertians.AddLambertian(testLambertian);
            Lambertian getLambertian = Lambertians.GetLambertian(testName, testUser);
            //assert
            Assert.ReferenceEquals(testLambertian, getLambertian);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void RemoveLambertianFromCollection()
        {
            //arrange
            Lambertians.AddLambertian(testLambertian);
            //act
            Lambertians.RemoveLambertian(testName, testUser);
            Lambertians.GetLambertian(testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void CantRemoveLambertianNotInCollection()
        {
            //act
            Lambertians.RemoveLambertian(testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian with the same name already exists in the collection")]
        public void CantAddLambertianWithNameAlreadyInCollection()
        {
            //arrange
            Lambertians.AddLambertian(testLambertian);
            Lambertian newLambertian = new Lambertian();
            newLambertian.Name = testName;
            newLambertian.Color = differentTestColor;
            newLambertian.Owner = testUser;

            //act
            Lambertians.AddLambertian(newLambertian);
        }

        [TestMethod]
        public void GetLambertiansFromUser_ShouldReturnLambertiansOwnedByUser()
        {
            User user1 = new User()
            {
                UserName = "User1",
                Password = "Password1"
            };
            User user2 = new User()
            {
                UserName = "User2",
                Password = "Password1"
            };

            Lambertian lambertian1 = new Lambertian()
            {
                Name = "scene1",
                Owner = user1,
            };
            Lambertian lambertian2 = new Lambertian()
            {
                Name = "scene2",
                Owner = user1,
            };
            Lambertian lambertian3 = new Lambertian()
            {
                Name = "scene3",
                Owner = user2,
            };

            Lambertians.AddLambertian(lambertian1);
            Lambertians.AddLambertian(lambertian2);
            Lambertians.AddLambertian(lambertian3);

            List<Lambertian> lambertians = Lambertians.GetLambertiansFromUser(user1);

            Assert.AreEqual(2, lambertians.Count);
            Assert.IsTrue(lambertians.Contains(lambertian1));
            Assert.IsTrue(lambertians.Contains(lambertian2));
        }

        [TestMethod]
        public void GetLambertiansFromUser_ShouldReturnEmptyListIfNoLambertiansOwnedByUser()
        {

            //Arrange
            User emptyUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1"
            };

            List<Lambertian> lambertians = Lambertians.GetLambertiansFromUser(emptyUser);

            Assert.AreEqual(0, lambertians.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            Lambertians.Drop();
        }
    }
}
