namespace _08.NightLife
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NightLifeMain
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, HashSet<string>>> cityInfo = new Dictionary<string, Dictionary<string, HashSet<string>>>();

            string cityInfoString = Console.ReadLine();

            while (cityInfoString != "END")
            {
                string[] splittedInfo = cityInfoString.Split(';');

                if (cityInfo.ContainsKey(splittedInfo[0]))
                {
                    if (cityInfo[splittedInfo[0]].ContainsKey(splittedInfo[1]))
                    {
                        cityInfo[splittedInfo[0]][splittedInfo[1]].Add(splittedInfo[2]);
                    }
                    else
                    {
                        cityInfo[splittedInfo[0]].Add(splittedInfo[1], new HashSet<string>());
                        cityInfo[splittedInfo[0]][splittedInfo[1]].Add(splittedInfo[2]);
                    }
                }
                else
                {
                    cityInfo.Add(splittedInfo[0], new Dictionary<string, HashSet<string>>());
                    cityInfo[splittedInfo[0]].Add(splittedInfo[1], new HashSet<string>());
                    cityInfo[splittedInfo[0]][splittedInfo[1]].Add(splittedInfo[2]);
                }

                cityInfoString = Console.ReadLine();
            }

            foreach (var city in cityInfo.Keys)
            {
                Console.WriteLine(city);
                var sortedVenueNames = cityInfo[city].Keys.OrderBy(v => v).ToList();
                foreach (var venue in sortedVenueNames)
                {
                    var s = cityInfo[city][venue];
                    Console.WriteLine("->{0}: {1}", venue, string.Join(", ", s));
                }
            }
        }
    }
}
