namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Enhancements;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Cruiser : Starship
    {
        private const int HealthDefault = 100;
        private const int ShieldsDefault = 100;
        private const int DamageDefault = 50;
        private const double FuelDefault = 300;

        public Cruiser(string name, StarSystem location)
            : base(name, HealthDefault, DamageDefault, ShieldsDefault, FuelDefault, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new PenetrationShell(this.Damage);
        }
    }
}
