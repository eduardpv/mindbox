using Geometry.Models;

namespace Geometry.Interfaces
{
    public interface IFigureVisitor
    {
        void Visit(Circle circle); 
        void Visit(Triangle triangle); 
    }
}
