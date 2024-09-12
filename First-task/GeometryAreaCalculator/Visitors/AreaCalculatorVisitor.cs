using GeometryAreaCalculator.Lib.Figures;
using GeometryAreaCalculator.Lib.Figures.Abstractions;

namespace GeometryAreaCalculator.Lib.Visitors
{
    // –еализовал логику вычислени€ через паттерн Visitor.
    // ћожет показатьс€ излишней абстракцией, но она нужна дл€ читабельности и соблюдени€ SRP.
    // Ћогика вычислени€ площади маловеро€тно будет часто мен€тьс€. –азве что перейдем в неевклидовую геометрию :)
    // ƒумал реализовать через стратегию, но тогда пришлось бы дл€ каждой фигуры делать отдельную стратегию,
    // и при добавлении функционала, например, вычислени€ периметра, пришлось бы городить еще больше классов.
    // „ерез Visitor можно просто добавить новый "посетитель", и дл€ всех фигур сразу добавить логику новой операции.
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