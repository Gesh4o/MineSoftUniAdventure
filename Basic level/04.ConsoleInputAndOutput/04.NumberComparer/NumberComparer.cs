using System;

class NumberComparer
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;


        Console.WriteLine("Please insert two numbers to compare:");
        double number0 = double.Parse(Console.ReadLine());
        double number1 = double.Parse(Console.ReadLine());
        Console.WriteLine("The greater number is: {0} !", Math.Max(number0,number1));
    }
}