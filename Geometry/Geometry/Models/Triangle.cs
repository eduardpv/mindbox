using Geometry.Interfaces;

namespace Geometry.Models
{
    public class Triangle : ITriangle
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }
        public bool IsRightTriangle => GetIsRightTriangle();

        /// <exception cref="ArgumentException">The sideA of the triangle is incorrect.</exception>
        /// <exception cref="ArgumentException">The sideB of the triangle is incorrect.</exception>
        /// <exception cref="ArgumentException">The sideC of the triangle is incorrect.</exception>
        /// <exception cref="ArgumentException">The existence of a triangle is impossible.</exception>
        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA < Constants.MinAccuracy)
                throw new ArgumentException("The sideA of the triangle is incorrect.", nameof(sideA));

            if (sideB < Constants.MinAccuracy)
                throw new ArgumentException("The sideB of the triangle is incorrect.", nameof(sideB));

            if (sideC < Constants.MinAccuracy)
                throw new ArgumentException("The sideC of the triangle is incorrect.", nameof(sideC));

            if (!(sideA + sideB > sideC && sideA + sideC > sideB && sideB + sideC > sideA))
                throw new ArgumentException("The existence of a triangle is impossible.");

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public void Accept(IFigureVisitor visitor)
        {
            visitor.Visit(this);
        }

        internal double GetSemiperimeter() => (SideA + SideB + SideC) / 2d;

        private bool GetIsRightTriangle()
        {
            return (Math.Pow(SideA, 2d) == Math.Pow(SideB, 2d) + Math.Pow(SideC, 2d)) ||
                   (Math.Pow(SideB, 2d) == Math.Pow(SideA, 2d) + Math.Pow(SideC, 2d)) ||
                   (Math.Pow(SideC, 2d) == Math.Pow(SideA, 2d) + Math.Pow(SideB, 2d));
        }
    }
}
