using BusinessLogic.Exceptions;
using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
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
        private BLCameraDTO _testCamera;

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

        private string _testUser;

        private MemorySceneRepository memorySceneRepository;
        private MemoryModelRepository memoryModelRepository;
        private MemorySphereRepository memorySphereRepository;
        private MemoryMaterialRepository memoryLambertianRepository;

        [TestInitialize]
        public void Initialize()
        {
            memorySceneRepository = new MemorySceneRepository();
            memoryModelRepository = new MemoryModelRepository(memorySceneRepository);
            memorySphereRepository = new MemorySphereRepository(memoryModelRepository);
            memoryLambertianRepository = new MemoryMaterialRepository(memoryModelRepository);


            _testName = "Rolling Balls";
            _testNullName = string.Empty;

            _testScene = new Scene()
            {
                Name = _testName
            };

            _testUser = "Username1";



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
                Material = _testLambertian,
                Owner = _testUser
            };

            _testPosition = new Vector(0, 0, 0);
            _testPositionAlternative = new Vector(1, 1, 1);


            _testPositionedModel = new PositionedModel()
            {
                Model = _testModel,
                Position = _testPosition
            };

            Vector origin = new Vector(4, 2, 8);

            Vector lookAt = new Vector(0, 0.5, -2);
            Vector vectorUp = new Vector(0, 1, 0);

            int samplesPerPixel = 100;
            int depth = 50;

            _testCamera = new BLCameraDTO()
            {
                LookFrom = origin,
                LookAt = lookAt,
                Up = vectorUp,
                FieldOfView = 40,
                ResolutionX = 50,
                ResolutionY = 50,
                SamplesPerPixel = samplesPerPixel,
                MaxDepth = depth,
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
        [ExpectedException(typeof(BusinessLogicException), "Name cant be null")]
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
            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);
            Assert.IsFalse(isContainedByScene);

            //act
            _testScene.AddPositionedModel(_testPositionedModel);

            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);
            Assert.IsTrue(isContainedByScene);
        }



        [TestMethod]
        public void RemovePositionedModelFromScene()
        {
            //arrange
            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);
            Assert.IsFalse(isContainedByScene);
            _testScene.AddPositionedModel(_testPositionedModel);
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);

            Assert.IsTrue(isContainedByScene);
            //act
            _testScene.RemovePositionedModel(_testPositionedModel);
            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);

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

            bool isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);
            Assert.IsTrue(isContainedByScene);

            //act
            _testScene.RemovePositionedModel(_testPositionedModel);

            //assert
            isContainedByScene = _testScene.ContainsPositionedModel(_testPositionedModel.Model.Name, _testPositionedModel.Position);

            Assert.IsFalse(isContainedByScene);
        }

        [TestMethod]
        public void SetCreationDateWhenCreatingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now;

            //act
            _testScene = new Scene();

            //assert
            Assert.AreEqual(_testScene.CreationDate, DateTimeProvider.Now);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenAddingPositionedModel()
        {
            //arrange

            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene();

            //act            
            DateTime previousDate = _testScene.LastModificationDate;
            DateTimeProvider.Reset();
            _testScene.AddPositionedModel(_testPositionedModel);
            DateTime newDate = _testScene.LastModificationDate;
            bool lastModificationIsLater = newDate > previousDate;
            //assert
            Assert.AreEqual(newDate, DateTimeProvider.Now);
            Assert.IsTrue(lastModificationIsLater);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenRemovingPositionedModel()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene();
            _testScene.AddPositionedModel(_testPositionedModel);
            //act
            DateTime previousDate = DateTimeProvider.Now;
            DateTimeProvider.Reset();
            _testScene.RemovePositionedModel(_testPositionedModel);
            DateTime newDate = _testScene.LastModificationDate;
            bool lastModificationIsLater = _testScene.LastModificationDate > previousDate;

            //assert
            Assert.AreEqual(newDate, DateTimeProvider.Now);
            Assert.IsTrue(lastModificationIsLater);

        }

        [TestMethod]
        public void LastRenderDateUpdatedAfterRenderingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            _testScene = new Scene();
            _testScene.UpdateLastRenderDate();
            //act
            DateTime previousDate = DateTimeProvider.Now;
            DateTimeProvider.Reset();
            _testScene.UpdateLastRenderDate();
            DateTime newDate = _testScene.LastRenderDate;
            bool lastRenderIsLater = _testScene.LastRenderDate > previousDate;

            //assert
            Assert.AreEqual(newDate, DateTimeProvider.Now);
            Assert.IsTrue(lastRenderIsLater);
        }
        public void AddSceneToCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser.UserName;
            _testScene.CameraDTO = _testCamera;
            //act
            memorySceneRepository.AddScene(_testScene);
            bool added = memorySceneRepository.ContainsScene(_testScene.Name, testUser.UserName);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSceneFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser.UserName;
            //act
            memorySceneRepository.AddScene(_testScene);
            Scene getScene = memorySceneRepository.GetScene(_testName, testUser.UserName);
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
            _testScene.Owner = testUser.UserName;
            _testScene.CameraDTO = _testCamera;
            memorySceneRepository.AddScene(_testScene);
            //act
            memorySceneRepository.RemoveScene(_testName, testUser.UserName);
            memorySceneRepository.GetScene(_testName, testUser.UserName);
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
                Owner = user1.UserName,
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user2.UserName,
            };
            memorySceneRepository.AddScene(scene1);
            memorySceneRepository.AddScene(scene2);

            // Act
            Action act = () => memorySceneRepository.RemoveScene("scene1", user2.UserName);

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
                Owner = testUser.UserName
            };
            memorySceneRepository.AddScene(_testScene);

            //act
            Scene newScene = new Scene()
            {
                Name = _testName,
                Owner = testUser.UserName
            };
            memorySceneRepository.AddScene(newScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete model used by active scene")]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            //arrange
            memoryModelRepository.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            memorySceneRepository.AddScene(_testScene);

            //act
            memoryModelRepository.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void DeleteModelAfterDeletingScene()
        {
            User testUser = new User();
            testUser.UserName = "Username";
            _testScene.Owner = testUser.UserName;
            _testScene.CameraDTO = _testCamera;
            memoryModelRepository.AddModel(_testModel);
            _testScene.AddPositionedModel(_testPositionedModel);
            memorySceneRepository.AddScene(_testScene);

            memorySceneRepository.RemoveScene(_testScene.Name, testUser.UserName);
            memoryModelRepository.RemoveModel(_testModel.Name, _testModel.Owner);
        }

        [TestMethod]
        public void ModelIsUsedByScene()
        {

            _testUser = "Username";
            _testScene.Owner = _testUser;
            _testScene.CameraDTO = _testCamera;
            Assert.IsFalse(_testScene.ContainsModel(_testModel));
            _testModel.Owner = _testUser;
            memoryModelRepository.AddModel(_testModel);

            _testScene.AddPositionedModel(_testPositionedModel);

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
                Owner = user1.UserName,
                CameraDTO = _testCamera
            };
            Scene scene2 = new Scene()
            {
                Name = "scene2",
                Owner = user1.UserName,
                CameraDTO = _testCamera
        };
            Scene scene3 = new Scene()
            {
                Name = "scene3",
                Owner = user2.UserName,
                CameraDTO = _testCamera
        };

            memorySceneRepository.AddScene(scene1);
            memorySceneRepository.AddScene(scene2);
            memorySceneRepository.AddScene(scene3);

            List<Scene> scenes = memorySceneRepository.GetScenesFromUser(user1.UserName);

            Assert.AreEqual(2, scenes.Count);
            Assert.IsTrue(scenes.Contains(scene1));
            Assert.IsTrue(scenes.Contains(scene2));
        }

        [TestMethod]
        public void GetScenesFromUser_ShouldReturnEmptyListIfNoScenesOwnedByUser()
        {

            User emptyUser = new User()
            {
                UserName = "TestUser",
                Password = "Password1"
            };

            List<Scene> scenes = memorySceneRepository.GetScenesFromUser(emptyUser.UserName);

            Assert.AreEqual(0, scenes.Count);
        }

        [TestCleanup]
        public void TearDown()
        {
            DateTimeProvider.Reset();
            memorySphereRepository.Drop();
            memoryLambertianRepository.Drop();
            memoryModelRepository.Drop();
            memorySceneRepository.Drop();
            _testScene.DropPositionedModels();
        }
    }
}