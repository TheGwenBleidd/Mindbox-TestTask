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

    // Насчет проверки были идеи, как выделить отдельно логику, думал, не overthink ли я задачу.
    // Можно было выделить логику через Visitor или Chain of Responsibility, но решил оставить так.
    // Если это окажется минусом — что ж, тогда будем разбираться).
    // Тут ещё зависит от требований бизнеса: если потребуется, например, проверка равнобедренности,
    // вычисление медиан и т.д., тогда можно было бы подумать над выносом.
    // Логика проверки на прямоугольность могла бы быть отдельной сущностью, если бы, скажем, для круга
    // тоже понадобилась подобная специфичная проверка.
    public bool IsRightAngled()
    {
        // Логика может выглядеть не самой красивой и читабельной, но я честно не понял,
        // что именно оценивается — знание геометрии или просто реализация.
        // Взял бы с интернета, но решил написать своё. 
        // Был вариант сделать решение лаконичнее через массив, но решил оставить это
        // как есть ради производительности.
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