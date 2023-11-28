using Geometry.Interfaces;

namespace Geometry.Models
{
    public class Circle : ICircle
    {
        public double Radius { get; }

        /// <exception cref="ArgumentException">The radius of the circle is incorrect.</exception>
        public Circle(double radius)
        {
            if (radius < Constants.MinAccuracy)
                throw new ArgumentException("The radius of the circle is incorrect.", nameof(radius));

            Radius = radius;
        }

        public void Accept(IFigureVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
