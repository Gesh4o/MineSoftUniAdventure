namespace _14.IntegerToHexAndBi
{
    using System;

    public class ConverterMain
    {
        public static void Main(string[] args)
        {
            int decimalValue = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Convert.ToString(decimalValue, 16).ToUpper());
            Console.WriteLine(Convert.ToString(decimalValue, 2));
        }
    }
}
