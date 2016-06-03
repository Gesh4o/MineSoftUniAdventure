namespace _02.TailRecursion
{
    using System;

    public class FactorialMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            // For n print the result of: result = n * (n-1) * (n - 2) * (n - 3) ... 1
            long result;
            result = GetResultRecursive(n);

            // result = GetResultTailRecursive(n, 1);
            Console.WriteLine(result);
        }

        private static long GetResultRecursive(int n)
        {
            if (n <= 1)
            {
                return 1;
            }

            return n * GetResultRecursive(n - 1);
        }

        private static long GetResultTailRecursive(int n, long result)
        {
            if (n <= 1)
            {
                return result;
            }

            return GetResultTailRecursive(n - 1, result * n);
        }
    }
}
