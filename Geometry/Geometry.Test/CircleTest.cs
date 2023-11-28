using Geometry.Extensions;
using Geometry.Models;
using System;
using Xunit;

namespace Geometry.Test
{
    public class CircleTest
    {
        [Fact]
        public void NegativeRadiusTest()
        {
            var exceptionType = typeof(ArgumentException);
            var expectedMessageSideA = "The radius of the circle is incorrect. (Parameter 'radius')";

            var exception = Assert.Throws<ArgumentException>(() =>
            {
                new Circle(-10d);
            });

            Assert.NotNull(exception);
            Assert.IsType(exceptionType, exception);
            Assert.Equal(expectedMessageSideA, exception.Message);
        }

        [Fact]
        public void GetAreaTest()
        {
            var radius = 10d;
            
            var circle = new Circle(radius);
            var circleArea = circle.GetArea();

            var expectedArea = Math.PI * Math.Pow(radius, 2d);

            Assert.Equal(expectedArea, circleArea);
        }
    }
}