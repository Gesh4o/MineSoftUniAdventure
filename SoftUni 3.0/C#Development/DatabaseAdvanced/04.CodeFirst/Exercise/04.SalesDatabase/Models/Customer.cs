namespace _04.SalesDatabase.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Customer
    {
        public Customer()
        {
            this.SalesForCustomer = new HashSet<Sale>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }

        [Required]
        public string CreditCardNumber { get; set; }

        public ICollection<Sale> SalesForCustomer { get; set; }
    }
}