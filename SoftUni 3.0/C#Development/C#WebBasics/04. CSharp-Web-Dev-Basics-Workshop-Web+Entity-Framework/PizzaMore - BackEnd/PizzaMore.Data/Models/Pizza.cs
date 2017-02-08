namespace PizzaMore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Pizza
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Recipe { get; set; }

        public string ImageUrl { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }

        public int OwnerId { get; set; }

        [ForeignKey("OwnerId")]
        public virtual User Owner { get; set; }
    }
}