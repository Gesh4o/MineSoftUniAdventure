using System;
class NumbersNotDevisibleBySevenAndThree
{
    static void Main()
    {
        Console.Write("Please insert integer N: ");
        int inputNumber = int.Parse(Console.ReadLine());

        Console.Write("You sequence of numbers [1;{0}] not devisible by 3 and 7 is: ", inputNumber);
        for (int i = 1; i <= inputNumber; i++)
        {
            if (i % 3 != 0 && i % 7 != 0)
            {
                Console.Write("{0} ", i);
            }
            else
            {
                continue;
            }
        }
        Console.Write("!");
        Console.WriteLine();
    }
}