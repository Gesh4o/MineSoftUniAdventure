using System;

class RandomNumbersInGivenRange
{
    static void Main(string[] args)
    {
        Console.Write("Please insert number N: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("Please insert minValue value: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Please insert maximum value");
        int maxValue = int.Parse(Console.ReadLine());

        Random numbers = new Random();

        for (int count = 0; count < n; count++)
        {
            Console.Write("{0} ", numbers.Next(minValue, maxValue+1));
        }
    }
}