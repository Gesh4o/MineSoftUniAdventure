namespace _05.Hospital
{
    using Models;
    using System.Data.Entity;

    public class HospitalDbContext : DbContext
    {
       public HospitalDbContext()
            : base("name=HospitalDbContext")
        {
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        public DbSet<Doctor> Doctors { get; set; }
    }
}