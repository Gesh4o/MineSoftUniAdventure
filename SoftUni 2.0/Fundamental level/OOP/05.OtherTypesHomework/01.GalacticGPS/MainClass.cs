﻿namespace _01.GalacticGPS
{
    using System;

    public class MainClass
    {
        private static void Main()
        {
            Location home = new Location(18.037986, 28.870097, Planet.Earth);
            Console.WriteLine(home);
        }
    }
}
