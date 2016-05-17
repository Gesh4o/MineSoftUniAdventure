namespace Orders
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;
    using Contracts;
    using Models.Interfaces;

    public class DataMapper : IDataMapper
    {
        private string categoriesFileName;
        private string productsFileName;
        private string ordersFileName;

        public DataMapper(string categoriesFileName, string productsFileName, string ordersFileName)
        {
            this.categoriesFileName = categoriesFileName;
            this.productsFileName = productsFileName;
            this.ordersFileName = ordersFileName;
        }

        public DataMapper()
            : this("../../Data/Categories.txt", "../../Data/Products.txt", "../../Data/Orders.txt")
        {
        }

        public IEnumerable<ICategory> GetAllCategories()
        {
            List<string> categoriesInfo = this.ReadFileLines(this.categoriesFileName, true);
            return categoriesInfo
                .Select(categoryArgs => categoryArgs.Split(','))
                .Select(categoryArgs => new Category(
                    int.Parse(categoryArgs[0]),
                    categoryArgs[1],
                    categoryArgs[2]));
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            List<string> productsInfo = this.ReadFileLines(this.productsFileName, true);
            return productsInfo
                .Select(productArgs => productArgs.Split(','))
                .Select(productArgs => new Product(
                    int.Parse(productArgs[0]),
                    productArgs[1],
                    int.Parse(productArgs[2]),
                    decimal.Parse(productArgs[3]),
                    int.Parse(productArgs[4])));
        }

        public IEnumerable<IOrder> GetAllOrders()
        {
            List<string> ordersInfo = this.ReadFileLines(this.ordersFileName, true);
            return ordersInfo
                .Select(orderInfo => orderInfo.Split(','))
                .Select(orderInfo => new Order(
                     int.Parse(orderInfo[0]),
                     int.Parse(orderInfo[1]),
                     int.Parse(orderInfo[2]),
                     decimal.Parse(orderInfo[3])));
        }

        private List<string> ReadFileLines(string filename, bool hasHeader)
        {
            var allLines = new List<string>();
            using (var reader = new StreamReader(filename))
            {
                string currentLine;
                if (hasHeader)
                {
                    reader.ReadLine();
                }

                while ((currentLine = reader.ReadLine()) != null)
                {
                    allLines.Add(currentLine);
                }
            }

            return allLines;
        }
    }
}
