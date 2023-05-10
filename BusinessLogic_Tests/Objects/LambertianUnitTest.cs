using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class LambertianUnitTest
    {
        private Lambertian _testLambertian;
        private Color _testColor;
        private Color _outOfBoundsColor;
        private Color _differentTestColor;
        private string _testName;
        private string _testNullName;
        private User _testUser;


        [TestInitialize]
        public void Initialize()
        {
            _testName = "Wood";
            _testColor = new Color(1, 1, 1);

            _differentTestColor = new Color((float)125 / 255, 0, (float)230 / 255);

            _testNullName = string.Empty;

            _testUser = new User()
            {
                UserName = "Username"
            };

            _testLambertian = new Lambertian()
            {
                Name = _testName,
                Color = _testColor,
                Owner = _testUser,
            };
        }

        [TestMethod]
        public void LambertianCreatedSuccesfullyTest()
        {
            //arrange           
            _testName = "Wood";
            //act
            _testLambertian = new Lambertian()
            {
                Name = _testName,
                Color = _testColor
            };
            //Assert
            Assert.IsNotNull(_testLambertian);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values must be between 0 and 255")]
        public void ValuesForVectorMustBeBetweenBounds()
        {
            _outOfBoundsColor = new Color((float)-1 / 255, 0, (float)230 / 255);
            _testLambertian.Color = _outOfBoundsColor;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Values must be natural numbers")]
        public void ValuesForColorAreNaturalNumbers()
        {
            //arrange
            _testColor = new Color(2.22, 1.55, 51.5);
            //assert
            _testLambertian.Color = _testColor;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //act
            _testLambertian.Name = _testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + _testName;
            //act
            _testLambertian.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(_testLambertian.Name, _testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = _testName + " ";
            //act
            _testLambertian.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(_testLambertian.Name, _testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + _testName + " ";
            //act
            _testLambertian.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(_testLambertian.Name, _testName);
        }

        [TestMethod]
        public void AddLambertianToCollection()
        {
            //arrange

            //act
            Lambertians.AddLambertian(_testLambertian);
            bool added = Lambertians.ContainsLambertian(_testLambertian.Name, _testLambertian.Owner);
            //assert
            Assert.IsTrue(added);

        }

        [TestMethod]
        public void GetLambertianFromCollection()
        {
            //arrange
            //act
            Lambertians.AddLambertian(_testLambertian);
            Lambertian getLambertian = Lambertians.GetLambertian(_testName, _testUser);
            //assert
            Assert.ReferenceEquals(_testLambertian, getLambertian);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void RemoveLambertianFromCollection()
        {
            //arrange
            Lambertians.AddLambertian(_testLambertian);
            //act
            Lambertians.RemoveLambertian(_testName, _testUser);
            Lambertians.GetLambertian(_testName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian does not exist in the collection")]
        public void CantRemoveLambertianNotInCollection()
        {
            //act
            Lambertians.RemoveLambertian(_testName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Lambertian with the same name already exists in the collection")]
        public void CantAddLambertianWithNameAlreadyInCollection()
        {
            //arrange
            Lambertians.AddLambertian(_testLambertian);
            Lambertian newLambertian = new Lambertian();
            newLambertian.Name = _testName;
            newLambertian.Color = _differentTestColor;
            newLambertian.Owner = _testUser;

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
