namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Star
    {
        public Star()
        {
            this.Planets = new HashSet<Planet>();
        }

        public Star(string name, SolarSystem solarSystem) : this()
        {
            this.Name = name;
            this.SolarSystem = solarSystem;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? SolarSystemId { get; set; }

        [ForeignKey("SolarSystemId")]
        public virtual SolarSystem SolarSystem { get; set; }

        public virtual ICollection<Planet> Planets { get; set; }
    }
}
