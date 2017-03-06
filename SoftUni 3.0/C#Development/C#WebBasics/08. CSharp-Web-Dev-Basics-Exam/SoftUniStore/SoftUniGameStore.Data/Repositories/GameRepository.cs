namespace SoftUniGameStore.Data.Repositories
{
    using Models;

    public class GameRepository : AbstractRepository<Game>
    {
        public GameRepository(GameStoreContext context)
            : base(context)
        {
        }
    }
}
