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
        public void AddSphereToCollection()
        {
            //act
            testModelCollection.AddModel(testModel);
            bool added = testModelCollection.ContainsModel(testModel.Name);
            //assert
            Assert.IsTrue(added);
        }

        [TestMethod]
        public void GetSphereFromCollection()
        {
            //arrange
            testModelCollection = new SphereCollection();
            //act
            testModelCollection.AddSphere(testSphere);
            Sphere getSphere = testModelCollection.GetModel(testName);
            //assert
            Assert.ReferenceEquals(testSphere, getSphere);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void RemoveSphereFromCollection()
        {
            //arrange
            testModelCollection = new SphereCollection();
            testModelCollection.AddSphere(testSphere);
            //act
            testModelCollection.RemoveSphere(testName);
            testModelCollection.GetSphere(testName);
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere does not exist in the collection")]
        public void CantRemoveSphereNotInCollection()
        {
            //arrange
            testModelCollection = new SphereCollection();
            //act
            testModelCollection.RemoveSphere(testName);
        }



        [TestMethod]
        [ExpectedException(typeof(BusinessLogicException), "Sphere with the same name already exists in the collection")]
        public void CantAddSphereWithNameAlreadyInCollection()
        {
            //arrange
            testModelCollection = new SphereCollection();
            testModelCollection.AddSphere(testSphere);
            Sphere newSphere = new Sphere();
            newSphere.Name = testName;
            newSphere.Radius = differentTestRadius;

            //act
            testModelCollection.AddSphere(newSphere);
        }




    }
}
