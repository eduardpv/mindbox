using Geometry.Implementations;
using Geometry.Interfaces;

namespace Geometry.Extensions
{
    public static class FigureExtensions
    {
        public static double GetArea(this IFigure figure)
        {
            var visitor = new ComputeAreaVisitor();
            figure.Accept(visitor);
            return visitor.Area;
        }
    }
}
