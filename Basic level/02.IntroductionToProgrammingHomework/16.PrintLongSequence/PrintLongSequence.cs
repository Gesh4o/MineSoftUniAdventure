using System;

class PrintASequence
{
    static void Main()
    {
        Console.Write("The first 1000 number of the sequence are: ");
        for (int i = 2; i < 1001; i++)
        {
            if (i % 2 == 0)
            {
                Console.Write(i); Console.Write(", ");
            }
            else
            {
                Console.Write(i * -1); Console.Write(", ");
            }
        }
        Console.Write("-1001. ");
    }
}
