namespace Orders
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Contracts;

    public class Program
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IDataMapper initialOrderData = new DataMapper();
            IData data = new Data(initialOrderData);

            // Names of the 5 most expensive products
            IEnumerable<string> fiveMostExpensiveProductsNames = data.AllProducts
                .OrderByDescending(product => product.UnitPrice)
                .Take(5)
                .Select(p => p.Name);
            Console.WriteLine(string.Join(Environment.NewLine, fiveMostExpensiveProductsNames));
            Console.WriteLine(new string('-', 10));

            // Number of products in each category
            var productsInEachCategory = data.AllProducts
                .GroupBy(product => product.CategoryId)
                .Select(grp => new { Category = data.AllproductCategories.First(c => c.Id == grp.Key).Name, Count = grp.Count() })
                .ToList();
            foreach (var product in productsInEachCategory)
            {
                Console.WriteLine("{0}: {1}", product.Category, product.Count);
            }
            Console.WriteLine(new string('-', 10));

            // The 5 top products (by order quantity)
            var fiveMostOrederedProducts = data.AllOrders
                .GroupBy(order => order.ProductID)
                .Select(grp => new { Product = data.AllProducts.First(p => p.ID == grp.Key).Name, Quantities = grp.Sum(grpgrp => grpgrp.Quantity) })
                .OrderByDescending(order => order.Quantities)
                .Take(5);
            foreach (var product in fiveMostOrederedProducts)
            {
                Console.WriteLine("{0}: {1}", product.Product, product.Quantities);
            }
            Console.WriteLine(new string('-', 10));

            // The most profitable category
            var mostProfitableCategory = data.AllOrders
                .GroupBy(order => order.ProductID)
                .Select(g => new { catId = data.AllProducts.First(p => p.ID == g.Key).CategoryId, price = data.AllProducts.First(p => p.ID == g.Key).UnitPrice, quantity = g.Sum(p => p.Quantity) })
                .GroupBy(gg => gg.catId)
                .Select(grp => new { category_name = data.AllproductCategories.First(c => c.Id == grp.Key).Name, total_quantity = grp.Sum(g => g.quantity * g.price) })
                .OrderByDescending(g => g.total_quantity)
                .First();
            Console.WriteLine("{0}: {1}", mostProfitableCategory.category_name, mostProfitableCategory.total_quantity);

            // Nothing special here, check Minesweeper.
        }
    }
}
