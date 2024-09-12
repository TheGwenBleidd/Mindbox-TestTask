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

    // Насчет проверки были идеи, как выделить отдельно логику, думал, не overthink ли я задачу.
    // Можно было выделить логику через Visitor или Chain of Responsibility, но решил оставить так.
    // Если это окажется минусом — что ж, тогда будем разбираться).
    // Тут ещё зависит от требований бизнеса: если потребуется, например, проверка равнобедренности,
    // вычисление медиан и т.д., тогда можно было бы подумать над выносом.
    // Логика проверки на прямоугольность могла бы быть отдельной сущностью, если бы, скажем, для круга
    // тоже понадобилась подобная специфичная проверка.
    public bool IsRightAngled()
    {
        double[] sides = { SideA, SideB, SideC };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.0001;
    }
}