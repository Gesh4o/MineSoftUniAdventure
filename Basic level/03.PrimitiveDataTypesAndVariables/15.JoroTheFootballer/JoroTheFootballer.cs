using System;

class JoroTheFootballer
{
    static void Main()
    {
        char leapYear = char.Parse(Console.ReadLine());
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());

        int normalWeekends = 52 - hometownWeekends;
        double weekendsPlays = (double)normalWeekends * 2 / 3;
        double holidayPlays = (double)holidays / 2;
        double hometownPlays = hometownWeekends;

        int combinedPlays =(int)(weekendsPlays + holidayPlays + hometownPlays);
        if (leapYear == 't')
        {
            int leapYearplay = 3;
            int allPlays = (combinedPlays + leapYearplay);
            Console.WriteLine(allPlays);
        }
        if (leapYear == 'f')
        {
            Console.WriteLine(combinedPlays);
        }
        
    }
}