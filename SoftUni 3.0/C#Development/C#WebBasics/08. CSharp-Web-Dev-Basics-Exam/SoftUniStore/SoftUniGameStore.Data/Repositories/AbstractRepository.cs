namespace SoftUniGameStore.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    using Interfaces;

    public abstract class AbstractRepository<T> : IRepository<T> where T : class
    {
        protected AbstractRepository(GameStoreContext context)
        {
            this.Context = context;
            this.DbSet = context.Set<T>();
        }

        protected GameStoreContext Context { get; }

        protected DbSet<T> DbSet { get; }

        public virtual IEnumerable<T> Get(
                    Expression<Func<T, bool>> filter = null,
                    params string[] propertiesToInclude)
        {
            IQueryable<T> query = this.DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in propertiesToInclude)
            {
                query = query.Include(includeProperty);
            }

            return query.ToList();
        }

        public virtual T GetById(object id)
        {
            return this.DbSet.Find((int)id);
        }

        public virtual void Insert(T entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            T entityToDelete = this.DbSet.Find(id);
            this.Delete(entityToDelete);
        }

        public virtual void Delete(T entityToDelete)
        {
            if (this.Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                this.DbSet.Attach(entityToDelete);
            }
            
            this.DbSet.Remove(entityToDelete);
        }

        public virtual void Update(T entityToUpdate)
        {
            this.DbSet.Attach(entityToUpdate);
            this.Context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public IEnumerable<T> SearchFor(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.DbSet;

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query;
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = this.DbSet;
            return query.ToList();
        }
    }
}