﻿namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class PenetrationShell : Projectile
    {
        public PenetrationShell(int damage)
            : base(damage)
        {

        }
        public override void Hit(IStarship ship)
        {
            ship.Health -= this.Damage;
        }
    }
}