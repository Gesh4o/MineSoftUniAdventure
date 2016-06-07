namespace _25.MasterNumber
{
    using System;

    public class MasterNumberMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int num = 1; num <= n; num++)
            {
                if (CheckIsMaster(num))
                {
                    Console.WriteLine(num);
                }
            }
        }

        private static bool CheckIsMaster(int num)
        {
            if (CheckIsPalindrome(num) && CheckIsDevisibleBySeven(num) && CheckIsHavingOneEvenDigit(num))
            {
                return true;
            }

            return false;
        }

        private static bool CheckIsHavingOneEvenDigit(int num)
        {
            while (num > 0)
            {
                int remainder = num % 10;
                if (remainder % 2 == 0)
                {
                    return true;
                }

                num /= 10;
            }

            return false;
        }

        private static bool CheckIsDevisibleBySeven(int num)
        {
            int sum = 0;
            while (num > 0)
            {
                sum += num % 10;
                num /= 10;
            }

            return sum % 7 == 0;
        }

        private static bool CheckIsPalindrome(int num)
        {
            string numberAsString = num.ToString();
            for (int i = 0; i < numberAsString.Length / 2; i++)
            {
                if (numberAsString[i] != numberAsString[numberAsString.Length - 1 - i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
