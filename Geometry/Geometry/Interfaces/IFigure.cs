namespace Geometry.Interfaces
{
    public interface IFigure
    {
        public void Accept(IFigureVisitor visitor);
    }
}
