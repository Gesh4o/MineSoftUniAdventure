using System;
using System.Collections.Generic;
using Interfaces;

namespace buls.data
{    
    public class Repository<T> : IRepository<T>
    {
        protected List<T> items;

        public Repository()
        {
            this.items = new List<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this.items;
        }

        public virtual T Get(int id)
        {
            T item;
            try
            {
                item = this.items[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                item = default(T);
            }

            return item;
        }

        public virtual void Add(T item)
        {
            this.items.Add(item);
        }
    }
}