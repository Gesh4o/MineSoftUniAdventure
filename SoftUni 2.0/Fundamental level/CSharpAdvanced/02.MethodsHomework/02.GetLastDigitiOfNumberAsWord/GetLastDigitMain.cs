namespace _02.GetLastDigitOfNumberAsWord
{
    using System;

    public class GetLastDigitMain
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(GetLastDigitAsWord(512));
            Console.WriteLine(GetLastDigitAsWord(1024));
            Console.WriteLine(GetLastDigitAsWord(12309));
        }

        private static string GetLastDigitAsWord(int number)
        {
            int lastDigit = number % 10;

            string result;
            switch (lastDigit)
            {
                case 1:
                    result = "One";
                    break;
                case 2:
                    result = "Two";
                    break;
                case 3:
                    result = "Three";
                    break;
                case 4:
                    result = "Four";
                    break;
                case 5:
                    result = "Five";
                    break;
                case 6:
                    result = "Six";
                    break;
                case 7:
                    result = "Seven";
                    break;
                case 8:
                    result = "Eight";
                    break;
                case 9:
                    result = "Nine";
                    break;
                default:
                    throw new ArgumentException("Invalid last digit!");
            }

            return result;
        }
    }
}
