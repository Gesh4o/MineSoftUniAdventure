using System;

class FourDigitNumber
{
    static void Main()
    {
        Console.Write("Please inser a four digit number: ");
        int number = int.Parse(Console.ReadLine());
        int firstDigit = number / 1000;
        int secondDigit = (number / 100) % 10;
        int thirdDigit = (number / 10) % 10;
        int fourthDigit = number % 10;
        Console.WriteLine("Digit's sum is: {0}" ,(firstDigit) + (secondDigit) + (thirdDigit) + (fourthDigit));
        Console.WriteLine("The reversed number is: {0}{1}{2}{3} ", fourthDigit, thirdDigit, secondDigit, firstDigit);
        Console.WriteLine("The last digit infront: {0}{1}{2}{3} ", fourthDigit, firstDigit, secondDigit, thirdDigit);
        Console.WriteLine("The exchanged second and third digit: {0}{1}{2}{3} ", firstDigit, thirdDigit, secondDigit, fourthDigit);
    }
}