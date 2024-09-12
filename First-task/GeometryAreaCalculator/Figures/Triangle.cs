using GeometryAreaCalculator.Lib.Abstractions;

namespace GeometryAreaCalculator.Lib.Figures;

public sealed class Triangle(double sideA, double sideB, double sideC) : IShape
{
    public double SideA { get; } = sideA;
    public double SideB { get; } = sideB;
    public double SideC { get; } = sideC;

    public void Accept(IShapeVisitor visitor)
    {
        visitor.Visit(this);
    }

    // ������ �������� ���� ����, ��� �������� �������� ������, �����, �� overthink �� � ������.
    // ����� ���� �������� ������ ����� Visitor ��� Chain of Responsibility, �� ����� �������� ���.
    // ���� ��� �������� ������� � ��� �, ����� ����� �����������).
    // ��� ��� ������� �� ���������� �������: ���� �����������, ��������, �������� ����������������,
    // ���������� ������ � �.�., ����� ����� ���� �� �������� ��� �������.
    // ������ �������� �� ��������������� ����� �� ���� ��������� ���������, ���� ��, ������, ��� �����
    // ���� ������������ �������� ����������� ��������.
    public bool IsRightAngled()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.0001;
    }
}