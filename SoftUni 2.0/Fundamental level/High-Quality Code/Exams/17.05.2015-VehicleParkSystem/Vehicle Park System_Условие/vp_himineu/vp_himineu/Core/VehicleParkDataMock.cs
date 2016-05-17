namespace VehicleParkSystem.Core
{
    using System;
    using System.Collections.Generic;

    using Moq;

    using VehicleParkSystem.Contracts;
    using VehicleParkSystem.Models.Vehicles;

    using Wintellect.PowerCollections;

    public class VehicleParkDataMock : IVehicleParkData
    {
        public VehicleParkDataMock(int numberOfSectors)
        {
            this.PlaceByVehicles = new Dictionary<IVehicle, string>();
            this.VehicleByPlace = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlates = new Dictionary<string, IVehicle>();
            this.EntryDateTimesByVehicle = new Dictionary<IVehicle, DateTime>();
            this.VehicleByOwners = new MultiDictionary<string, IVehicle>(false);
            this.Sectors = new int[numberOfSectors];

            this.Setup();
        }

        public Dictionary<IVehicle, string> PlaceByVehicles { get; set; }

        public int[] Sectors { get; set; }

        public Dictionary<IVehicle, DateTime> EntryDateTimesByVehicle { get; set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlates { get; set; }

        public MultiDictionary<string, IVehicle> VehicleByOwners { get; set; }

        public Dictionary<string, IVehicle> VehicleByPlace { get; set; }

        private void Setup()
        {
            var mock = new Mock<IVehicleParkData>();

            ////mock.Setup(v => v.PlaceByVehicles[It.IsAny<IVehicle>()]).Returns("(0,1)");
            ////mock.Setup(v => v.EntryDateTimesByVehicle[It.IsAny<IVehicle>()]);

            string peshoOwner = "Pesho";
            string goshoOwner = "Gosho";
            string toshoOwner = "Tosho";
            string emoOwner = "Emo";

            var firstCar = new Car("CA0000AH", peshoOwner, 2);
            var secondCar = new Car("CA0001AH", goshoOwner, 2);

            var firstTruck = new Truck("TA0000AH", goshoOwner, 2);
            var secondTruck = new Truck("TA0001AH", toshoOwner, 3);

            var firstMotorbike = new Motorbike("MA0000AH", goshoOwner, 4);
            var secondMotorbike = new Motorbike("MA0001AH", emoOwner, 1);

            this.VehiclesByLicensePlates.Add(firstCar.LicensePlate, firstCar);
            this.VehiclesByLicensePlates.Add(secondCar.LicensePlate, secondCar);

            this.VehiclesByLicensePlates.Add(firstTruck.LicensePlate, firstTruck);
            this.VehiclesByLicensePlates.Add(secondTruck.LicensePlate, secondTruck);

            this.VehiclesByLicensePlates.Add(firstMotorbike.Owner, firstMotorbike);
            this.VehiclesByLicensePlates.Add(secondMotorbike.Owner, secondMotorbike);

            // Initializing vehicle per owner data.
            this.VehicleByOwners.Add(firstCar.Owner, firstCar);
            this.VehicleByOwners.Add(secondCar.Owner, secondCar);

            this.VehicleByOwners.Add(firstTruck.Owner, firstTruck);
            this.VehicleByOwners.Add(secondTruck.Owner, secondTruck);

            this.VehicleByOwners.Add(firstMotorbike.Owner, firstMotorbike);
            this.VehicleByOwners.Add(secondMotorbike.Owner, secondMotorbike);

            // By place

            this.VehicleByPlace.Add("(0,0)", firstCar);
            this.VehicleByPlace.Add("(0,1)", secondCar);

            this.VehicleByPlace.Add("(0,2)", firstTruck);
            this.VehicleByPlace.Add("(0,3)", secondTruck);

            this.VehicleByPlace.Add("(0,4)", firstMotorbike);
            this.VehicleByPlace.Add("(0,5)", secondMotorbike);

            this.PlaceByVehicles.Add(firstCar, "(0,0)");
            this.PlaceByVehicles.Add(secondCar, "(0,1)");

            this.PlaceByVehicles.Add(firstTruck, "(0,2)");
            this.PlaceByVehicles.Add(secondTruck, "(0,3)");

            this.PlaceByVehicles.Add(firstMotorbike, "(0,4)");
            this.PlaceByVehicles.Add(secondMotorbike, "(0,5)");


        }
    }
}
