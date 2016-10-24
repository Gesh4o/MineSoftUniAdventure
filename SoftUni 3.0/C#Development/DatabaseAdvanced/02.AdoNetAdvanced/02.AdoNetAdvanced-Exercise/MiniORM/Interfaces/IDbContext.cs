namespace MiniORM.Interfaces
{
    using System.Collections.Generic;

    public interface IDbContext
    {
        bool Persist<T>(object entity);

        T FindById<T>(int id);

        IEnumerable<T> FindAll<T>();

        IEnumerable<T> FindAll<T>(string condition);

        T FindFirst<T>();

        T FindFirst<T>(string condition);

        int Delete<T>(string condition);
    }
}
