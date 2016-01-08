using System;

class SumOfFiveNumbers
{
    static void Main()
    {
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
        Console.WriteLine("Please enter five numbers at the next line each separated by  \" \": ");
        string[] tokens = Console.ReadLine().Split();
        double firstNumber = double.Parse(tokens[0]);
        double secondNumber = double.Parse(tokens[1]);
        double thirdNumber = double.Parse(tokens[2]);
        double fourthNumber = double.Parse(tokens[3]);
        double fifthNumber = double.Parse(tokens[4]);
        Console.WriteLine("The sum of these numbers is: {0} !", firstNumber + secondNumber + thirdNumber + fourthNumber + fifthNumber);
    }
}