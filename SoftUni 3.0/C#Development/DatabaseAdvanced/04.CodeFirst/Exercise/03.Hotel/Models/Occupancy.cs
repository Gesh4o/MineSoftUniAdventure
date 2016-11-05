namespace _03.Hotel.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Occupencies")]
    class Occupancy
    {
        [Key]
        public int Id { get; set; }

        public string AccountNumbeerId { get; set; }

        [Required]
        [ForeignKey("AccountNumbeerId")]
        public string AccountNumber { get; set; }

        public string RoomNumberId { get; set; }

        [ForeignKey("RoomNumberId")]
        public string RoomNumber { get; set; }

        public DateTime DateOccupied { get; set; }

        public decimal RateApplied { get; set; }
        public decimal PhoneCharge { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
