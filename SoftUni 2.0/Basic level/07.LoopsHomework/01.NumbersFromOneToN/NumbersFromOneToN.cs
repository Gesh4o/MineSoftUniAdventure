using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int inputNumber = int.Parse(Console.ReadLine());

        Console.Write("You sequence of numbers [1;{0}] is: ",inputNumber);
        for (int i = 1; i <=inputNumber; i++)
        {
            Console.Write("{0} ",i);
        }
        Console.Write("!");
        Console.WriteLine();
    }
}