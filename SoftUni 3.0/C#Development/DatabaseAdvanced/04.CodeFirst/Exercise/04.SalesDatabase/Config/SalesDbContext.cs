namespace _04.SalesDatabase.Config
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SalesDbContext : DbContext
    {
        // Your context has been configured to use a 'SalesDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // '_04.SalesDatabase.SalesDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SalesDbContext' 
        // connection string in the application configuration file.
        public SalesDbContext()
            : base("name=SalesDbContext.cs")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SalesDbContext, SalesConfiguration>());
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<StoreLocation> Locations { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}