namespace MassEffect.Engine.Factories
{
    using System;

    using MassEffect.GameObjects.Locations;
    using MassEffect.GameObjects.Ships;
    using MassEffect.Interfaces;

    public class ShipFactory
    {
        public IStarship CreateShip(StarshipType type, string name, StarSystem location)
        {
            switch (type)
            {
                case StarshipType.Frigate:
                    Frigate frigate = new Frigate(name, location);
                    return frigate;
                case StarshipType.Cruiser:
                    Cruiser crusier = new Cruiser(name, location);
                    return crusier;
                case StarshipType.Dreadnought:
                    Dreadnought dreadnought = new Dreadnought(name, location);
                    return dreadnought;
                default:
                    throw new NotSupportedException("Starship type not supported.");
            }
        }
    }
}
