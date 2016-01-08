using System;

class Volleyball
{
    static void Main()
    {
        string year = Console.ReadLine();
        int holidays = int.Parse(Console.ReadLine());
        int hometownWeekends = int.Parse(Console.ReadLine());

        double normalWeekendsPlays = (48 - hometownWeekends) * 3.0 / 4;
        double holidayPlays = holidays * 2.0 / 3;
        double normalYearPlays = hometownWeekends + normalWeekendsPlays + holidayPlays;
        if (year == "leap")
        {
            Console.WriteLine("{0}",Math.Floor(normalYearPlays +(0.15*normalYearPlays)) );
        }
        else
        {
            Console.WriteLine("{0}",Math.Floor(normalYearPlays));
        }
    }
}