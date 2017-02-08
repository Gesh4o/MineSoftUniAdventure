namespace PizzaMore.Data
{
    using Models;
    using System.Data.Entity;
    using System;

    public class PizzaMoreContext : DbContext
    {
        public PizzaMoreContext()
            : base("name=PizzaMoreContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Pizza> Pizzas { get; set; }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}