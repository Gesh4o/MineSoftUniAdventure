namespace _05.Hospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Patient
    {
        public Patient(string firstName, string lastName, bool hasMedicalInsurance) : this()
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HasMedicalInsurance = hasMedicalInsurance;
        }

        public Patient()
        {
            this.Visitations = new HashSet<Visitation>();
            this.Medicaments = new HashSet<Medicament>();
            this.Diagnoses = new HashSet<Diagnose>();
        }

        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public byte[] Picture { get; set; }

        [Required]
        public bool HasMedicalInsurance { get; set; }

        public ICollection<Visitation> Visitations { get; set; }

        public ICollection<Diagnose> Diagnoses { get; set; }

        public ICollection<Medicament> Medicaments { get; set; }
    }
}
