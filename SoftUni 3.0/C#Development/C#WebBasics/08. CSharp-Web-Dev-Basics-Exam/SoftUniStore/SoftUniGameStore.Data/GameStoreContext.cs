namespace SoftUniGameStore.Data
{
    using System.Data.Entity;

    using Models;

    public class GameStoreContext : DbContext
    {
        public GameStoreContext()
            : base("name=GameStoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Login> Logins { get; set; }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Games).WithMany(g => g.Users);
            modelBuilder.Entity<Cart>().HasMany(c => c.Games).WithMany(g => g.Carts);
        }
    }
}