using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SceneUnitTest
    {
        private Scene _testScene;
        private string _testName;
        private string _testNullName;

        private Model _testModel;
        private string _modelName;

        private Sphere _testSphere;
        private string _sphereName;
        private float _radius;

        private Lambertian _testLambertian;
        private string _lambertianName;
        private Color _color;

        private PositionedModel _testPositionedModel;
        private Vector _testPosition;
        private Vector _testPositionAlternative;

        private User _testUser;


        [TestInitialize]
        public void Initialize()
        {
            _testName = "Rolling Balls";
            _testNullName = string.Empty;

            _testScene = new Scene()
            {
                Name = _testName
            };

            _testUser = new User()
            {
                UserName = "Username1"
            };



            _modelName = "Wooden ball";
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
                Color = _color
            };


            _testModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian
            };

            _testPosition = new Vector(0, 0, 0);
            _testPositionAlternative = new Vector(1, 1, 1);


            _testPositionedModel = new PositionedModel()
            {
                Model = _testModel,
                Position = _testPosition
            };



            DateTimeProvider.Reset();

        }

        [TestMethod]
        public void SceneCreatedSuccesfullyTest()
        {
            _testScene = new Scene()
            {
                Name = _testName
            };
            //assert
            Assert.IsNotNull(_testScene);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            _testNullName = string.Empty;
            //act
            _testScene.Name = _testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + _testName;
            //act
            _testScene.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(_testScene.Name, _testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = _testName + " ";
            //act
            _testScene.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(_testScene.Name, _testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + _testName + " ";
            //act
            _testScene.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(_testScene.Name, _testName);
        }

        [TestMethod]
        public void AddPositionedModelToScene()
        {
            //arrange
            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsFalse(isContainedByScene);

            //act
            _testScene.AddPositionedModel(_testPositionedModel);

            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsTrue(isContainedByScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Duplicated PositionedModel in Scene")]
        public void CantHaveDuplicatedPositionedModelInScene()
        {
            //arrange
            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsFalse(isContainedByScene);
            _testScene.AddPositionedModel(_testPositionedModel);
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsTrue(isContainedByScene);
            //act
            _testScene.AddPositionedModel(_testPositionedModel);
        }

        [TestMethod]
        public void RemovePositionedModelFromScene()
        {
            //arrange
            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsFalse(isContainedByScene);
            _testScene.AddPositionedModel(_testPositionedModel);
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsTrue(isContainedByScene);
            //act
            _testScene.RemovePositionedModel(_testPositionedModel);
            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsFalse(isContainedByScene);
        }

        [TestMethod]
        public void RemovingSameNamePositionedModelsWithDiffPosition()
        {
            //arrange
            PositionedModel testPositionedModelAlternative = new PositionedModel()
            {
                Model = _testModel,
                Position = _testPositionAlternative
            };

            _testScene.AddPositionedModel(_testPositionedModel);
            _testScene.AddPositionedModel(testPositionedModelAlternative);

            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsTrue(isContainedByScene);

            //act
            _testScene.RemovePositionedModel(_testPositionedModel);

            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel);
            Assert.IsFalse(isContainedByScene);
        }

        [TestMethod]
        public void SetCreationDateWhenCreatingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now;

            //act
            _testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
            };

            //assert
            Assert.AreEqual(_testScene.CreationDate, DateTimeProvider.Now);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenAddingPositionedModel()
        {
            //arrange

            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
                LastModificationDate = DateTimeProvider.Now,
            };

            //act
            DateTime previousDate = _testScene.LastModificationDate;
            _testScene.AddPositionedModel(_testPositionedModel);
            bool lastModificationIsLater = _testScene.LastModificationDate > previousDate;

            //assert
            Assert.IsTrue(lastModificationIsLater);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenRemovingPositionedModel()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,


            };
            _testScene.AddPositionedModel(_testPositionedModel);
            _testScene.LastModificationDate = DateTimeProvider.Now;
            //act
            DateTime previousDate = _testScene.LastModificationDate;
            _testScene.RemovePositionedModel(_testPositionedModel);
            bool lastModificationIsLater = _testScene.LastModificationDate > previousDate;

            //assert
            Assert.IsTrue(lastModificationIsLater);
        }

        [TestMethod]
        public void LastRenderDateUpdatedAfterRenderingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
                LastRenderDate = DateTimeProvider.Now,
            };

            //act

            DateTime previousDate = _testScene.LastRenderDate;
            _testScene.UpdateLastRenderDate();
            bool lastRenderIsLater = _testScene.LastRenderDate > previousDate;

            //assert
            Assert.IsTrue(lastRenderIsLater);
        }
        public void AddSceneToCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser;
            //act
            Scenes.AddScene(_testScene);
            bool added = Scenes.ContainsScene(_testScene.Name, testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSceneFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser;
            //act
            Scenes.AddScene(_testScene);
            Scene getScene = Scenes.GetScene(_testName, testUser);
            //assert
            Assert.ReferenceEquals(_testScene, getScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene does not exist in the collection")]
        public void RemoveSceneFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser;
            Scenes.AddScene(_testScene);
            //act
            Scenes.RemoveScene(_testName, testUser);
            Scenes.GetScene(_testName, testUser);
        }


        [TestMethod]
        public void RemoveScene_ThrowsBusinessLogicException_WhenOwnerDoesNotHaveSceneWithGivenName()
        {
            // Arrange
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
            Scene scene1 = new Scene()
            {
                Name = "scene1",
                Owner = user1,
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user2,
            };
            Scenes.AddScene(scene1);
            Scenes.AddScene(scene2);

            // Act
            Action act = () => Scenes.RemoveScene("scene1", user2);

            // Assert
            var exception = Assert.ThrowsException<BusinessLogicException>(act);
            Assert.AreEqual("Owner does not have a scene with that name", exception.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene with the same name already exists in the collection")]
        public void CantAddSceneWithNameAlreadyInCollection()
        {
            //arrange
            User testUser = new User()
            {
                UserName = "Username1"
            };

            _testScene = new Scene()
            {
                Name = _testName,
                Owner = testUser
            };
            Scenes.AddScene(_testScene);

            //act
            Scene newScene = new Scene()
            {
                Name = _testName,
                Owner = testUser
            };
            Scenes.AddScene(newScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete model used by active scene")]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            //arrange

            Models.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            Scenes.AddScene(_testScene);

            //act
            Models.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void DeleteModelAfterDeletingScene()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser;
            Models.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            Scenes.AddScene(_testScene);

            //act
            Scenes.RemoveScene(_testScene.Name, testUser);
            Models.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void ModelIsUsedByScene()
        {

            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser;
            Assert.IsFalse(_testScene.ContainsModel(_testModel));
            Models.AddModel(_testModel);
            //act
            _testScene.AddPositionedModel(_testPositionedModel);
            //assert
            Assert.IsTrue(_testScene.ContainsModel(_testModel));
            _testScene.RemovePositionedModel(_testPositionedModel);
            Assert.IsFalse(_testScene.ContainsModel(_testModel));
        }

        [TestMethod]
        public void GetScenesFromUser_ShouldReturnScenesOwnedByUser()
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

            Scene scene1 = new Scene()
            {
                Name = "scene1",
                Owner = user1,
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user1,
            };
            Scene scene3 = new Scene()
            {
                Name = "scene3",
                Owner = user2,
            };

            Scenes.AddScene(scene1);
            Scenes.AddScene(scene2);
            Scenes.AddScene(scene3);

            List<Scene> scenes = Scenes.GetScenesFromUser(user1);

            Assert.AreEqual(2, scenes.Count);
            Assert.IsTrue(scenes.Contains(scene1));
            Assert.IsTrue(scenes.Contains(scene2));
        }

        [TestMethod]
        public void GetScenesFromUser_ShouldReturnEmptyListIfNoScenesOwnedByUser()
        {

            //Arrange
            User emptyUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1"
            };

            List<Scene> scenes = Scenes.GetScenesFromUser(emptyUser);

            Assert.AreEqual(0, scenes.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            Spheres.Drop();
            Lambertians.Drop();
            Models.Drop();
            Scenes.Drop();
            _testScene.DropPositionedModels();
        }
    }
}