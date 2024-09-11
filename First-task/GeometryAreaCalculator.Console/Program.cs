using GeometryAreaCalculator.Lib.Figures;
using GeometryAreaCalculator.Lib.Figures.Abstractions;
using GeometryAreaCalculator.Lib.Visitors;

IShape circle = new Circle(5.0);
IShape triangle = new Triangle(3.0, 4.0, 5.0);

var areaCalculator = new AreaCalculatorVisitor();

circle.Accept(areaCalculator);
Console.WriteLine($"Circle Area: {areaCalculator.Area}");

triangle.Accept(areaCalculator);
Console.WriteLine($"Triangle Area: {areaCalculator.Area}");

if (triangle is Triangle t && t.IsRightAngled())
{
    Console.WriteLine("The triangle is right-angled.");
}