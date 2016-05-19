namespace _24.PrimeInRange
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            int startNumber = int.Parse(Console.ReadLine());
            int endNumber = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            for (int num = startNumber; num <= endNumber; num++)
            {
                if (CheckIsPrime(num))
                {
                    numbers.Add(num);
                }
            }

            Console.WriteLine(string.Join(", ", numbers));
        }

        private static bool CheckIsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            for (int i = 2; i <= Math.Sqrt(num); i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
