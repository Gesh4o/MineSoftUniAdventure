using System;

class DifferenceBetweenDates
{
    static void Main()
    {
        //Reading the input, casting it to datetime variable then doing the maths.
        Console.Write("Please enter first date: ");
        string startDate = Console.ReadLine();

        Console.Write("Please enter second date: ");
        string endDate = Console.ReadLine();

        DateTime firstDate = DateTime.Parse(startDate);
        DateTime secondDate = DateTime.Parse(endDate);

        int result = (secondDate - firstDate).Days;

        Console.WriteLine("The difference between these two dates in days is: {0} !",result);

    }
}