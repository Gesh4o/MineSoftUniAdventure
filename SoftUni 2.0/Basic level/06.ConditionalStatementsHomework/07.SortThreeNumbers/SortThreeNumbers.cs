using System;

class SortThreeNumbers
{
    static void Main()
    {
        //Reading three numbers from the console
        Console.Write("Insert number a: ");
        double firstNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number b: ");
        double secondNumber = double.Parse(Console.ReadLine());

        Console.Write("Insert number c: ");
        double thirdNumber = double.Parse(Console.ReadLine());

        //Now using some nested ifs
        if (firstNumber > secondNumber && firstNumber > thirdNumber)
        {
            if (secondNumber>thirdNumber)
            {
                Console.WriteLine("{0} {1} {2}", firstNumber, secondNumber, thirdNumber);

            }
            else
            {
                Console.WriteLine("{0} {1} {2}", firstNumber, thirdNumber, secondNumber);
            }
        }
        else if (secondNumber > firstNumber && secondNumber > thirdNumber)
        {
            if (firstNumber > thirdNumber)
            {
                Console.WriteLine("{0} {1} {2}", secondNumber, firstNumber, secondNumber);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", secondNumber, thirdNumber, firstNumber);
            }
        }
        else
        {
            if (firstNumber > secondNumber)
            {
                Console.WriteLine("{0} {1} {2}", thirdNumber, firstNumber, secondNumber);
            }
            else
            {
                Console.WriteLine("{0} {1} {2}", thirdNumber, secondNumber, firstNumber);

            }
        }
    }
}