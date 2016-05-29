namespace _07.SquareNumber
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SquareNumbersMain
    {
        public static void Main(string[] args)
        {
            int[] sequence = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

            List<int> squares = sequence.Where(IsSquare).ToList();

            Console.WriteLine(string.Join(" ", squares.OrderByDescending(n => n)));
        }

        private static bool IsSquare(int number)
        {
            double sqrtNum = Math.Sqrt(number);
            if (sqrtNum == (int)sqrtNum)
            {
                return true;
            }

            return false;
        }
    }
}
