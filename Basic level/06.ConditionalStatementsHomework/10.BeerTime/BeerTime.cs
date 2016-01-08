using System;
using System.Globalization;
using System.Threading;

class BeerTime
{
    static void Main()
    {
        //Reading the input
        Console.Write("Insert time in the format given - \"hh:mm tt\": ");
        string beerTime = Console.ReadLine();

        //Setting current culture and working with TryParseExact method
        DateTime time;
        CultureInfo enUS = new CultureInfo ("en-US");
        DateTime startBeerTime = DateTime.Parse("1:00 PM");
        DateTime endBeerTime = DateTime.Parse("3:00 AM");
        if (DateTime.TryParseExact(beerTime,"hh:mm tt",enUS,DateTimeStyles.None, out time))
        {
            if (time >= startBeerTime || time < endBeerTime)
            {
                Console.WriteLine("beer time");
            }
            else
            {
                Console.WriteLine("non-beer time");
            }
        }
        else
        {
            Console.WriteLine("Invalid time");
        }
    }
}