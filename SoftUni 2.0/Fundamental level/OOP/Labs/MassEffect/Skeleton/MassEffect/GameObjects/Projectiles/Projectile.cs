namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Projectile : IProjectile
    {
        public Projectile(int damage)
        {
            this.Damage = damage;
        }
        public int Damage { get; set; }

        public abstract void Hit(IStarship ship);
    }
}
