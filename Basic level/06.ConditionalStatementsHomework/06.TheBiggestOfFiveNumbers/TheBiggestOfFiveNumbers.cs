using System;

class TheBiggestOfFiveNumbers
{
    static void Main()
    {
        //Reading the numbers from the console
        Console.Write("Insert number a: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number b: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number c: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number a: ");
        double fourthNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number b: ");
        double fifthNumber = double.Parse(Console.ReadLine());

        //Simply checking if the number is greater then any given number
        //Note that the order after the first "if" is messy becouse I am lazy to preoreder them (wink)
        if (firstNumber > secondNumber && firstNumber > thirdNumber && firstNumber > fourthNumber && firstNumber > fifthNumber)
        {
            Console.WriteLine(firstNumber);
        }

        if (secondNumber > firstNumber && secondNumber > thirdNumber && secondNumber > fourthNumber && secondNumber > fifthNumber)
        {
            Console.WriteLine(fifthNumber);
        }

        if (thirdNumber > firstNumber && thirdNumber > secondNumber && thirdNumber > fourthNumber && thirdNumber > fifthNumber)
        {
            Console.WriteLine(fifthNumber);
        }

        if (fourthNumber > secondNumber && fourthNumber > thirdNumber && fourthNumber > firstNumber && fourthNumber > fifthNumber)
        {
            Console.WriteLine(firstNumber);
        }

        if (fifthNumber > secondNumber && fifthNumber > thirdNumber && fifthNumber > fourthNumber && fifthNumber > firstNumber)
        {
            Console.WriteLine(firstNumber);
        }
    }
}
