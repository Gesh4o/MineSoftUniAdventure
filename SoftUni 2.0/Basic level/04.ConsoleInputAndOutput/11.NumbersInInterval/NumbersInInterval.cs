using System;

class NumbersInInterval
{
    static void Main()
    {
        Console.WriteLine("Please insert number which starts the interval: ");
        int startNumber = int.Parse(Console.ReadLine());
        Console.WriteLine("Please insert number which ends the interval: ");
        int endNumber = int.Parse(Console.ReadLine());
        if (startNumber > endNumber)
        {
            endNumber = startNumber;
            startNumber = endNumber;
        }
        int difference = Math.Abs(endNumber - startNumber);
        int thirdNumber = startNumber - 1;
        int count = 0;
        for (int i = 0; i <= difference; i++ )
        {
            thirdNumber++;
            if(thirdNumber % 5==0)
            {
                Console.WriteLine("The number(s) devidable by 5 are (is):" + thirdNumber);
                count++;
            }
        }
        Console.WriteLine("Number(s) that can be devided by 5 (p): " + count++ + " !");
    }
}