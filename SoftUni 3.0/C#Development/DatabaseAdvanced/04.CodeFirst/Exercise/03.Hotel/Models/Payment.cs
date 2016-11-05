using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Hotel.Models
{
    class Payment
    {
        [Key]
        public int Id { get; set; }

        public string AccountNumbeerId { get; set; }

        [Required]
        [ForeignKey("AccountNumbeerId")]
        public string AccountNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public DateTime? FirstDateOccupied { get; set; }

        public DateTime? LastDateOccupied { get; set; }

        public int TotalDays { get; set; }

        [Required]
        public decimal AmountCharged { get; set; }

        public decimal TaxRate { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal PaymentTotal { get; set; }

        [MaxLength(1000)]
        public string Notes { get; set; }
    }
}
