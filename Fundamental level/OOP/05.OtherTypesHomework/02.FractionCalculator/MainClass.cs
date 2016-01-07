namespace _02.FractionCalculator
{
    using System;

    public class MainClass
    {
        private static void Main()
        {
            Fraction frac1 = new Fraction(5, 5);
            Fraction frac2 = new Fraction(5, 3);
            Fraction result = frac1 + frac2;
            Console.WriteLine(result);
            Console.WriteLine();
            Fraction fraction1 = new Fraction(22, 7);
            Fraction fraction2 = new Fraction(40, 4);
            Fraction result1 = fraction1 + fraction2;
            Console.WriteLine(result1.Numerator);
            Console.WriteLine(result1.Denominator);
            Console.WriteLine(result1);

        }
    }
}
