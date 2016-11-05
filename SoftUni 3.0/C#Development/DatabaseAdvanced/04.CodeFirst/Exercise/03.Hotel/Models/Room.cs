namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    class Room
    {
        [Key]
        public string RoomNumber { get; set; }

        public int RoomTypeId { get; set; }

        [ForeignKey("RoomTypeId")]
        public RoomTypes RoomType { get; set; }

        public int BedTypeId { get; set; }

        [ForeignKey("BedTypeId")]
        public BedTypes BedType { get; set; }

        public int RoomStatusId { get; set; }

        [ForeignKey("RoomStatusId")]
        public RoomStatus RoomStatus { get; set; }

        public decimal Rate { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
