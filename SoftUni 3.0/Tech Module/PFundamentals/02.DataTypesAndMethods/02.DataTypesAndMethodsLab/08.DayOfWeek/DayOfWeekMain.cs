namespace _08.DayOfWeek
{
    using System;

    public class DayOfWeekMain
    {
        public static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());

            if (dayNumber > 7 || dayNumber == 0)
            {
                Console.WriteLine("Error!");
            }
            else
            {
                Console.WriteLine(((DaysOfWeek)dayNumber).ToString());
            }
        }
    }

    public enum DaysOfWeek
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 3,
        Thursday = 4,
        Friday = 5,
        Saturday = 6,
        Sunday = 7
    }
}
