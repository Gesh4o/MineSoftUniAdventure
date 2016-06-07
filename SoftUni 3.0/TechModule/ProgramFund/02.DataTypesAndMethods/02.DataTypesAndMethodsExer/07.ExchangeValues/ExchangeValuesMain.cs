namespace _07.ExchangeValues
{
    using System;

    public class ExchangeValuesMain
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            string firstOutputFormat = @"Before:
a = {0}
b = {1}";
            Console.WriteLine(firstOutputFormat, a, b);

            string secondOutputFormat = @"After:
a = {0}
b = {1}
";

            int oldValue = a;
            a = b;
            b = oldValue;

            Console.WriteLine(secondOutputFormat, a, b);
        }
    }
}
