using BusinessLogic.DomainObjects;
using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class PositionedModelUnitTest
    {
        private PositionedModel _testPositionedModel;
        private Vector _testPosition;

        private Model _testModel;
        private string _modelName;

        private Sphere _testSphere;
        private string _sphereName;
        private float _radius;

        private Lambertian _testLambertian;
        private string _lambertianName;
        private Color _color;

        [TestInitialize]
        public void Initialize()
        {
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
                Color = _color,
                Name = _lambertianName,
            };

            _testModel = new Model()
            {
                Name = _modelName,
                Shape = _testSphere,
                Material = _testLambertian
            };

            _testPosition = new Vector(0, 0, 0);

            _testPositionedModel = new PositionedModel()
            {
                Model = _testModel,
                Position = _testPosition
            };
        }

        [TestMethod]
        public void PositionedModelCreatedSuccesfullyTest()
        {
            //arrange
            _testPosition = new Vector(0, 0, 0);

            //act
            _testPositionedModel = new PositionedModel()
            {
                Model = _testModel,
                Position = _testPosition
            };
            //assert
            Assert.IsNotNull(_testModel);
        }
    }
}
