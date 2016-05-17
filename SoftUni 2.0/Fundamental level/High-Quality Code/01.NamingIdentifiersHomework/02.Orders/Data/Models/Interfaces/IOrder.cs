namespace Orders.Models.Interfaces
{
    public interface IOrder
    {
        int ID { get; set; }

        int ProductID { get; set; }

        int Quantity { get; set; }

        decimal Discount { get; set; }
    }
}
