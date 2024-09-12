using GeometryAreaCalculator.Lib.Figures;

namespace GeometryAreaCalculator.Lib.Abstractions;

public interface IShapeVisitor
{
    void Visit(Circle circle);
    void Visit(Triangle triangle);
}