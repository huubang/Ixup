using System;
using Ixup.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ixup.Test
{
    [TestClass]
    public class ShapesUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidTriangleException))]
        public void InvalidTrianglePositiveEdgesTest()
        {
            var area = new Triangle(5, 8, 3).ComputeArea();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidTriangleException))]
        public void InvalidTriangleNegativeEdgesTest()
        {
            var area = new Triangle(-5, 8, 3).ComputeArea();
        }

        [TestMethod]
        public void TrivialTriangleAreaTest()
        {
            // Arrange
            var triangle = new Triangle(7, 5, 10);

            // Act
            double area = triangle.ComputeArea();

            // Assert
            Assert.AreEqual(16.25, area);
        }

        [TestMethod]
        public void TrivialTrianglePerimeterTest()
        {
            // Arrange
            var triangle = new Triangle(7, 5, 10);

            // Act
            double p = triangle.ComputePerimeter();

            // Assert
            Assert.AreEqual(22, p);
        }

        [TestMethod]
        public void EquilateralTriangleTypeTest()
        {
            // Arrange
            var triangle = new Triangle(7.5, 7.5, 7.5);

            // Act
            var result = triangle.Type;

            // Assert
            Assert.AreEqual(TriangleType.Equilateral, result);
        }

        [TestMethod]
        public void IsoscelesTriangleTypeTest()
        {
            // Arrange
            var triangle = new Triangle(7.5, 7.5, 7.58);

            // Act
            var result = triangle.Type;

            // Assert
            Assert.AreEqual(TriangleType.Isosceles, result);
        }

        [TestMethod]
        public void ScaleneTriangleTypeTest()
        {
            // Arrange
            var triangle = new Triangle(7.4, 7.6, 7.58);

            // Act
            var result = triangle.Type;

            // Assert
            Assert.AreEqual(TriangleType.Scalene, result);
        }
    }
}
