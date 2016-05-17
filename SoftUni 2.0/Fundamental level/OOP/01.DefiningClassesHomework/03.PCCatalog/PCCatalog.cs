using System;
using System.Linq;
namespace _03.PCCatalog
{
    class PCCatalog
    {
        static void Main()
        {
            Component processor0 = new Component("Intel", 120m);
            Component processor1 = new Component("Intel", "4GHz", 100M);
            Component hdd0 = new Component("I am HDD", "1TB", 100m);
            Component motherboard0 = new Component("Motherboard", 300m);
            Component videoCard0 = new Component("Nvidia ", "G8000", 100m);

            Computer computer0 = new Computer("First computer", processor0, videoCard0, motherboard0, hdd0, 800M);
            Computer computer1 = new Computer("Second computer", processor1, videoCard0, 1000M);
            Computer computer2 = new Computer("Razor", 3000M);

            Computer[] compArray = new Computer[3]
            {
                computer2,computer0,computer1
            };
            compArray = compArray.OrderBy(comp => comp.Price).ToArray(); //Totally haven't taken this one from stackoverflow.

            foreach (var item in compArray)
            {
                Computer.PrintComponentsAndDisplaySum(item);
            }
        }
    }
}
