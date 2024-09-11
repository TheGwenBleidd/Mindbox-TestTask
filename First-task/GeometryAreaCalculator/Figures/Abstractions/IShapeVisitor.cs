namespace GeometryAreaCalculator.Lib.Figures.Abstractions;

public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Triangle triangle);
}