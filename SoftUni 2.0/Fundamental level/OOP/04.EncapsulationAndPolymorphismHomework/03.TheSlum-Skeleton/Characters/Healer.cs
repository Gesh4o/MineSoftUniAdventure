namespace TheSlum.Characters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using TheSlum.Interfaces;

    class Healer : Character, IHeal
    {
        public Healer(string id, int x, int y, int healthPoints, int defensePoints, int healPoints, Team team, int range)
            :base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healPoints;
        }
        public int HealingPoints { get; set; }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var target = targetsList.OrderBy(t => t.HealthPoints)
                .FirstOrDefault(t => t.Team == this.Team && t.IsAlive);
            return target;
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveItemEffects(item);
        }

        public override string ToString()
        {
            string baseString = base.ToString();
            string result = baseString + string.Format(" Heal: {0}", this.HealingPoints);
            return result;
        }
    }
}
