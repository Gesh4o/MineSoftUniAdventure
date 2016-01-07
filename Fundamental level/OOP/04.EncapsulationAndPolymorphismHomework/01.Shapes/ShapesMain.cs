namespace _01.Shapes
{
    using Interfaces;
    using System;

    class ShapesMain
    {
        static void Main()
        {
            Circle circle = new Circle(3);
            Rectangle rectangle = new Rectangle(2, 4);
            Rhombus rhombus = new Rhombus(1, 3);

            IShape[] figures = new IShape[3] { circle, rectangle, rhombus };

            foreach (var figure in figures)
            {
                Console.WriteLine(figure.CalculateArea());
            }

        }
    }
}
