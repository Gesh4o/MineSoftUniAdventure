namespace _05.SpecialNumbers
{
    using System;

    public class SpecialNumbersMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int number = 1; number <= n; number++)
            {
                bool isSpecial = CheckIsNumberSpecial(number);
                if (isSpecial)
                {
                    Console.WriteLine(number + " -> True");
                }
                else
                {
                    Console.WriteLine(number + " -> False");
                }
            }
        }

        private static bool CheckIsNumberSpecial(int number)
        {
            int sum = 0;
            int currentNumber = number;
            int remainder;
            while (currentNumber > 0)
            {
                remainder = currentNumber % 10;
                sum += remainder;
                currentNumber /= 10;
            }

            if (sum == 5 || sum == 7 || sum == 11)
            {
                return true;
            }

            return false;
        }
    }
}
