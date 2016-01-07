using System;

namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enhancements;
    using Locations;

    public abstract class Starship : IStarship
    {
        private IList<Enhancement> enhancements;
        public Starship(string name, int health, int damage, int shields, double fuel, StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Damage = damage;
            this.Shields = shields;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }
        public int Damage { get; set; }

        public IEnumerable<Enhancement> Enhancements { get { return this.enhancements; } }

        public double Fuel { get; set; }

        public int Health { get; set; }

        public StarSystem Location { get; set; }

        public string Name { get; set; }

        public int Shields { get; set; }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.Shields += enhancement.ShieldBonus;
            this.Damage += enhancement.DamageBonus;
            this.Fuel += enhancement.FuelBonus;

            enhancements.Add(enhancement);
        }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder shipInfo = new StringBuilder();
            shipInfo.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));
            if (this.Health <=0)
            {
                shipInfo.Append("(Destroyed)");
            }
            else
            {
                shipInfo.AppendLine(string.Format("-Location: {0}",this.Location.Name));
                shipInfo.AppendLine(string.Format("-Health: {0}", this.Health));
                shipInfo.AppendLine(string.Format("-Shields: {0}", this.Shields));
                shipInfo.AppendLine(string.Format("-Damage: {0}", this.Damage));
                shipInfo.AppendLine(string.Format("-Fuel: {0:f1}", this.Fuel));
                string enhancements = string.Join(", ", this.enhancements.Select(e => e.Name));
                shipInfo.Append(string.Format("-Enhancements: {0}", this.enhancements.Count == 0?"N/A":enhancements));
            }

            return shipInfo.ToString();
        }
    }
}
