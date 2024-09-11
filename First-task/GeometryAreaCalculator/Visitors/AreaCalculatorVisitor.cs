using GeometryAreaCalculator.Lib.Figures;
using GeometryAreaCalculator.Lib.Figures.Abstractions;

namespace GeometryAreaCalculator.Lib.Visitors
{
    // Реализовал логику вычисления через паттерн Visitor.
    // Может быть излишняя абстракция, хотя для читаемости и ещё чтобы не нарушать принцип SRP.
    // Но просто логика вычисления площади вряд ли постоянно или очень маловерятно что будет менятся. Если только не перенесемся в неевклидовую геометрию.
    public class AreaCalculatorVisitor : IShapeVisitor
    {
        public double Area { get; private set; }

        public void Visit(Circle circle)
        {
            Area = Math.PI * Math.Pow(circle.Radius, 2);
        }

        public void Visit(Triangle triangle)
        {
            double semiPerimeter = (triangle.SideA + triangle.SideB + triangle.SideC) / 2;
            Area = Math.Sqrt(semiPerimeter * (semiPerimeter - triangle.SideA) * (semiPerimeter - triangle.SideB) * (semiPerimeter - triangle.SideC));
        }
    }
}