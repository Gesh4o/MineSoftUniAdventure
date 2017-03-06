namespace SoftUniGameStore.Data.Repositories
{
    using Models;

    public class UserRepository : AbstractRepository<User>
    {
        public UserRepository(GameStoreContext context)
            : base(context)
        {
        }
    }
}
