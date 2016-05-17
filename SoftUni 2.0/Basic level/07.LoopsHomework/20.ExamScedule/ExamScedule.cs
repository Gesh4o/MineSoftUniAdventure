using System;
using System.Globalization;
using System.Threading;

class ExamScedule
{
    static void Main()
    {
        int startingHours = int.Parse(Console.ReadLine());
        int startingMinutes = int.Parse(Console.ReadLine());
        string partOfDay = Console.ReadLine();
        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

        double examHours = double.Parse(Console.ReadLine());
        double examMinutes = double.Parse(Console.ReadLine());

        string startingTime = startingHours + ":" + startingMinutes + " " + partOfDay;
        DateTime time;
        bool isValid = DateTime.TryParse(startingTime, out time);
        if (isValid)
        {
            time = time.AddHours(examHours);
            time = time.AddMinutes(examMinutes);


            Console.WriteLine(string.Format("{0:hh:mm:tt}", time));
        }
        else
        {
            Console.WriteLine("Invalid input!");
        }
    }
}