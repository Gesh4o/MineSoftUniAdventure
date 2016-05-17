using System;
using System.Threading;
using System.Globalization;

class ComparingFloats
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("Enter two numbers to check if they are equal (Note that \".\" works):"); 
        double number0 = double.Parse(Console.ReadLine());
        double number1 = double.Parse(Console.ReadLine());
        Console.WriteLine(number0);
        Console.WriteLine(number1);
        double epsilon = 0.000001;
        bool checkNumber = Math.Abs(number0 - number1) < epsilon;
        if (Math.Abs(number0 - number1) < epsilon)
        {
            Console.WriteLine("Your answer is: " + checkNumber+"- they are equal!");
        }
        else if (Math.Abs(number0 - number1) >= epsilon)
        {
            Console.WriteLine("Your answer is: " + checkNumber + "- they are not equal!");
        }
    }
}