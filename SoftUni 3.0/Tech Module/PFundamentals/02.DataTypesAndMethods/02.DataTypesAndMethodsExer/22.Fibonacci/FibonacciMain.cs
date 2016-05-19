namespace _22.Fibonacci
{
    using System;

    public class FibonacciMain
    {
        private const int MaxSize = 100;

        private static long[] memo = new long[MaxSize];

        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long fibonacciNumber = CalculateFibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        private static long CalculateFibonacci(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            if (memo[n] != 0)
            {
                return memo[n];
            }

            memo[n] = CalculateFibonacci(n - 1) + CalculateFibonacci(n - 2);
            return memo[n];
        }
    }
}
