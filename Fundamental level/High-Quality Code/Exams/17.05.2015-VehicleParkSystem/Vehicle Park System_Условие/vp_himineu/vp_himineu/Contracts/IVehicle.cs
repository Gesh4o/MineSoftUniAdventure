namespace VehicleParkSystem.Contracts
{
    public interface IVehicle
    {
        string LicensePlate { get; }

        decimal OvertimeRate { get; }

        string Owner { get; }

        decimal RegularRate { get; }

        int ReservedHours { get; }
    }
}