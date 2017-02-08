namespace PizzaMore.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    public class Session
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public override string ToString()
        {
            return $"{this.Id}\t{this.UserId}";
        }
    }
}
