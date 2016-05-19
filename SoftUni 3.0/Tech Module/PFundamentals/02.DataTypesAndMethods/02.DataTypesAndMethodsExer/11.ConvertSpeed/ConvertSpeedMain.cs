namespace _11.ConvertSpeed
{
    using System;

    public class ConvertSpeedMain
    {
        public static void Main(string[] args)
        {
            int distanceInMeters = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            float allTimeInMinutes = (hours * 60.0F) + minutes + (seconds / 60.0F);
            float metersPerSecond = distanceInMeters / (allTimeInMinutes * 60.0F);
            float kilometersPerHour = (distanceInMeters / 1000.0F) / (allTimeInMinutes / 60.0F);
            float milesPerHour = (distanceInMeters / 1609.0F) / (allTimeInMinutes / 60.0F);

            Console.WriteLine("{0}", metersPerSecond);
            Console.WriteLine("{0}", kilometersPerHour);
            Console.WriteLine("{0}", milesPerHour);

        }
    }
}
