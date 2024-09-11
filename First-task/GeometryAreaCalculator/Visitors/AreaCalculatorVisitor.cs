using GeometryAreaCalculator.Lib.Figures;
using GeometryAreaCalculator.Lib.Figures.Abstractions;

namespace GeometryAreaCalculator.Lib.Visitors
{
    // ���������� ������ ���������� ����� ������� Visitor.
    // ����� ���� �������� ����������, ���� ��� ���������� � ��� ����� �� �������� ������� SRP.
    // �� ������ ������ ���������� ������� ���� �� ��������� ��� ����� ����������� ��� ����� �������. ���� ������ �� ����������� � ������������ ���������.
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