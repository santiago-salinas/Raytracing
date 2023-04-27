using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        [TestInitialize]
        public void Initialize()
        {
            modelName = "Wooden ball";          
            testNullName = string.Empty;

            sphereName = "Small sized sphere";
            radius = 5;
            lambertianName = "Oak color";
            color = new Color((float)133 / 255, (float)94 / 255, (float)66 / 255);

            testSphere = new Sphere(sphereName,radius);
            testLambertian = new Lambertian(lambertianName,color);


            testModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
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
                ModelShape = testSphere,
                ModelColor = testLambertian
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
            ModelCollection.AddModel(testModel);
            bool added = ModelCollection.ContainsModel(testModel.Name);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetModelFromCollection()
        {
            //act
            ModelCollection.AddModel(testModel);
            Model getModel = ModelCollection.GetModel(modelName);
            //assert
            Assert.ReferenceEquals(testModel, getModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void RemoveModelFromCollection()
        {
            ModelCollection.AddModel(testModel);
            //act
            ModelCollection.RemoveModel(modelName);
            ModelCollection.GetModel(modelName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void CantRemoveModelNotInCollection()
        {
            //act
            ModelCollection.RemoveModel(modelName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model with the same name already exists in the collection")]
        public void CantAddModelWithNameAlreadyInCollection()
        {
            //arrange
            ModelCollection.AddModel(testModel);
            Model newModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };

            //act
            ModelCollection.AddModel(newModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete sphere used by active model")]
        public void CantDeleteSphereFromCollectionUsedByModel()
        {
            //arrange
            SphereCollection.AddSphere(testSphere);
            ModelCollection.AddModel(testModel);
            //act
            SphereCollection.RemoveSphere(sphereName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Cant delete lambertian used by active model")]
        public void CantDeleteLambertianFromCollectionUsedByModel()
        {
            //arrange
            LambertianCollection.AddLambertian(testLambertian);
            ModelCollection.AddModel(testModel);
            //act
            LambertianCollection.RemoveLambertian(lambertianName);
        }

        [TestMethod]
        public void DeleteSphereAndLambertianAfterDeletingModel()
        {
            //arrange
            SphereCollection.AddSphere(testSphere);
            LambertianCollection.AddLambertian(testLambertian);
            ModelCollection.AddModel(testModel);
            ModelCollection.RemoveModel(modelName);

            //act
            SphereCollection.RemoveSphere(sphereName);
            LambertianCollection.RemoveLambertian(lambertianName);
            //assert
            bool sphereDeleted = !SphereCollection.ContainsSphere(sphereName);
            bool lambertianDeleted = !LambertianCollection.ContainsLambertian(lambertianName);
            Assert.IsTrue(sphereDeleted && lambertianDeleted);
        }

        [TestCleanup]
        public void TearDown()
        {
            SphereCollection.DropCollection();
            LambertianCollection.DropCollection();
            ModelCollection.DropCollection();

        }
    }
}
