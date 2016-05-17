using System;

class ThirdDigitIsSeven
{
    static void Main()
    {
        Console.Write("Please insert a number to check if the third digit form right to left is 7: ");
        int number = int.Parse(Console.ReadLine());
        number /= 100;
        int thirdDigit = number % 10;
        Console.WriteLine(thirdDigit==7? true :false);
    }
}