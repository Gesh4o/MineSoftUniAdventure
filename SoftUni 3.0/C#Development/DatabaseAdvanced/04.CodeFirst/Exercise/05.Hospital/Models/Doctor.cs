namespace _05.Hospital.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Doctor
    {
        public Doctor(string name, string specialty) : this()
        {
            this.Name = name;
            this.Specialty = specialty;
        }

        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Specialty { get; set; }

        public ICollection<Visitation> Visitations { get; set; }
    }
}
