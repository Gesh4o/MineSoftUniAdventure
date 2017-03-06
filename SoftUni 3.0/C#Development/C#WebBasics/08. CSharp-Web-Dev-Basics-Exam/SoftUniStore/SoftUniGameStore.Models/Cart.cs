namespace SoftUniGameStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Cart
    {
        public Cart()
        {
            this.Games = new HashSet<Game>();
        }

        public int Id { get; set; }

        public string SessionId { get; set; }

        [ForeignKey("User")]
        public int? UserId { get; set; }
        
        public virtual User User { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
