namespace SoftUniGameStore.Data.Repositories
{
    using Models;

    public class CartRepository : AbstractRepository<Cart>
    {
        public CartRepository(GameStoreContext context)
            : base(context)
        {
        }
    }
}
