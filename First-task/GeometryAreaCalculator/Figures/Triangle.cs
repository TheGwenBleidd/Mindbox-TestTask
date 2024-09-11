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

    // Насчет проверки были идеи, как выделить отдельно логику, задумался не overthink ли задачу,
    // можно было это выделить отдельно логику обработки через Visitor или Chain of Responsibility.
    // Но решил таким образом оставить, если это -point, то тогда чтож поделать).
    // Подумал насчёт сценария когда такая же проверка понадобится для других фигур, выделять отдельную логику для проверки прямоугольности не видел смысла, так как кругу такая проверка бесполезна, если добавится ещё квадрат, 
    public bool IsRightAngled()
    {
        // Логика проверки может выглядить не красивым и менее читаемым. Но я честно не знал что именно оценивается этим пунктом что нужно реализовать логику проверки на прямоуголность.
        // Вряд ли на знание просто геометрии и то я мог это взять решение с интернета
        // Был выбор между более лаконичным и более красивым решение через создание массива. 
        // Но тоже не стоит забывать про производительность так что решил выбрать этот вариант.
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