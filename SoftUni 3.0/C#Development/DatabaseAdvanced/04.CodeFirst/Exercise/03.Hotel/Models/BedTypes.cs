namespace _03.Hotel.Models
{
    using System.ComponentModel.DataAnnotations;

    class BedTypes
    {
        [Key]
        public string BedType { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
