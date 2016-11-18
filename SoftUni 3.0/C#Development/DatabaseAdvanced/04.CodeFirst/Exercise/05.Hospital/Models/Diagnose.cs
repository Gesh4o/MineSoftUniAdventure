namespace _05.Hospital.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Diagnose
    {
        public Diagnose()
        {
            this.Comments = new List<string>();
        }

        public Diagnose(string name, Patient patient) : this()
        {
            this.Name = name;
            this.Patient = patient;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<string> Comments { get; set; }

        [Required]
        public Patient Patient { get; set; }
    }
}