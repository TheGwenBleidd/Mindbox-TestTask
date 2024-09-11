using GeometryAreaCalculator.Lib.Figures.Abstractions;

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

    // ������ �������� ���� ����, ��� �������� �������� ������, ��������� �� overthink �� ������,
    // ����� ���� ��� �������� �������� ������ ��������� ����� Visitor ��� Chain of Responsibility.
    // �� ����� ����� ������� ��������, ���� ��� -point, �� ����� ���� ��������).
    // ������� ������ �������� ����� ����� �� �������� ����������� ��� ������ �����, �������� ��������� ������ ��� �������� ��������������� �� ����� ������, ��� ��� ����� ����� �������� ����������, ���� ��������� ��� �������, 
    public bool IsRightAngled()
    {
        // ������ �������� ����� ��������� �� �������� � ����� ��������. �� � ������ �� ���� ��� ������ ����������� ���� ������� ��� ����� ����������� ������ �������� �� ��������������.
        // ���� �� �� ������ ������ ��������� � �� � ��� ��� ����� ������� � ���������
        // ��� ����� ����� ����� ���������� � ����� �������� ������� ����� �������� �������. 
        // �� ���� �� ����� �������� ��� ������������������ ��� ��� ����� ������� ���� �������.
        if (SideA > SideB && SideA > SideC)
        {
            return Math.Abs(Math.Pow(SideA, 2) - (Math.Pow(SideB, 2) + Math.Pow(SideC, 2))) < 0.0001;
        }
        else if (SideB > SideA && SideB > SideC)
        {
            return Math.Abs(Math.Pow(SideB, 2) - (Math.Pow(SideA, 2) + Math.Pow(SideC, 2))) < 0.0001;
        }
        else
        {
            return Math.Abs(Math.Pow(SideC, 2) - (Math.Pow(SideA, 2) + Math.Pow(SideB, 2))) < 0.0001;
        }
    }
}