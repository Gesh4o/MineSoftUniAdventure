namespace _23.PrimeChecker
{
    using System;

    public class PrimeCheckerMain
    {
        public static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            if (n <= 1)
            {
                Console.WriteLine("False");
                return;
            }

            bool isPrime = true;
            for (long i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
