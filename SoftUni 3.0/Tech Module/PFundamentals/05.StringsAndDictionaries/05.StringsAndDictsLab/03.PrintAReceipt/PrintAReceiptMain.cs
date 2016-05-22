namespace _03.PrintAReceipt
{
    using System;
    using System.Globalization;
    using System.Linq;

    public class PrintAReceiptMain
    {
        public static void Main(string[] args)
        {
            string top = "/----------------------\\";
            string mid = "|----------------------|";
            string bot = "\\----------------------/";

            double[] bills = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            Console.WriteLine(top);
            foreach (double bill in bills)
            {
                string billAsString = $"{bill:0.00}";
                Console.WriteLine("|{0} |", billAsString.PadLeft(21, ' '));
            }
            
            Console.WriteLine(mid);
            string totalSumASString = $"{bills.Sum():0.00}";
            Console.WriteLine("| Total: {0} |", totalSumASString.PadLeft(13, ' '));
            Console.WriteLine(bot);
        }
    }
}
