using BusinessLogic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BusinessLogic_Tests
{
    [TestClass]
    public class VectorUnitTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Vector vec1 = new Vector()
            {
                FstValue = -8,
                SndValue = 2.1,
                ThrdValue = 3.2,
            };

            Vector vec2 = new Vector(-8, 2.1, 3.2);

            Assert.AreEqual(vec1, vec2);
        }


        [TestMethod]
        public void TestEquals()
        {
            var vec1 = new Vector(0.5, 7.3, 6);
            var vec2 = new Vector(0.5, 7.3, 6);

            Assert.IsTrue(Equals(vec1, vec2));
        }


        [TestMethod]
        public void TestAdd()
        {
            var vec1 = new Vector(1, 2, 3);
            var vec2 = new Vector(4.6, 5.0, 6);

            var result = vec1.Add(vec2);
            var expected = new Vector(5.6, 7, 9);

            Assert.IsTrue(Equals(result, expected));
        }

        [TestMethod]
        public void TestSubtract()
        {
            var vec1 = new Vector(1, 2, 3);
            var vec2 = new Vector(4, 5, 6);

            var result = vec1.Subtract(vec2);
            var expected = new Vector(-3, -3, -3);

            Assert.IsTrue(Equals(result, expected));
        }

        [TestMethod]
        public void TestMultiply()
        {
            var vec = new Vector(1, 2, 3);

            var result = vec.Multiply(2);
            var expected = new Vector(2, 4, 6);

            Assert.IsTrue(Equals(result, expected));
        }

        [TestMethod]
        public void TestDivide()
        {
            var vec = new Vector(2, 4, 6);

            var result = vec.Divide(2);
            var expected = new Vector(1, 2, 3);

            Assert.IsTrue(Equals(result, expected));
        }

        [TestMethod]
        public void TestAddTo()
        {
            var vec1 = new Vector(1, 2, 3);
            var vec2 = new Vector(4, 5, 6);

            vec1.AddTo(vec2);

            var expected = new Vector(5, 7, 9);
            Assert.IsTrue(Equals(vec1, expected));
        }

        [TestMethod]
        public void TestSubtractFrom()
        {
            var vec1 = new Vector(1, 2, 3);
            var vec2 = new Vector(4, 5, 6);

            vec1.SubtractFrom(vec2);

            var expected = new Vector(-3, -3, -3);

            Assert.IsTrue(Equals(vec1, expected));
        }

        [TestMethod]
        public void TestScaleUpBy()
        {
            var vec = new Vector(1, 2, 3);

            vec.ScaleUpBy(2);

            var expected = new Vector(2, 4, 6);

            Assert.IsTrue(Equals(vec, expected));
        }

        [TestMethod]
        public void TestScaleDownBy()
        {
            var vec = new Vector(2, 4, 6);

            vec.ScaleDownBy(2);

            var expected = new Vector(1, 2, 3);

            Assert.IsTrue(Equals(vec, expected));
        }

        [TestMethod]
        public void TestSquaredLength()
        {
            var vec = new Vector(2, 3, 6);

            var result = vec.SquaredLength();

            Assert.AreEqual(result, 49);
        }

        [TestMethod]
        public void TestLength()
        {
            // Arrange
            Vector v = new Vector(3, 4, 0);

            // Act
            double result = v.Length();
            var expected = 5;

            // Assert
            Assert.AreEqual(result, expected);
        }


        [TestMethod]
        public void GetUnit_ReturnsUnitVector()
        {
            // Arrange
            var v = new Vector(3, 4, 5);

            // Act
            var unitVector = v.GetUnit();
            var expected = new Vector(0.42426406871192851, 0.56568542494923801, 0.70710678118654757);

            // Assert
            Assert.IsTrue(Equals(unitVector, expected));
        }

        [TestMethod]
        public void Dot_ReturnsDotProduct()
        {
            // Arrange
            var v1 = new Vector(1, 2, 3);
            var v2 = new Vector(4, 5, 6);

            // Act
            var dotProduct = v1.Dot(v2);

            // Assert
            Assert.AreEqual(32, dotProduct, 0.0001);
        }

        [TestMethod]
        public void Cross_ReturnsCrossProduct()
        {
            // Arrange
            var v1 = new Vector(1, 0, 0);
            var v2 = new Vector(0, 1, 0);

            // Act
            var crossProduct = v1.Cross(v2);
            var expected = new Vector(0, 0, 1);

            // Assert
            Assert.IsTrue(Equals(crossProduct, expected));
        }
    }
}
