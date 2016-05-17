namespace Orders
{
    using Contracts;
    using System.Collections.Generic;
    using Models.Interfaces;

    public class Data : IData
    {
        private IEnumerable<IOrder> allOrders;
        private IEnumerable<ICategory> allCategories;
        private IEnumerable<IProduct> allProducts;

        public Data(IDataMapper dataMapper)
        {
            this.allCategories = dataMapper.GetAllCategories();
            this.allOrders = dataMapper.GetAllOrders();
            this.allProducts = dataMapper.GetAllProducts();
        }

        public IEnumerable<IOrder> AllOrders
        {
            get
            {
                return allOrders;
            }
        }

        public IEnumerable<ICategory> AllproductCategories
        {
            get
            {
                return allCategories;
            }
        }

        public IEnumerable<IProduct> AllProducts
        {
            get
            {
                return allProducts;
            }
        }
    }
}
