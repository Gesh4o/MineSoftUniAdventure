using System;

class NumbersFromOneToN
{
    static void Main()
    {
        Console.WriteLine("Please insert \"n\": ");
        string readingLine = Console.ReadLine();
        int n = int.Parse(readingLine);
        int rows ;
        for (rows =1; rows <= n; rows++)
        {
            Console.WriteLine(rows);
        }
    }
}