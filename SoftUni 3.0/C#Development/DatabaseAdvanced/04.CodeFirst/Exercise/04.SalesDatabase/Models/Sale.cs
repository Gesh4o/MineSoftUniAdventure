namespace _04.SalesDatabase.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Sale
    {
        [Key]
        int Id { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        public int StoreLocationId { get; set; }

        [ForeignKey("StoreLocationId")]
        public StoreLocation StoreLocation { get; set; }

        public DateTime Date { get; set; }
    }
}
