namespace Orders.Models.Interfaces
{
    public interface IProduct
    {
        int ID { get; set; }

        string Name { get; set; }

        int CategoryId { get; set; }

        decimal UnitPrice { get; set; }

        int UnitsInStock { get; set; }
    }
}
