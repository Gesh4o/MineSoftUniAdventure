namespace _05.ReversNumber
{
    using System;
    using System.Globalization;

    public class ReverseNumberMain
    {
        public static void Main(string[] args)
        {
            // double reverserdNumber = ReverseNumber(512);
            // double reverserdNumber = ReverseNumber(123.45);
            double reverserdNumber = ReverseNumber(0.12);
            Console.WriteLine(reverserdNumber);
        }

        private static double ReverseNumber(double numberToReverse)
        {
            char[] numberAsChars = numberToReverse.ToString(CultureInfo.InvariantCulture).ToCharArray();
            char[] resultedNumberAsChars = new char[numberAsChars.Length];
            for (int index = 0; index < numberAsChars.Length; index++)
            {
                resultedNumberAsChars[index] = numberAsChars[numberAsChars.Length - 1 - index];
            }

            string resultedNumberString = string.Join(string.Empty, resultedNumberAsChars);

            double resultedNumber = double.Parse(resultedNumberString);

            return resultedNumber;
        }
    }
}
