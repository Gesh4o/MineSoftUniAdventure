namespace _04.Hexadecimal
{
    using System;

    public class HexadecimalMain
    {
        public static void Main(string[] args)
        {
            int decimalValue = Convert.ToInt32(Console.ReadLine(), 16);
            Console.WriteLine(decimalValue);
        }
    }
}
