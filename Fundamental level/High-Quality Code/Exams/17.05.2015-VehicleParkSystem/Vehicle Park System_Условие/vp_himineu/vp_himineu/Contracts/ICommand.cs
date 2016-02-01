namespace VehicleParkSystem.Contracts
{
    using System.Collections.Generic;

    public interface ICommand
    {
        string ActionName { get; }

        IDictionary<string, string> Parameters { get; }
    }
}
