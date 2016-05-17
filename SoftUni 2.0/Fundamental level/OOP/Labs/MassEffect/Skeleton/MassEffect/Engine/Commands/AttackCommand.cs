namespace MassEffect.Engine.Commands
{
    using System;
    using MassEffect.Interfaces;
    using System.Linq;
    using Exceptions;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string attackingShipName = commandArgs[1];
            string defendingShipName = commandArgs[2];

            IStarship attackerShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == attackingShipName);
            IStarship defenderShip = this.GameEngine.Starships.FirstOrDefault(s => s.Name == defendingShipName);

            this.ProcessStarshipBattle(attackerShip, defenderShip);


        }

        private void ProcessStarshipBattle(IStarship attackerShip, IStarship defenderShip)
        {
            if (attackerShip.Health <= 0 || defenderShip.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
            if (attackerShip.Location.Name != defenderShip.Location.Name)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            IProjectile attack = attackerShip.ProduceAttack();
            defenderShip.RespondToAttack(attack);

            Console.WriteLine(string.Format(Messages.ShipAttacked, attackerShip.Name, defenderShip.Name));
            if (defenderShip.Shields < 0) 
            {
                defenderShip.Shields = 0;
            }
            if (defenderShip.Health <= 0)
            {
                defenderShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, defenderShip.Name);
            }
        }
    }
}
