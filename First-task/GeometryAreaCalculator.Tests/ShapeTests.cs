using GeometryAreaCalculator.Lib.Figures;
using GeometryAreaCalculator.Lib.Visitors;
using Xunit;

namespace GeometryAreaCalculator.Tests;

public class ShapeTests
{
    [Fact]
    public void CircleArea_ShouldReturnCorrectArea()
    {
        // Arrange
        var circle = new Circle(5.0);
        var areaCalculator = new AreaCalculatorVisitor();

        // Act
        circle.Accept(areaCalculator);

        // Assert
        Assert.Equal(Math.PI * 25, areaCalculator.Area);
    }

    [Fact]
    public void TriangleArea_ShouldReturnCorrectArea()
    {
        // Arrange
        var triangle = new Triangle(3.0, 4.0, 5.0);
        var areaCalculator = new AreaCalculatorVisitor();

        // Act
        triangle.Accept(areaCalculator);

        // Assert
        var expectedArea = 6.0; // Площадь прямоугольного треугольника с сторонами 3, 4, 5
        Assert.Equal(expectedArea, areaCalculator.Area);
    }
}