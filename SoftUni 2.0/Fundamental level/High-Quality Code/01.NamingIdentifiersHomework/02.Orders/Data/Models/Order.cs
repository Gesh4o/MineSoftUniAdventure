namespace Orders.Models
{
    using Interfaces;

    public class Order : IOrder
    {
        public Order(int id, int productID, int quantity, decimal discount)
        {
            this.ID = id;
            this.ProductID = productID;
            this.Quantity = quantity;
            this.Discount = discount;
        }

        public int ID { get; set; }

        public int ProductID { get; set; }

        public int Quantity { get; set; }

        public decimal Discount { get; set; }
    }
}
