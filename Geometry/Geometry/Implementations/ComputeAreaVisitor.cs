using Geometry.Interfaces;
using Geometry.Models;

namespace Geometry.Implementations
{
    public class ComputeAreaVisitor : IFigureVisitor
    {
        public double Area { get; private set; }

        public void Visit(Circle circle)
        {
            Area = Math.PI * Math.Pow(circle.Radius, 2d);
        }

        public void Visit(Triangle triangle)
        {
            var sp = triangle.GetSemiperimeter();

            Area = Math.Sqrt(
                sp 
                * (sp - triangle.SideA)
                * (sp - triangle.SideB)
                * (sp - triangle.SideC));
        }
    }
}
