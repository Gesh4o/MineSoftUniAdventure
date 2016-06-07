namespace _01.DayOfWeek
{
    using System;

    public class DayOfWeekMain
    {
        public static void Main(string[] args)
        {
            int dayNumber = int.Parse(Console.ReadLine());

            string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

            if (dayNumber <= 7 && dayNumber >= 1)
            {
                Console.WriteLine(days[dayNumber - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
