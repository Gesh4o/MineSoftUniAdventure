namespace TheSlum.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Injection : Bonus
    {
        public Injection(string id, int healthEffect = 200,int defenseEffect=0, int attackEffect=0)
            :base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 3;
            this.HasTimedOut = false;
            this.Timeout = 3;
        }
    }
}
