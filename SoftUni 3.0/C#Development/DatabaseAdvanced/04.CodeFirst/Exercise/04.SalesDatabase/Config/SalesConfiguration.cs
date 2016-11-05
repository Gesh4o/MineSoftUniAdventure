namespace _04.SalesDatabase.Config
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;
    using System.Collections.Generic;
    using System.Text;

    class SalesConfiguration : DbMigrationsConfiguration<SalesDbContext>
    {
        private static readonly Random Random = new Random();
        public SalesConfiguration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SalesDbContext context)
        {
            if (
                !context.Customers.Any() && 
                !context.Locations.Any() && 
                !context.Products.Any() && 
                !context.Sales.Any() && 
                !context.Locations.Any())
            {
                PopulateWithRandomCustomers(context.Customers);
            }

            base.Seed(context);
        }

        private void PopulateWithRandomCustomers(DbSet<Customer> customers)
        {
            int customerCount = Random.Next(101);
            for (int i = 0; i < customerCount; i++)
            {
                customers.Add(new Customer()
                {
                    Name = GenerateRandomString(),
                    CreditCardNumber = GenerateRandomString(15)
                });
            }
        }

        private void PopulateWithRandomProducts(DbSet<Product> products)
        {
            int productCount = Random.Next(51);
            for (int i = 0; i < productCount; i++)
            {
                products.Add(new Product()
                {
                    Name = GenerateRandomString(),
                    Quantity = Random.Next(0, int.MaxValue),
                    Price = Random.Next(0, int.MaxValue)
                });
            }

        }

        private string GenerateRandomString()
        {
            int count = Random.Next(100);
            return GenerateRandomString(count);
        }

        private string GenerateRandomString(int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                // 33-127 is range of simple non-escapable chars. (ASCII table)
                sb.Append((char)(Random.Next(33, 127)));
            }

            return sb.ToString().Trim();
        }
    }
}
