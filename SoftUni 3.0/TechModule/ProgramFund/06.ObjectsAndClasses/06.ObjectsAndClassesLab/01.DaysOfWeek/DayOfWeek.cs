namespace _01.DaysOfWeek
{
    using System;
    using System.Globalization;

    public class DayOfWeek
    {
        public static void Main(string[] args)
        {
            var dateAsText = Console.ReadLine();
            var date = DateTime.ParseExact(dateAsText, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine(date.DayOfWeek);
        }
    }
}
