namespace _02.Customer.Contracts
{
    using _02.Customer;
    using System.Collections.Generic;

    public interface ICustomer
    {
        string FirstName { get; }

        string MiddleName { get; }

        string LastName { get; }

        string ID { get; }

        string Address { get; }

        string MobilePhone { get; }

        string Email { get; }

        IEnumerable<IPayment> Payments { get; }

        CustomerTypes CustomerType { get; }


    }
}
