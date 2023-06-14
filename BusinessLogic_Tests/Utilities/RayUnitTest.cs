using BusinessLogic.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class RayUnitTest
    {
        private Vector _origin;
        private Vector _direction;
        private Ray _ray;

        [TestInitialize]
        public void TestInitialize()
        {
            _origin = new Vector(0, 0, 0);
            _direction = new Vector(1, 1, 1);
            _ray = new Ray(_origin, _direction);
        }

        [TestMethod]
        public void TestOriginProperty()
        {
            // Arrange
            var expected = new Vector(1, 2, 3);

            // Act
            _ray.Origin = expected;
            var actual = _ray.Origin;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestDirectionProperty()
        {
            // Arrange
            var expected = new Vector(2, 3, 4);

            // Act
            _ray.Direction = expected;
            var actual = _ray.Direction;

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestPointAtMethod()
        {
            // Arrange
            var expected = new Vector(2, 2, 2);
            float t = 2;

            // Act
            var actual = _ray.PointAt(t);

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
