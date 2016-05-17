namespace MassEffect.Engine.Commands
{
    using System;
    using MassEffect.Interfaces;
    using System.Linq;
    using GameObjects.Locations;
    using Exceptions;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipName = commandArgs[1];
            IStarship ship = GameEngine.Starships.FirstOrDefault(s => s.Name == shipName);
            StarSystem currentLocation = ship.Location;

            string destinationName = commandArgs[2];
            StarSystem destination = GameEngine.Galaxy.StarSystems.FirstOrDefault(d => d.Name == destinationName);

            if (ship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
            if (currentLocation.Name == destination.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem,currentLocation.Name));
            }

            GameEngine.Galaxy.TravelTo(ship, destination);

            Console.WriteLine(string.Format(Messages.ShipTraveled, ship.Name, currentLocation.Name, destination.Name));
        }
    }
}
