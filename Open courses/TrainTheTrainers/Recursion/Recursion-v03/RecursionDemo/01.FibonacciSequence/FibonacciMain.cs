namespace _01.FibonacciSequence
{
    using System;

    public class FibonacciMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long fibonacciN = GetFibonacci(n);

            Console.WriteLine(fibonacciN);
        }

        private static long GetFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }

            long result = GetFibonacci(n - 1) + GetFibonacci(n - 2);

            return result;
        }

        private static long GetModifiedFibonacci(int n)
        {
            if (n <= 2)
            {
                return 1;
            }

            long result = 5;

            result += GetModifiedFibonacci(n - 1) + GetModifiedFibonacci(n - 2);

            result = result * n;

            return result;
        }
    }
}