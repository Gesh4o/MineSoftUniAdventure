namespace _02.CreateUser.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        public Town()
        {
            this.BornPeople = new HashSet<User>();
            this.LivingPeople = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Country { get; set; }

        [InverseProperty("BornTown")]
        public ICollection<User> BornPeople { get; set; }

        [InverseProperty("LivingTown")]
        public ICollection<User> LivingPeople { get; set; }
    }
}