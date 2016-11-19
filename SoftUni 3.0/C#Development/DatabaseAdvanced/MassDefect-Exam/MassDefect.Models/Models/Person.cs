namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        public Person()
        {
            this.Anomalies = new HashSet<Anomaly>();
        }

        public Person(string name, Planet home) : this()
        {
            this.Name = name;
            this.HomePlanet = home;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int HomePlanetId { get; set; }

        [Required, ForeignKey("HomePlanetId")]
        public virtual Planet HomePlanet { get; set; }

        public virtual ICollection<Anomaly> Anomalies { get; set; }
    }
}
