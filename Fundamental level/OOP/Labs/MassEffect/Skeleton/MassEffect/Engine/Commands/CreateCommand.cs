namespace MassEffect.Engine.Commands
{
    using System;
    using MassEffect.Interfaces;
    using Factories;
    using System.Linq;
    using Exceptions;
    using GameObjects.Ships;
    using GameObjects;
    using GameObjects.Locations;
    using GameObjects.Enhancements;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            string shipType = commandArgs[1];
            string shipName = commandArgs[2];
            string shipLocation = commandArgs[3];

            bool isShipCreatedAlready = GameEngine.Starships.Any(s => s.Name == shipName);
            if (isShipCreatedAlready)
            {
                throw new ShipException(Messages.DuplicateShipName);
            }

            StarshipType type = (StarshipType)Enum.Parse(typeof(StarshipType), shipType);
            StarSystem location = GameEngine.Galaxy.GetStarSystemByName(shipLocation);

            IStarship starship = GameEngine.ShipFactory.CreateShip(type, shipName, location);
            GameEngine.Starships.Add(starship);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                EnhancementType enhancementType = (EnhancementType)Enum.Parse(typeof(EnhancementType), commandArgs[i]);
                Enhancement enhancement = GameEngine.EnhancementFactory.Create(enhancementType);
                starship.AddEnhancement(enhancement);
            }

            Console.WriteLine(string.Format(Messages.CreatedShip,shipType,shipName));
        }
    }
}
