namespace GeometryAreaCalculator.Lib.Figures.Abstractions;

public interface IShape
{
    void Accept(IShapeVisitor visitor);
}