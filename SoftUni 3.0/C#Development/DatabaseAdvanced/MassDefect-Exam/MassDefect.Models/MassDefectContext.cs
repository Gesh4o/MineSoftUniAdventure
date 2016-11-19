namespace MassDefect.Models
{
    using Models;
    using System.Data.Entity;

    public class MassDefectContext : DbContext
    {
        public MassDefectContext()
            : base("name=MassDefectContext")
        {
        }

        public virtual DbSet<Person> People { get; set; }

        public virtual DbSet<Anomaly> Anomalies { get; set; }

        public virtual DbSet<Planet> Planets { get; set; }

        public virtual DbSet<SolarSystem> SolarSystems { get; set; }

        public virtual DbSet<Star> Stars { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anomaly>()
                .HasMany(a => a.Victims)
                .WithMany(p => p.Anomalies)
                .Map(configuration =>
                {
                    configuration.MapLeftKey("AnomalyId");
                    configuration.MapRightKey("PersonId");
                    configuration.ToTable("AnomalyVictims");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}