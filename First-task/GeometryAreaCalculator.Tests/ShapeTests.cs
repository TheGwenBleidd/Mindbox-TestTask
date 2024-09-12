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

    [Fact]
    public void Triangle_IsRightAngled_ShouldReturnTrue_WhenTriangleIsRightAngled()
    {
        // Arrange
        var triangle = new Triangle(3.0, 4.0, 5.0);

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.True(isRightAngled); // 3-4-5 — это прямоугольный треугольник
    }

    [Fact]
    public void Triangle_IsRightAngled_ShouldReturnFalse_WhenTriangleIsNotRightAngled()
    {
        // Arrange
        var triangle = new Triangle(5.0, 5.0, 5.0); // Равносторонний треугольник

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.False(isRightAngled); // Равносторонний треугольник не может быть прямоугольным
    }

    [Fact]
    public void Triangle_IsRightAngled_ShouldHandleNonRightAngledCasesCorrectly()
    {
        // Arrange
        var triangle = new Triangle(2.0, 2.0, 3.0);

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.False(isRightAngled); // Этот треугольник не является прямоугольным
    }

    [Fact]
    public void Triangle_IsRightAngled_ShouldHandleFloatingPointPrecision()
    {
        // Arrange
        var triangle = new Triangle(1.0, Math.Sqrt(2), 1.0); // Почти прямоугольный треугольник

        // Act
        var isRightAngled = triangle.IsRightAngled();

        // Assert
        Assert.True(isRightAngled); // Ожидаем, что математически это прямоугольный треугольник
    }
}