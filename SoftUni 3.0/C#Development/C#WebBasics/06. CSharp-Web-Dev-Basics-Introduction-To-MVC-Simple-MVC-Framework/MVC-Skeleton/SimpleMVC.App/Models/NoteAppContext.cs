namespace SimpleMVC.App.Models
{
    using System.Data.Entity;

    public class NoteAppContext : DbContext
    {
        public NoteAppContext()
            : base("name=NoteAppContext")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Note> Notes { get; set; }
    }
}