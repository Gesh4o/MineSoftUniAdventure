using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MassDefect.Models.Models
{
    public class Planet
    {
        public Planet()
        {
            this.OriginAnomalies = new HashSet<Anomaly>();
            this.TeleportAnomalies = new HashSet<Anomaly>();
        }

        public Planet(string name, Star star, SolarSystem solarSystem) : this()
        {
            this.Name = name;
            this.Star = star;
            this.SolarSystem = solarSystem;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int StarId { get; set; }

        [Required, ForeignKey("StarId")]
        public virtual  Star Star { get; set; }

        public int SolarSystemId { get; set; }

        [Required, ForeignKey("SolarSystemId")]
        public virtual SolarSystem SolarSystem { get; set; }

        [InverseProperty("OriginPlanet")]
        public virtual ICollection<Anomaly> OriginAnomalies { get; set; }

        [InverseProperty("TeleportPlanet")]
        public virtual ICollection<Anomaly> TeleportAnomalies { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
