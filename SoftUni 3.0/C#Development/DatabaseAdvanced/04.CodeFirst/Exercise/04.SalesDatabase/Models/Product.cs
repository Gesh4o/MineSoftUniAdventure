namespace _04.SalesDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Products")]
    public class Product
    {
        public Product()
        {
            this.SalesOfProduct = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double Quantity { get; set; }

        [Range(0, (double)decimal.MaxValue)]
        [Required]
        public decimal Price { get; set; }

        public ICollection<Sale> SalesOfProduct { get; set; }
    }
}
