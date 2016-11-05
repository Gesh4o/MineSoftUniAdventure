namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("RoomTypes")]
    class RoomTypes
    {
        [Key]
        public string RoomType { get; set; }


        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
