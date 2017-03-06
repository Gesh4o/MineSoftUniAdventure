namespace SoftUniGameStore.Data.Repositories
{
    using Models;

    public class LoginRepository : AbstractRepository<Login>
    {
        public LoginRepository(GameStoreContext context)
            : base(context)
        {
        }
    }
}
