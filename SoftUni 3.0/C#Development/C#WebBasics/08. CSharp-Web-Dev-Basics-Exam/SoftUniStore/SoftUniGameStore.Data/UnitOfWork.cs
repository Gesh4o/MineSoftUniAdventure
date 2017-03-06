namespace SoftUniGameStore.Data
{
    using System;

    using Interfaces;

    using Models;

    using Repositories;

    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed;

        private IRepository<Login> loginRepository;

        private IRepository<User> userRepository;

        private IRepository<Game> gameRepository;

        private IRepository<Cart> cartRepository;
        
        public IRepository<Login> LoginRepository
        {
            get
            {
                if (this.loginRepository == null)
                {
                    this.loginRepository = new LoginRepository(Singleton.Context);
                }

                return this.loginRepository;
            }
        }

        public IRepository<Game> GameRepository
        {
            get
            {
                if (this.gameRepository == null)
                {
                    this.gameRepository = new GameRepository(Singleton.Context);
                }

                return this.gameRepository;
            }
        }

        public IRepository<Cart> CartRepository
        {
            get
            {
                if (this.cartRepository == null)
                {
                    this.cartRepository = new CartRepository(Singleton.Context);
                }

                return this.cartRepository;
            }
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(Singleton.Context);
                }

                return this.userRepository;
            }
        }

        public void Save()
        {
            Singleton.Context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Singleton.Context.Dispose();
                }
            }

            this.disposed = true;
        }

        private static class Singleton
        {
            public static readonly GameStoreContext Context = new GameStoreContext();
        }
    }
}
