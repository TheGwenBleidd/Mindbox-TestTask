using GeometryAreaCalculator.Lib.Figures.Abstractions;

namespace GeometryAreaCalculator.Lib.Figures;

public sealed class Circle(double radius) : IShape
{
    public double Radius { get; } = radius;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }
}