namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class SolarSystem
    {
        public SolarSystem()
        {
            this.Planets = new HashSet<Planet>();
            this.Stars = new HashSet<Star>();
        }

        public SolarSystem(string name): this()
        {
            this.Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        public virtual ICollection<Planet> Planets { get; set; }

        public virtual ICollection<Star> Stars { get; set; }
    }
}
