﻿using BusinessLogic;
using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class SceneUnitTest
    {
        private Scene testScene;
        private string testName;
        private string testNullName;

        private Model testModel;
        private string modelName;

        private Sphere testSphere;
        private string sphereName;
        private float radius;

        private Lambertian testLambertian;
        private string lambertianName;
        private Color color;

        private PositionedModel testPositionedModel;
        private Vector testPosition;
        private Vector testPositionAlternative;


        private Vector defaultLookFromVector;
        private Vector defaultLookAtVector;
        private int defaultFOV;

        


        [TestInitialize]
        public void Initialize()
        {
            testName = "Rolling Balls";
            testNullName = string.Empty;

            defaultLookFromVector = new Vector(0, 2, 0);
            defaultLookAtVector = new Vector(0, 2, 5);
            defaultFOV = 30;

            testScene = new Scene()
            {
                Name = testName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
                FOV = defaultFOV
            };

            modelName = "Wooden ball";
            sphereName = "Small sized sphere";
            radius = 5;
            lambertianName = "Oak color";
            color = new Color((float)133/255, (float)94 / 255, (float)66 / 255);

            testSphere = new Sphere(sphereName, radius);
            testLambertian = new Lambertian(lambertianName, color);


            testModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };

            testPosition = new Vector(0, 0, 0);
            testPositionAlternative = new Vector(1, 1, 1);


            testPositionedModel = new PositionedModel()
            {
                PositionedModelModel = testModel,
                PositionedModelPosition = testPosition
            };

            DateTimeProvider.Reset();

        }

        [TestMethod]
        public void SceneCreatedSuccesfullyTest()
        {
            testScene = new Scene()
            {
                Name = testName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
            };
            //assert
            Assert.IsNotNull(testScene);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name cant be null")]
        public void NameCantBeNullTest()
        {
            //arrange
            testNullName = string.Empty;
            //act
            testScene.Name = testNullName;
        }

        [TestMethod]
        public void NameWithLeftPaddingFail()
        {
            //arrange
            string nameWithLeftPadding = " " + testName;
            //act
            testScene.Name = nameWithLeftPadding;
            //assert
            Assert.AreEqual(testScene.Name, testName);
        }

        [TestMethod]
        public void NameWithRightPaddingFail()
        {
            //arrange
            string nameWithRightPadding = testName + " ";
            //act
            testScene.Name = nameWithRightPadding;
            //assert
            Assert.AreEqual(testScene.Name, testName);
        }

        [TestMethod]
        public void NameWithPaddingsFail()
        {
            //arrange
            string nameWithPaddings = " " + testName + " ";
            //act
            testScene.Name = nameWithPaddings;
            //assert
            Assert.AreEqual(testScene.Name, testName);
        }

        [TestMethod]
        public void AddPositionedModelToScene()
        {
            //arrange
            bool isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsFalse(isContainedByScene);

            //act
            testScene.AddPositionedModel(testPositionedModel);

            //assert
            isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsTrue(isContainedByScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Duplicated PositionedModel in Scene")]
        public void CantHaveDuplicatedPositionedModelInScene()
        {
            //arrange
            bool isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsFalse(isContainedByScene);
            testScene.AddPositionedModel(testPositionedModel);
            isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsTrue(isContainedByScene);
            //act
            testScene.AddPositionedModel(testPositionedModel);
        }

        [TestMethod]
        public void RemovePositionedModelFromScene()
        {
            //arrange
            bool isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsFalse(isContainedByScene);
            testScene.AddPositionedModel(testPositionedModel);
            isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsTrue(isContainedByScene);
            //act
            testScene.RemovePositionedModel(testPositionedModel);
            //assert
            isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsFalse(isContainedByScene);
        }

        [TestMethod]
        public void RemovingSameNamePositionedModelsWithDiffPosition()
        {
            //arrange
            PositionedModel testPositionedModelAlternative = new PositionedModel()
            {
                PositionedModelModel = testModel,
                PositionedModelPosition = testPositionAlternative
            };

            testScene.AddPositionedModel(testPositionedModel);
            testScene.AddPositionedModel(testPositionedModelAlternative);

            bool isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsTrue(isContainedByScene);

            //act
            testScene.RemovePositionedModel(testPositionedModel);

            //assert
            isContainedByScene = testScene.ContainsPositionedModel(testPositionedModel);
            Assert.IsFalse(isContainedByScene);
        }

        [TestMethod]
        public void SetCreationDateWhenCreatingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now;

            //act
            testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
            };

            //assert
            Assert.AreEqual(testScene.CreationDate, DateTimeProvider.Now);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenAddingPositionedModel()
        {
            //arrange

            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
                LastModificationDate = DateTimeProvider.Now,
            };

            //act
            DateTime previousDate = testScene.LastModificationDate;
            testScene.AddPositionedModel(testPositionedModel);
            bool lastModificationIsLater = testScene.LastModificationDate > previousDate;

            //assert
            Assert.IsTrue(lastModificationIsLater);
        }

        [TestMethod]
        public void LastModificationDateUpdatedWhenRemovingPositionedModel()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
                

            };
            testScene.AddPositionedModel(testPositionedModel);
            testScene.LastModificationDate = DateTimeProvider.Now;
            //act
            DateTime previousDate = testScene.LastModificationDate;
            testScene.RemovePositionedModel(testPositionedModel);
            bool lastModificationIsLater = testScene.LastModificationDate > previousDate;
            
            //assert
            Assert.IsTrue(lastModificationIsLater);
        }

        [TestMethod]
        public void LastRenderDateUpdatedAfterRenderingScene()
        {
            //arrange
            DateTimeProvider.Now = DateTime.Now.AddDays(-1);
            testScene = new Scene()
            {
                CreationDate = DateTimeProvider.Now,
                LastRenderDate = DateTimeProvider.Now,
            };

            //act

            DateTime previousDate = testScene.LastRenderDate;
            testScene.RenderScene();
            bool lastRenderIsLater = testScene.LastRenderDate > previousDate;
            
            //assert
            Assert.IsTrue(lastRenderIsLater);
        }
        public void AddSceneToCollection()
        {
            //act
            SceneCollection.AddScene(testScene);
            bool added = SceneCollection.ContainsScene(testScene.Name);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSceneFromCollection()
        {
            //act
            SceneCollection.AddScene(testScene);
            Scene getScene = SceneCollection.GetScene(testName);
            //assert
            Assert.ReferenceEquals(testScene, getScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene does not exist in the collection")]
        public void RemoveSceneFromCollection()
        {
            SceneCollection.AddScene(testScene);
            //act
            SceneCollection.RemoveScene(testName);
            SceneCollection.GetScene(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene does not exist in the collection")]
        public void CantRemoveSceneNotInCollection()
        {
            //act
            SceneCollection.RemoveScene(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene with the same name already exists in the collection")]
        public void CantAddSceneWithNameAlreadyInCollection()
        {
            //arrange
            SceneCollection.AddScene(testScene);
            Scene newScene = new Scene()
            {
                Name = testName,
                LookFrom = defaultLookFromVector,
                LookAt = defaultLookAtVector,
            };

            //act
            SceneCollection.AddScene(newScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete model used by active scene")]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            ModelCollection.AddModel(testModel);
            testScene.AddPositionedModel(testPositionedModel);
            SceneCollection.AddScene(testScene);

            //act
            ModelCollection.RemoveModel(testModel.Name);
        }

        [TestMethod]
        public void DeleteModelAfterDeletingScene()
        {
            ModelCollection.AddModel(testModel);
            testScene.AddPositionedModel(testPositionedModel);
            SceneCollection.AddScene(testScene);

            //act
            SceneCollection.RemoveScene(testScene.Name);
            ModelCollection.RemoveModel(testModel.Name);
        }

        [TestMethod]
        public void ModelIsUsedByScene()
        {
            Assert.IsFalse(testScene.ContainsModel(testModel.Name));
            ModelCollection.AddModel(testModel);
            //act
            testScene.AddPositionedModel(testPositionedModel);
            //assert
            Assert.IsTrue(testScene.ContainsModel(testModel.Name));
            testScene.RemovePositionedModel(testPositionedModel);
            Assert.IsFalse(testScene.ContainsModel(testModel.Name));


        }

        [TestCleanup]
        public void TearDown()
        {
            SphereCollection.DropCollection();
            LambertianCollection.DropCollection();
            ModelCollection.DropCollection();
            SceneCollection.DropCollection();
            testScene.DropPositionedModels();
        }
    }
}