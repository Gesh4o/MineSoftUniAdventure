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
    using Projectiles;

    public class Frigate : Starship
    {
        private const int HealthDefault = 60;
        private const int ShieldsDefault = 50;
        private const int DamageDefault = 30;
        private const double FuelDefault = 220;
        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(name, HealthDefault, DamageDefault, ShieldsDefault, FuelDefault, location) 
        {
            this.projectilesFired = 0;
        }

        public override IProjectile ProduceAttack()
        {
            projectilesFired++;
            return new ShieldReaver(this.Damage);

        }

        public override string ToString()
        {
            if (this.Health <=0)
            {
                return base.ToString();
            }

            string output = base.ToString() + string.Format("\n-Projectiles fired: {0}", projectilesFired);
            return output;
        }
    }
}
