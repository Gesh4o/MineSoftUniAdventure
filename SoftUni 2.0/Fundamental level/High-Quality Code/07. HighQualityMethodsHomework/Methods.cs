namespace Methods
{
    using System;

    /// <summary>
    /// A class with real bad cohision.
    /// </summary>
    public class Methods
    {
        public static void Main()
        {
            Console.WriteLine(MathUtils.CalcTriangleArea(3, 4, 5));

            Console.WriteLine(MathUtils.NumberToDigit(5));

            Console.WriteLine(MathUtils.FindMax(5, -1, 3, 2, 14, 2, 3));

            MathUtils.PrintAsNumber(1.3, "f");
            MathUtils.PrintAsNumber(0.75, "%");
            MathUtils.PrintAsNumber(2.30, "r");

            bool horizontal;
            bool vertical;
            Console.WriteLine(MathUtils.CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");

            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
