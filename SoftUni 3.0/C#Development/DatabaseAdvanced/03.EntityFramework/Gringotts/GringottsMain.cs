namespace Gringotts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class GringottsMain
    {
        private static ApplicationDBContext dbContext = new ApplicationDBContext();
        static void Main(string[] args)
        {
            IEnumerable<string> letters = dbContext.WizzardDeposits.Where(wd => wd.DepositGroup == "Troll Chest").Select(wd => wd.FirstName.Substring(0,1)).Distinct().OrderBy(c => c);

            foreach (string letter in letters)
            {
                Console.WriteLine(letter);
            }
        }
    }
}
