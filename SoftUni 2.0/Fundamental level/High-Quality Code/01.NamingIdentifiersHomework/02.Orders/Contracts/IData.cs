namespace Orders.Contracts
{
    using System.Collections.Generic;
    using Models.Interfaces;

    public interface IData
    {
        IEnumerable<ICategory> AllproductCategories { get; }

        IEnumerable<IProduct> AllProducts { get; }

        IEnumerable<IOrder> AllOrders { get; }


    }
}
