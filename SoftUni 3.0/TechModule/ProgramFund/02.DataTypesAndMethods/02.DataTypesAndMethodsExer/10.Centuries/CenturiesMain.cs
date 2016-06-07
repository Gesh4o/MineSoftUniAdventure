namespace _10.Centuries
{
    using System;
    using System.Numerics;

    public class CenturiesMain
    {
        public static void Main(string[] args)
        {
            byte century = byte.Parse(Console.ReadLine());
            byte oneHundred = 100;
            short years = (short)(century * oneHundred);
            int days = (int)(years * 365.2425);
            long hours = days * 24;
            long minutes = hours * 60;
            long seconds = minutes * 60;
            BigInteger miliSeconds = seconds * 1000;
            BigInteger microSeconds = miliSeconds * 1000;
            BigInteger nanoSeconds = microSeconds * 1000;

            Console.WriteLine(century);
            Console.WriteLine(years);
            Console.WriteLine(days);
            Console.WriteLine(hours);
            Console.WriteLine(minutes);
            Console.WriteLine(seconds);
            Console.WriteLine(miliSeconds);
            Console.WriteLine(microSeconds);
            Console.WriteLine(nanoSeconds);
        }
    }
}
