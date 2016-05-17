using System;

class DevideBySevenAndFive
{
    static void Main()
    {
        Console.Write("Please insert an integer and the answer will tell you if it can be devided by both 5 and 7: ");
        int integer = int.Parse(Console.ReadLine());
        if (integer == 0)
        {
            Console.WriteLine(false);
            return;
        }
        if (integer % 35 == 0)
        {
            Console.WriteLine(true);
        }
        else
        {
            Console.WriteLine(false);
        }
    }
}