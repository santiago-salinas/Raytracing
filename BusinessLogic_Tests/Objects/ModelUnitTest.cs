using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class ModelUnitTest
    {
        private Model _testModel;
        private string _modelName;
        private string _testNullName;

        private Sphere _testSphere;
        private string _sphereName;
        private float _radius;

        private Lambertian _testLambertian;
        private string _lambertianName;
        private Color _color;

        private User _testUser;

        [TestInitialize]
        public void Initialize()
        {
            _modelName = "Wooden ball";
            _testNullName = string.Empty;

            _sphereName = "Small sized sphere";
            _radius = 5;
            _lambertianName = "Oak color";
            _color = new Color((float)133 / 255, (float)94 / 255, (float)66 / 255);

            _testSphere = new Sphere()
            {
                Name = _sphereName,
                Radius = _radius,
            };
            _testLambertian = new Lambertian()
            {
                Name = _lambertianName,
                Color = _color,
            };

            _testUser = new User()
            {
                UserName = "Username1",

            };

            _testModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian,
                Owner = _testUser
            };
        }

        [TestMethod]
        public void ModelCreatedSuccesfullyTest()
        {
            //arrange            
            _modelName = "Wooden ball";
            //act
            _testModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian
            };
            //Assert
            Assert.IsNotNull(_testModel);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            _testNullName = string.Empty;
            //act
            _testModel.Name = _testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + _modelName;
            //act
            _testModel.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(_testModel.Name, _modelName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = _modelName + " ";
            //act
            _testModel.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(_testModel.Name, _modelName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + _modelName + " ";
            //act
            _testModel.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(_testModel.Name, _modelName);
        }

        [TestMethod]
        public void AddModelToCollection()
        {
            //act
            Models.AddModel(_testModel);
            bool added = Models.ContainsModel(_testModel.Name, _testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetModelFromCollection()
        {
            //act
            Models.AddModel(_testModel);
            Model getModel = Models.GetModel(_modelName, _testUser);
            //assert
            Assert.ReferenceEquals(_testModel, getModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void RemoveModelFromCollection()
        {
            Models.AddModel(_testModel);
            //act
            Models.RemoveModel(_modelName, _testUser);
            Models.GetModel(_modelName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void CantRemoveModelNotInCollection()
        {
            //act
            Models.RemoveModel(_modelName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model with the same name already exists in the collection")]
        public void CantAddModelWithNameAlreadyInCollection()
        {
            //arrange
            Models.AddModel(_testModel);
            Model newModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian,
                Owner = _testUser
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
            _testSphere.Owner = testUser;

            Spheres.AddSphere(_testSphere);
            Models.AddModel(_testModel);
            //act
            Spheres.RemoveSphere(_sphereName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete lambertian used by active model")]
        public void CantDeleteLambertianFromCollectionUsedByModel()
        {
            //arrange
            Lambertians.AddLambertian(_testLambertian);
            _testLambertian.Owner = _testUser;
            Models.AddModel(_testModel);
            //act
            Lambertians.RemoveLambertian(_lambertianName, _testUser);
        }

        [TestMethod]
        public void DeleteSphereAndLambertianAfterDeletingModel()
        {
            //arrange                                    
            _testSphere.Owner = _testUser;
            _testLambertian.Owner = _testUser;
            Spheres.AddSphere(_testSphere);
            Lambertians.AddLambertian(_testLambertian);
            Models.AddModel(_testModel);
            Models.RemoveModel(_modelName, _testUser);

            //act
            Spheres.RemoveSphere(_sphereName, _testUser);
            Lambertians.RemoveLambertian(_lambertianName, _testUser);
            //assert
            bool sphereDeleted = !Spheres.ContainsSphere(_sphereName, _testUser);
            bool lambertianDeleted = !Lambertians.ContainsLambertian(_lambertianName, _testUser);
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
