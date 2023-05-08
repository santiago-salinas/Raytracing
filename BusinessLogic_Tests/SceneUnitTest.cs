using BusinessLogic;
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

        private User testUser;


        [TestInitialize]
        public void Initialize()
        {
            testName = "Rolling Balls";
            testNullName = string.Empty;

            testScene = new Scene()
            {
                Name = testName
            };

            testUser = new User()
            {
                UserName = "Username1"
            };



            modelName = "Wooden ball";
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
                Color = color
            };


            testModel = new Model()
            {
                Name = modelName,
                Shape = testSphere,
                Material = testLambertian
            };

            testPosition = new Vector(0, 0, 0);
            testPositionAlternative = new Vector(1, 1, 1);


            testPositionedModel = new PositionedModel()
            {
                Model = testModel,
                Position = testPosition
            };



            DateTimeProvider.Reset();

        }

        [TestMethod]
        public void SceneCreatedSuccesfullyTest()
        {
            testScene = new Scene()
            {
                Name = testName
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
                Model = testModel,
                Position = testPositionAlternative
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
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            //act
            SceneCollection.AddScene(testScene);
            bool added = SceneCollection.ContainsScene(testScene.Name, testUser);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSceneFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            //act
            SceneCollection.AddScene(testScene);
            Scene getScene = SceneCollection.GetScene(testName, testUser);
            //assert
            Assert.ReferenceEquals(testScene, getScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene does not exist in the collection")]
        public void RemoveSceneFromCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            SceneCollection.AddScene(testScene);
            //act
            SceneCollection.RemoveScene(testName, testUser);
            SceneCollection.GetScene(testName, testUser);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Scene does not exist in the collection")]
        public void CantRemoveSceneNotInCollection()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            //act
            SceneCollection.RemoveScene(testName, testUser);
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

            testScene = new Scene()
            {
                Name = testName,
                Owner = testUser
            };
            SceneCollection.AddScene(testScene);

            //act
            Scene newScene = new Scene()
            {
                Name = testName,
                Owner = testUser
            };
            SceneCollection.AddScene(newScene);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete model used by active scene")]
        public void CantDeleteModelFromCollectionUsedByScene()
        {
            //arrange

            ModelCollection.AddModel(testModel);
            testScene.AddPositionedModel(testPositionedModel);
            SceneCollection.AddScene(testScene);

            //act
            ModelCollection.RemoveModel(testModel.Name, testModel.Owner);
        }

        [TestMethod]
        public void DeleteModelAfterDeletingScene()
        {
            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            ModelCollection.AddModel(testModel);
            testScene.AddPositionedModel(testPositionedModel);
            SceneCollection.AddScene(testScene);

            //act
            SceneCollection.RemoveScene(testScene.Name, testUser);
            ModelCollection.RemoveModel(testModel.Name, testModel.Owner);
        }

        [TestMethod]
        public void ModelIsUsedByScene()
        {

            //arrange
            User testUser = new User();
            testUser.UserName = "Username";
            testScene.Owner = testUser;
            Assert.IsFalse(testScene.ContainsModel(testModel));
            ModelCollection.AddModel(testModel);
            //act
            testScene.AddPositionedModel(testPositionedModel);
            //assert
            Assert.IsTrue(testScene.ContainsModel(testModel));
            testScene.RemovePositionedModel(testPositionedModel);
            Assert.IsFalse(testScene.ContainsModel(testModel));


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