namespace _26.Factorial
{
    using System;
    using System.Numerics;

    public class FactorialMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            BigInteger factorial = GetFactorial(n);

            Console.WriteLine(factorial);
        }

        private static BigInteger GetFactorial(int number)
        {
            if (number <= 1)
            {
                return 1;
            }

            return GetFactorial(number - 1) * number;
        }
    }
}
