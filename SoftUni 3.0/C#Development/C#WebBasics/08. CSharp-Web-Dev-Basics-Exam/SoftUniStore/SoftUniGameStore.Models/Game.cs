namespace SoftUniGameStore.Models
{
    using System;
    using System.Collections.Generic;

    public class Game
    {
        public Game()
        {
            this.Users = new HashSet<User>();
            this.Carts = new HashSet<Cart>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageThumbnail { get; set; }

        public string VideoUrl { get; set; }

        public double Size { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
    }
}
