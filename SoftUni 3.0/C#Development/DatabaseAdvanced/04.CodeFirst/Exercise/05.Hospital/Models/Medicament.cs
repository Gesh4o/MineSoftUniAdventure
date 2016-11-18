namespace _05.Hospital.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        public Medicament()
        {
        }

        public Medicament(string name, Patient patient)
        {
            this.Name = name;
            this.Patient = patient;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}