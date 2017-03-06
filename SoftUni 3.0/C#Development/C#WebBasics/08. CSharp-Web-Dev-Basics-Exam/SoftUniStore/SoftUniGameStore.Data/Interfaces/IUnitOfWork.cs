namespace SoftUniGameStore.Data.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Save();
    }
}
