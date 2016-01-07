namespace MassEffect.Engine.Commands
{
    using System;
    using MassEffect.Interfaces;
    using System.Linq;
    using System.Text;
    using GameObjects.Ships;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            Console.WriteLine(ship.ToString());
        }
    }
}
