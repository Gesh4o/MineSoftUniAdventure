namespace _11.CommonStrings
{
    using System;
    using System.Collections.Generic;

    public class CommonStringsMain
    {
        public static void Main(string[] args)
        {
            HashSet<char> firstString = new HashSet<char>(Console.ReadLine().ToCharArray());
            HashSet<char> secondString = new HashSet<char>(Console.ReadLine().ToCharArray());

            firstString.IntersectWith(secondString);
            if (firstString.Count > 1)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}
