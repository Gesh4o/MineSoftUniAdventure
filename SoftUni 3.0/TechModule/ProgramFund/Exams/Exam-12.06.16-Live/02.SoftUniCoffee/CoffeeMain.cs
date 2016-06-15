namespace _02.SoftUniCoffee
{
    using System;
    using System.Numerics;
    using System.Globalization;

    public class CoffeeMain
    {
        public static void Main(string[] args)
        {
            int countOfOrders = int.Parse(Console.ReadLine());
            decimal totalPrice = 0;
            for (int order = 0; order < countOfOrders; order++)
            {
                decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
                DateTime month = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                int capsulesCount = int.Parse(Console.ReadLine());

                decimal currentPrice =(pricePerCapsule * DateTime.DaysInMonth(month.Year, month.Month) * capsulesCount * 1.0M);

                Console.WriteLine($"The price for the coffee is: ${currentPrice:F2}");
                totalPrice += currentPrice;
            }

            Console.WriteLine($"Total: ${totalPrice:F2}");
        }
    }
}
