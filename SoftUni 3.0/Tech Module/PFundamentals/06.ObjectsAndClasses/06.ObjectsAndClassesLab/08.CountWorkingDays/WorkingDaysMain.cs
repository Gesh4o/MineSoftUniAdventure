namespace _08.CountWorkingDays
{
    using System;
    using System.Globalization;

    public class WorkingDaysMain
    {
        public static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workdaysCounter = 0;
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (CheckIsWorkday(date))
                {
                    workdaysCounter++;
                }
            }

            Console.WriteLine(workdaysCounter);
        }

        private static bool CheckIsWorkday(DateTime date)
        {
            bool isWorkday = true;

            if (date.DayOfWeek == DayOfWeek.Sunday || date.DayOfWeek == DayOfWeek.Saturday)
            {
                isWorkday = false;
            }
            else if ((date.Day == 1 && date.Month == 1) ||
                (date.Day == 3 && date.Month == 3) ||
                (date.Day == 1 && date.Month == 5) ||
                (date.Day == 6 && date.Month == 5) ||
                (date.Day == 24 && date.Month == 5) ||
                (date.Day == 6 && date.Month == 9) ||
                (date.Day == 22 && date.Month == 9) ||
                (date.Day == 1 && date.Month == 11) ||
                (date.Day == 24 && date.Month == 12) ||
                (date.Day == 25 && date.Month == 12) ||
                (date.Day == 26 && date.Month == 12))
            {
                isWorkday = false;
            }

            return isWorkday;
        }
    }
}
