namespace Exceptions_Homework.Utilities
{
    using System;

    public static class MathUtilities
    {
        public static void CheckPrime(int number)
        {
            if (number < 1)
            {
                throw new ArgumentException("By definition all numbers below 1 cannot be prime!");
            }

            bool isPrimeNumberFound = true;
            int sqrtNumber = (int)Math.Sqrt(number);
            for (int divisor = 2; divisor <= sqrtNumber; divisor++)
            {
                if (number % divisor == 0)
                {
                    isPrimeNumberFound = false;
                    Console.WriteLine($"The {number} is not prime!");
                    break;
                }
            }

            if (isPrimeNumberFound)
            {
                Console.WriteLine($"The {number} is prime!");
            }
        }

    }
}
