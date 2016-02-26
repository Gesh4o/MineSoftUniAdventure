namespace _01.BiggerNumber
{
    using System;

    public class BiggerNumberMain
    {
        public static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            int biggerNumber = GetBiggerNumber(firstNumber, secondNumber);

            Console.WriteLine(biggerNumber);
        }

        private static int GetBiggerNumber(int firstNumber, int secondNumber)
        {
            if (firstNumber > secondNumber)
            {
                return firstNumber;
            }

            return secondNumber;
        }
    }
}
