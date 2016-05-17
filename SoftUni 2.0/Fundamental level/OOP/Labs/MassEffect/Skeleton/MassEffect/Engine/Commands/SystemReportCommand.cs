namespace MassEffect.Engine.Commands
{
    using Interfaces;
    using GameObjects.Locations;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {

        }
        public override void Execute(string[] commandArgs)
        {
            StringBuilder output = new StringBuilder();
            string starSystemName = commandArgs[1];

            IEnumerable<IStarship> intactShips = this.GameEngine.Starships.Where(s => s.Location.Name == starSystemName)
                .Where(s => s.Health > 0)
                .ToList();
            intactShips = intactShips.OrderByDescending(s => s.Health).ThenByDescending(s => s.Shields).ToList();

            IEnumerable<IStarship> destroyedShips = this.GameEngine.Starships.Where(s => s.Location.Name == starSystemName)
                .Where(s => s.Health <= 0)
                .ToList();

            destroyedShips = destroyedShips.OrderBy(s => s.Name).ToList();

            output.AppendLine("Intact ships:");
            output.AppendLine(intactShips.Any() ? string.Join("\n", intactShips) : "N/A");

            output.AppendLine("Destroyed ships:");
            output.Append(destroyedShips.Any() ? string.Join("\n", destroyedShips) : "N/A");

            Console.WriteLine(output.ToString());


        }
    }
}
