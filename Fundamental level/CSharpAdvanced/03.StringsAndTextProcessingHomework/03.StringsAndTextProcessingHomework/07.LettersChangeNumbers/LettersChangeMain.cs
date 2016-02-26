namespace _07.LettersChangeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class LettersChangeMain
    {
        private static readonly Dictionary<char, int> LowerCaseLettersByPosition = new Dictionary<char, int>();
        private static readonly Dictionary<char, int> UpperCaseLettersByPosition = new Dictionary<char, int>();

        public static void Main()
        {
            InitializeDictionaries();

            string[] inputAsStrings = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            decimal sum = 0;
            for (int i = 0; i < inputAsStrings.Length; i++)
            {
                sum += GetLetterChangeNumber(inputAsStrings[i]);
            }

            Console.WriteLine("{0:F2}", sum);
        }

        private static void InitializeDictionaries()
        {
            for (int a = 1; a <= 26; a++)
            {
                LowerCaseLettersByPosition.Add((char)('a' - 1 + a), a);
                UpperCaseLettersByPosition.Add((char)('A' - 1 + a), a);
            }
        }

        private static decimal GetLetterChangeNumber(string inputAsString)
        {
            char firstLetter = inputAsString[0];
            char lastLetter = inputAsString[inputAsString.Length - 1];

            Regex regex = new Regex("[0-9]+");
            string numberToPar = regex.Match(inputAsString).ToString();
            decimal number = decimal.Parse(numberToPar);

            int firstLetterPosition = GetLetterPosition(firstLetter);
            int lastLetterPosition = GetLetterPosition(lastLetter);

            decimal sum = GetFirstLetterSum(firstLetter, number, firstLetterPosition);

            sum = GetLastLetterSum(lastLetter, sum, lastLetterPosition);

            return sum;
        }

        private static int GetLetterPosition(char letter)
        {
            if (char.IsUpper(letter))
            {
                return UpperCaseLettersByPosition[letter];
            }

            return LowerCaseLettersByPosition[letter];
        }

        private static decimal GetFirstLetterSum(char firstLetter, decimal number, int letterPosition)
        {
            decimal firstLetterSum;
            if (char.IsUpper(firstLetter))
            {
                firstLetterSum = number / letterPosition;
            }
            else
            {
                firstLetterSum = number * letterPosition;
            }

            return firstLetterSum;
        }

        private static decimal GetLastLetterSum(char lastLetter, decimal sum, int lastLetterPosition)
        {
            if (char.IsUpper(lastLetter))
            {
                sum -= lastLetterPosition;
            }
            else
            {
                sum += lastLetterPosition;
            }

            return sum;
        }
    }
}
