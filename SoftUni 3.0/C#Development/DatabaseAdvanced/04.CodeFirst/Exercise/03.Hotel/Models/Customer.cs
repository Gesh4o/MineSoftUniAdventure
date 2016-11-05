namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Customers")]
    class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }

        [MinLength(5)]
        [MaxLength(25)]
        public string FirstName { get; set; }


        [MinLength(10)]
        [MaxLength(35)]
        public string LastName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }
    }
}
