namespace _07.SalesReport
{
    using System;
    using System.Linq;

    public class ReportMain
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Sale[] sales = new Sale[n];

            for (int inputLine = 0; inputLine < n; inputLine++)
            {
                string[] saleInfo = Console.ReadLine()
                .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                string townName = saleInfo[0];
                string itemName = saleInfo[1];
                double price = double.Parse(saleInfo[2]);
                double quantity = double.Parse(saleInfo[3]);

                Sale sale = new Sale(townName, itemName, price, quantity);
                sales[inputLine] = sale;
            }

            var grouping = sales.GroupBy(s => s.Town).OrderBy(g => g.Key).ToArray();

            foreach (IGrouping<string, Sale> sale in grouping)
            {

                string result = $"{sale.Sum(s => s.Price * s.Quantity * 1.0):0.00}";

                Console.WriteLine("{0} -> {1}", sale.Key, result);
            }
        }
    }

    public class Sale
    {
        public Sale(string town, string item, double price, double quantity)
        {
            this.Town = town;
            this.Item = item;
            this.Price = price;
            this.Quantity = quantity;
        }

        public string Town { get; }

        public string Item { get; }

        public double Price { get; }

        public double Quantity { get; }
    }
}
