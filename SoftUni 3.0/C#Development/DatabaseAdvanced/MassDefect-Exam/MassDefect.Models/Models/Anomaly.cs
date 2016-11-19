namespace MassDefect.Models.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Anomaly
    {
        public Anomaly()
        {
            this.Victims = new HashSet<Person>();
        }

        public Anomaly(Planet origin, Planet teleport) : this()
        {
            this.OriginPlanet = origin;
            this.TeleportPlanet = teleport;
        }

        public int Id { get; set; }

        public int? OriginPlanetId { get; set; }

        [ForeignKey("OriginPlanetId")]
        public virtual Planet OriginPlanet { get; set; }

        public int? TeleportPlanetId { get; set; }

        [ForeignKey("TeleportPlanetId")]
        public virtual Planet TeleportPlanet { get; set; }

        public virtual ICollection<Person> Victims { get; set; }
    }
}
