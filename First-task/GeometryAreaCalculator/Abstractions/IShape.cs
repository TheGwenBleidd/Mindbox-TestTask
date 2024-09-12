namespace GeometryAreaCalculator.Lib.Abstractions;

public interface IShape
{
    void Accept(IShapeVisitor visitor);
}