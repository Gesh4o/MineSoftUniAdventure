namespace VehicleParkSystem.Core
{
    using System;
    using System.Globalization;

    using VehicleParkSystem.Contracts;
    using VehicleParkSystem.Infrastructure;
    using VehicleParkSystem.Models.Vehicles;

    public class CommandDispatcher
    {
        public VehiclePark VehiclePark { get; set; }

        public string Execute(ICommand command)
        {
            if (command.ActionName != "SetupPark" && this.VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }

            switch (command.ActionName)
            {
                case "SetupPark":

                    this.VehiclePark = new VehiclePark(
                       int.Parse(command.Parameters["sectors"]),
                       int.Parse(command.Parameters["placesPerSector"]),
                       new VehicleParkData(int.Parse(command.Parameters["sectors"])));

                    // ToDo: Check if adding one sector is a bug.
                    return "Vehicle park created";
                case "Park":
                    switch (command.Parameters["type"])
                    {
                        case "car":
                            return
                                this.VehiclePark.InsertCar(
                                    new Car(
                                        command.Parameters["licensePlate"], 
                                        command.Parameters["owner"], 
                                        int.Parse(command.Parameters["hours"])), 
                                    int.Parse(command.Parameters["sector"]), 
                                    int.Parse(command.Parameters["place"]), 
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                                    // ToDo: Check why this dateTimeStyle is set.
                        case "motorbike":
                            return
                                this.VehiclePark.InsertMotorbike(
                                    new Motorbike(
                                        command.Parameters["licensePlate"], 
                                        command.Parameters["owner"], 
                                        int.Parse(command.Parameters["hours"])), 
                                    int.Parse(command.Parameters["sector"]), 
                                    int.Parse(command.Parameters["place"]), 
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));

                        case "truck":
                            return
                                this.VehiclePark.InsertTruck(
                                    new Truck(
                                        command.Parameters["licensePlate"], 
                                        command.Parameters["owner"], 
                                        int.Parse(command.Parameters["hours"])), 
                                    int.Parse(command.Parameters["sector"]), 
                                    int.Parse(command.Parameters["place"]), 
                                    DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind));
                        default:
                            Console.WriteLine("Vehicle type not recognized!");
                            break;
                    }

                    break;
                case "Exit":
                    string exitResult = this.VehiclePark.ExitVehicle(
                        command.Parameters["licensePlate"],
                        DateTime.Parse(command.Parameters["time"], null, DateTimeStyles.RoundtripKind),
                        decimal.Parse(command.Parameters["paid"]));

                    return exitResult;
                case "Status":
                    string statusResult = this.VehiclePark.GetStatus();

                    return statusResult;
                case "FindVehicle":
                    string findVehicleResult = this.VehiclePark.FindVehicle(command.Parameters["licensePlate"]);

                    return findVehicleResult;
                case "VehiclesByOwner":
                    string vehiclesByOwner = this.VehiclePark.FindVehiclesByOwner(command.Parameters["owner"]);

                    return vehiclesByOwner;
                default:
                    throw new IndexOutOfRangeException("Invalid command.");
            }

            return string.Empty;
        }
    }
}