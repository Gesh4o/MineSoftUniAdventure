namespace SoftUniGameStore.Data.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<T> where T : class
    {
        void Insert(T entity);

        void Delete(T entity);

        IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate);

        IEnumerable<T> GetAll();

        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, params string[] propertiesToInclude);

        T GetById(object id);

        void Update(T entity);
    }
}
