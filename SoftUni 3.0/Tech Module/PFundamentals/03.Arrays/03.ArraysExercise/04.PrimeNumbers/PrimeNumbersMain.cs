namespace _04.PrimeNumbers
{
    using System;
    using System.Collections.Generic;

    public class PrimeNumbersMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var primes = FindAllPrimesUntil(n);

            Console.WriteLine(string.Join("\n", primes));
        }

        private static IList<long> FindAllPrimesUntil(int n)
        {
            IList<long> primes = new List<long>();
            bool[] sieve = new bool[n + 1];
            sieve[0] = true;
            sieve[1] = true;

            for (int index = 2; index < sieve.Length; index++)
            {
                if (!sieve[index])
                {
                    int counter = 2;
                    while (counter * index < sieve.Length)
                    {
                        sieve[counter * index] = true;
                        counter++;
                    }
                }
            }

            for (int number = 2; number <= n; number++)
            {
                if (!sieve[number])
                {
                    primes.Add(number);
                }    
            }

            return primes;
        }
    }
}
