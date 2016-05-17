namespace VehicleParkSystem.Contracts
{
    using System;

    using VehicleParkSystem.Models.Vehicles;

    // TODO: Documente esta contrato
    public interface IVehiclePark
    {
        // TODO: Documentar esse método
        string ExitVehicle(string leavingVehicleLicensePlate, DateTime timeWhenLeaving, decimal paid);

        // TODO: Documentar esse método
        string FindVehicle(string searchedLicensePlate);

        // TODO: Documentar esse método
        string FindVehiclesByOwner(string owner);

        // TODO: Documentar esse método
        string GetStatus();

        // TODO: Documentar esse método
        string InsertCar(Car car, int sector, int placeNumber, DateTime arrivalDateTime);

        // TODO: Documentar esse método
        string InsertMotorbike(Motorbike motorbike, int sector, int placeNumber, DateTime startTime);

        // TODO: Documentar esse método
        string InsertTruck(Truck truck, int sector, int placeNumber, DateTime startTime);
    }
}
