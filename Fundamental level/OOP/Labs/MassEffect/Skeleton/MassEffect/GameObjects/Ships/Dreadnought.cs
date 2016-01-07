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

    public class Dreadnought : Starship
    {
        private const int HealthDefault = 200;
        private const int ShieldsDefault = 300;
        private const int DamageDefault = 150;
        private const double FuelDefault = 700;

        public Dreadnought(string name, StarSystem location)
            : base(name, HealthDefault, DamageDefault, ShieldsDefault, FuelDefault, location)
        {

        }

        public override IProjectile ProduceAttack()
        {
            return new Laser(this.Damage + this.Shields / 2);
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;
            base.RespondToAttack(attack);
            this.Shields -=50;
        }
    }
}
