using System;

class Program
{
    static void Main()
    {
        //Note that in the expample given for integer = - 1 it has to say true, 
        //so I decided to work with absolute values even though I don't think it is correct.
        //Every program in this homework will read '.' as decimal symbol - "1.23" (Invariant culture), if you don't have it setted up use the code below:
        //System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;

        Console.Write("Please insert an integer to check if it is odd (else is even): ");
        int integer = int.Parse(Console.ReadLine());
        Console.Write("Your answer is: ");
        Console.WriteLine(Math.Abs(integer) % 2 == 1 ? true : false);
        
    }
}