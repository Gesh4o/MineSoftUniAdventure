using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("Please insert three numbers to calculate their sum: ");
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());
        Console.WriteLine("The sum of these three number is: {0} !", firstNumber + secondNumber + thirdNumber);
    }
}