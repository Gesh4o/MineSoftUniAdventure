namespace _02.Customer.Contracts
{
    public interface IPayment
    {
        string ProductName { get; }

        decimal ProductPrice { get; }
    }
}