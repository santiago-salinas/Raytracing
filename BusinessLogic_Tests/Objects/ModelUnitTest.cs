using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class ModelUnitTest
    {
        private Model testModel;
        private string modelName;
        private string testNullName;

        private Sphere testSphere;
        private string sphereName;
        private float radius;

        private Lambertian testLambertian;
        private string lambertianName;
        private Color color;

        private User testUser;

        [TestInitialize]
        public void Initialize()
        {
            modelName = "Wooden ball";
            testNullName = string.Empty;

            sphereName = "Small sized sphere";
            radius = 5;
            lambertianName = "Oak color";
            color = new Color((float)133 / 255, (float)94 / 255, (float)66 / 255);

            testSphere = new Sphere()
            {
                Name = sphereName,
                Radius = radius,
            };
            testLambertian = new Lambertian()
            {
                Name = lambertianName,
                Color = color,
            };

            testUser = new User()
            {
                UserName = "Username1",

            };

            testModel = new Model()
            {
                Name = modelName,
                Shape = testSphere,
                Material = testLambertian,
                Owner = testUser
            };
        }

        [TestMethod]
        public void ModelCreatedSuccesfullyTest()
        {
            //arrange            
            modelName = "Wooden ball";
            //act
            testModel = new Model()
            {
                Name = modelName,
                Shape = testSphere,
                Material = testLambertian
            };
            //Assert
            Assert.IsNotNull(testModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            testNullName = string.Empty;
            //act
            testModel.Name = testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + modelName;
            //act
            testModel.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testModel.Name, modelName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = modelName + " ";
            //act
            testModel.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(testModel.Name, modelName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + modelName + " ";
            //act
            testModel.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testModel.Name, modelName);
        }

        [TestMethod]
        public void AddModelToCollection()
        {
            //act
            Models.AddModel(testModel);
            bool added = Models.ContainsModel(testModel.Name, testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetModelFromCollection()
        {
            //act
            Models.AddModel(testModel);
            Model getModel = Models.GetModel(modelName, testUser);
            //assert
            Assert.ReferenceEquals(testModel, getModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void RemoveModelFromCollection()
        {
            Models.AddModel(testModel);
            //act
            Models.RemoveModel(modelName, testUser);
            Models.GetModel(modelName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void CantRemoveModelNotInCollection()
        {
            //act
            Models.RemoveModel(modelName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model with the same name already exists in the collection")]
        public void CantAddModelWithNameAlreadyInCollection()
        {
            //arrange
            Models.AddModel(testModel);
            Model newModel = new Model()
            {
                Name = modelName,
                Shape = testSphere,
                Material = testLambertian,
                Owner = testUser
            };

            //act
            Models.AddModel(newModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete sphere used by active model")]
        public void CantDeleteSphereFromCollectionUsedByModel()
        {

            //arrange
            User testUser = new User();
            testSphere.Owner = testUser;

            Spheres.AddSphere(testSphere);
            Models.AddModel(testModel);
            //act
            Spheres.RemoveSphere(sphereName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete lambertian used by active model")]
        public void CantDeleteLambertianFromCollectionUsedByModel()
        {
            //arrange
            Lambertians.AddLambertian(testLambertian);
            testLambertian.Owner = testUser;
            Models.AddModel(testModel);
            //act
            Lambertians.RemoveLambertian(lambertianName, testUser);
        }

        [TestMethod]
        public void DeleteSphereAndLambertianAfterDeletingModel()
        {
            //arrange                                    
            testSphere.Owner = testUser;
            testLambertian.Owner = testUser;
            Spheres.AddSphere(testSphere);
            Lambertians.AddLambertian(testLambertian);
            Models.AddModel(testModel);
            Models.RemoveModel(modelName, testUser);

            //act
            Spheres.RemoveSphere(sphereName, testUser);
            Lambertians.RemoveLambertian(lambertianName, testUser);
            //assert
            bool sphereDeleted = !Spheres.ContainsSphere(sphereName, testUser);
            bool lambertianDeleted = !Lambertians.ContainsLambertian(lambertianName, testUser);
            Assert.IsTrue(sphereDeleted && lambertianDeleted);
        }

        [TestMethod]
        public void GetModelsFromUser_ShouldReturnModelsOwnedByUser()
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

            Model model1 = new Model()
            {
                Name = "scene1",
                Owner = user1,
            };
            Model model2 = new Model()
            {
                Name = "scene2",
                Owner = user1,
            };
            Model model3 = new Model()
            {
                Name = "scene3",
                Owner = user2,
            };

            Models.AddModel(model1);
            Models.AddModel(model2);
            Models.AddModel(model3);

            List<Model> models = Models.GetModelsFromUser(user1);

            Assert.AreEqual(2, models.Count);
            Assert.IsTrue(models.Contains(model1));
            Assert.IsTrue(models.Contains(model2));
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

            List<Model> models = Models.GetModelsFromUser(emptyUser);

            Assert.AreEqual(0, models.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            Spheres.Drop();
            Lambertians.Drop();
            Models.Drop();

        }
    }
}
