namespace _05.Hospital.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public Visitation()
        {
            this.Comments = new List<string>();
        }

        public Visitation(DateTime date, Patient patient, Doctor doctor) : this()
        {
            this.Date = date;
            this.Patient = patient;
            this.Doctor = doctor;
        }

        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        public List<string> Comments { get; set; }

        [Required]
        public Patient Patient { get; set; }

        [Required]
        public Doctor Doctor { get; set; }
    }
}