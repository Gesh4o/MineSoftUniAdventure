namespace Orders.Models
{
    using Interfaces;

    public class Product :IProduct
    {
        public Product(int id, string name, int categoryID, decimal unitPrice, int unitsInStock)
        {
            this.ID = id;
            this.Name = name;
            this.CategoryId = categoryID;
            this.UnitPrice = unitPrice;
            this.UnitsInStock = unitsInStock;
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal UnitPrice { get; set; }

        public int UnitsInStock { get; set; }
    }
}
