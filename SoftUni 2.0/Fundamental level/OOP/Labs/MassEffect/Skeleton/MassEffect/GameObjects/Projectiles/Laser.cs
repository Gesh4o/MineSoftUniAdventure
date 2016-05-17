namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
                
        }
        public override void Hit(IStarship ship)
        {
            ship.Shields -= this.Damage;
            if (ship.Shields <0)
            {
                ship.Health += ship.Shields;
            }
        }
    }
}
