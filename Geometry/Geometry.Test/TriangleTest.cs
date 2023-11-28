using Geometry.Extensions;
using Geometry.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace Geometry.Test
{
    public class TriangleTest
    {
        [Theory]
        [MemberData(nameof(NegativeSidesData))]
        public void NegativeSidesTest(double sideA, double sideB, double sideC)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }

        [Fact]
        public void NegativeSideATest()
        {
            var exceptionType = typeof(ArgumentException);
            var expectedMessageSideA = "The sideA of the triangle is incorrect. (Parameter 'sideA')";

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                new Triangle(-1d, 2d, 3d);
            });

            Assert.NotNull(exception);
            Assert.IsType(exceptionType, exception);
            Assert.Equal(expectedMessageSideA, exception.Message);
        }

        [Theory]
        [MemberData(nameof(CorrectSidesData))]
        public void CorrectSidesTest(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var triangleArea = triangle?.GetArea();

            Assert.NotNull(triangleArea);
        }

        [Theory]
        [MemberData(nameof(CorrectSidesData))]
        public void GetAreaTest(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var triangleArea = triangle?.GetArea();

            Assert.NotNull(triangleArea);
        }

        [Fact]
        public void IsTriangleNotExistsTest()
        {
            var exceptionType = typeof(ArgumentException);
            var expectedMessageSideA = "The existence of a triangle is impossible.";

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                new Triangle(1d, 1d, 3d);
            });

            Assert.NotNull(exception);
            Assert.IsType(exceptionType, exception);
            Assert.Equal(expectedMessageSideA, exception.Message);
        }

        [Fact]
        public void IsRightTriangleTest()
        {
            var triangle = new Triangle(3d, 4d, 5d);
            var isRightTriangle = triangle.IsRightTriangle;

            Assert.True(isRightTriangle);
        }

        public static IEnumerable<object[]> NegativeSidesData => new List<object[]>
        {
            new object[] { -1, 2, 3 },
            new object[] { 1, -2, 3 },
            new object[] { 1, 2, -3 }
        };

        public static IEnumerable<object[]> CorrectSidesData => new List<object[]>
        {
            new object[] { 3, 4, 5 },
            new object[] { 5, 6, 9 },
            new object[] { 7, 8, 10 }
        };
    }
}
