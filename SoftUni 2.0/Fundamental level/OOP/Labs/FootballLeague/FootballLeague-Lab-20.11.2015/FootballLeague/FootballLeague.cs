using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballLeague
{
    class FootballLeague1
    {
        static void Main()
        {
            string line = Console.ReadLine();

            while (line != "end")
            {
                try
                {
                    LeagueManager.HandleInput(line);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
                line = Console.ReadLine();
            }
        }
    }
}
