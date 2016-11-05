namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RoomStatuses")]
    class RoomStatus
    {
        [Key]
        public string RoomStat { get; set; }


        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
