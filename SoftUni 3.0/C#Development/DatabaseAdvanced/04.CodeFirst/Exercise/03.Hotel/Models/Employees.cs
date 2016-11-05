namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Employees")]
    class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(25)]
        public string FirstName { get; set; }


        [Required]
        [MinLength(10)]
        [MaxLength(35)]
        public string LastName { get; set; }


        [MinLength(5)]
        [MaxLength(25)]
        public string Title { get; set; }


        [MaxLength(1000)]
        public string Notes { get; set; }

    }
}
