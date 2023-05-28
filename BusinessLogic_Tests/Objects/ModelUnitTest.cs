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

        private SphereRepository _testSphereRepository = new SphereRepository();

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
            ModelRepository.AddModel(_testModel);
            bool added = ModelRepository.ContainsModel(_testModel.Name, _testUser.UserName);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetModelFromCollection()
        {
            //act
            ModelRepository.AddModel(_testModel);
            Model getModel = ModelRepository.GetModel(_modelName, _testUser);
            //assert
            Assert.ReferenceEquals(_testModel, getModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void RemoveModelFromCollection()
        {
            ModelRepository.AddModel(_testModel);
            //act
            ModelRepository.RemoveModel(_modelName, _testUser);
            ModelRepository.GetModel(_modelName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void CantRemoveModelNotInCollection()
        {
            //act
            ModelRepository.RemoveModel(_modelName, _testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model with the same name already exists in the collection")]
        public void CantAddModelWithNameAlreadyInCollection()
        {
            //arrange
            ModelRepository.AddModel(_testModel);
            Model newModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian,
                Owner = _testUser
            };

            //act
            ModelRepository.AddModel(newModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete sphere used by active model")]
        public void CantDeleteSphereFromCollectionUsedByModel()
        {

            //arrange           
            _testSphere.Owner = _testUser.UserName;

            _testSphereRepository.AddSphere(_testSphere);
            ModelRepository.AddModel(_testModel);
            //act
            _testSphereRepository.RemoveSphere(_sphereName, _testUser.UserName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete lambertian used by active model")]
        public void CantDeleteLambertianFromCollectionUsedByModel()
        {
            //arrange
            LambertianRepository.AddLambertian(_testLambertian);
            _testLambertian.Owner = _testUser;
            ModelRepository.AddModel(_testModel);
            //act
            LambertianRepository.RemoveLambertian(_lambertianName, _testUser);
        }

        [TestMethod]
        public void DeleteSphereAndLambertianAfterDeletingModel()
        {
            //arrange                                    
            _testSphere.Owner = _testUser.UserName;
            _testLambertian.Owner = _testUser;
            _testSphereRepository.AddSphere(_testSphere);
            LambertianRepository.AddLambertian(_testLambertian);
            ModelRepository.AddModel(_testModel);
            ModelRepository.RemoveModel(_modelName, _testUser);

            //act
            _testSphereRepository.RemoveSphere(_sphereName, _testUser.UserName);
            LambertianRepository.RemoveLambertian(_lambertianName, _testUser);
            //assert
            bool sphereDeleted = !_testSphereRepository.ContainsSphere(_sphereName, _testUser.UserName);
            bool lambertianDeleted = !LambertianRepository.ContainsLambertian(_lambertianName, _testUser);
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

            ModelRepository.AddModel(model1);
            ModelRepository.AddModel(model2);
            ModelRepository.AddModel(model3);

            List<Model> models = ModelRepository.GetModelsFromUser(user1.UserName);

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

            List<Model> models = ModelRepository.GetModelsFromUser(emptyUser.UserName);

            Assert.AreEqual(0, models.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            _testSphereRepository.Drop();
            LambertianRepository.Drop();
            ModelRepository.Drop();

        }
    }
}
