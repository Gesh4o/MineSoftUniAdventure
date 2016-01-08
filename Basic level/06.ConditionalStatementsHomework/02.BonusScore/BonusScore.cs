using System;

class BonusScore
{
    static void Main()
    {
        Console.Write("Please insert your score (e.g. 1): ");
        int score = int.Parse(Console.ReadLine());

        if (0 < score && score < 4)
        {
            Console.WriteLine("{0}", score * 10);
        }
        else if (3 < score && score < 7)
        {
            Console.WriteLine("{0}", score * 100);
        }
        else if (6 < score && score <= 9)
        {
            Console.WriteLine("{0}", score * 1000);
        }
        else
        {
            Console.WriteLine("Invalid score");
        }
    }
}