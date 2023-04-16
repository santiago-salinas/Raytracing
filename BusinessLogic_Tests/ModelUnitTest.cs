using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class ModelUnitTest
    {
        private Model testModel;
        private ModelCollection testModelCollection;   
        private SphereCollection testSphereCollection;

        private string modelName;
        private string testNullName;

        private Sphere testSphere;
        private string sphereName;
        private float radius;
        
        private Lambertian testLambertian;
        private string lambertianName;
        private Vector color;

        [TestInitialize]
        public void Initialize()
        {
            modelName = "Wooden ball";          
            testNullName = string.Empty;

            sphereName = "Small sized sphere";
            radius = 5;
            lambertianName = "Oak color";
            color = new Vector(133, 94, 66);

            testSphere = new Sphere(sphereName,radius);
            testLambertian = new Lambertian(lambertianName,color);


            testModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };
            testModelCollection = new ModelCollection();
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
            testModelCollection.AddModel(testModel);
            bool added = testModelCollection.ContainsModel(testModel.Name);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetModelFromCollection()
        {
            //arrange
            testModelCollection = new ModelCollection();
            //act
            testModelCollection.AddModel(testModel);
            Model getModel = testModelCollection.GetModel(modelName);
            //assert
            Assert.ReferenceEquals(testModel, getModel);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void RemoveModelFromCollection()
        {
            //arrange
            testModelCollection = new ModelCollection();
            testModelCollection.AddModel(testModel);
            //act
            testModelCollection.RemoveModel(modelName);
            testModelCollection.GetModel(modelName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model does not exist in the collection")]
        public void CantRemoveModelNotInCollection()
        {
            //arrange
            testModelCollection = new ModelCollection();
            //act
            testModelCollection.RemoveModel(modelName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Model with the same name already exists in the collection")]
        public void CantAddModelWithNameAlreadyInCollection()
        {
            //arrange
            testModelCollection = new ModelCollection();
            testModelCollection.AddModel(testModel);
            Model newModel = new Model()
            {
                Name = modelName,
                ModelShape = testSphere,
                ModelColor = testLambertian
            };

            //act
            testModelCollection.AddModel(newModel);
        }
    }
}
