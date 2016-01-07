namespace _03.CompanyHierarchy
{
    using System;
    using Interfaces;

    public class Sale : ISale
    {
        private string productName;
        private string date;
        private decimal price;

        // Really thought abous this one. I personally think that is more user friendly to put the date in a string and perfom later a validation.

        public Sale(string productName, string date, decimal price)
        {
            this.ProductName = productName;
            this.Date = date;
            this.Price = price;
        }

        public string ProductName
        {
            get
            {
                return this.productName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentOutOfRangeException("Product name must not be empty or null!");
                }

                this.productName = value;
            }
        }

        public string Date
        {
            get
            {
                return this.date;
            }

            set
            {
                DateTime futureBoundary = DateTime.Now.AddHours(1);
                string firstSaleDate = "01.12.2003";
                DateTime pastBoundary = DateTime.Parse(firstSaleDate);
                DateTime currentSaleTime = DateTime.Parse(value);
                if (currentSaleTime > futureBoundary || currentSaleTime < pastBoundary)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("The sale's date must be in {0} to {1} !", pastBoundary, futureBoundary));
                }

                this.date = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Sale's price must not be negative!");
                }

                this.price = value;
            }
        }
    }
}
