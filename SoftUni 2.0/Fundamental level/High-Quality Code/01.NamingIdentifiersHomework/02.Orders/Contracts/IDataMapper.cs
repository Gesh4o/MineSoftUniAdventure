namespace Orders.Contracts
{
    using System.Collections.Generic;
    using Models.Interfaces;

    public interface IDataMapper
    {
        IEnumerable<ICategory> GetAllCategories();

        IEnumerable<IProduct> GetAllProducts();

        IEnumerable<IOrder> GetAllOrders();
    }
}
