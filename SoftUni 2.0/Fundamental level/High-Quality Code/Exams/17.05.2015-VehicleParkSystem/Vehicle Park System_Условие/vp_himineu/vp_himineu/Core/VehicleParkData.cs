namespace VehicleParkSystem.Core
{
    using System;
    using System.Collections.Generic;

    using VehicleParkSystem.Contracts;

    using Wintellect.PowerCollections;

    public class VehicleParkData : IVehicleParkData
    {
        public VehicleParkData(int numberOfSectors)
        {
            this.PlaceByVehicles = new Dictionary<IVehicle, string>();
            this.VehicleByPlace = new Dictionary<string, IVehicle>();
            this.VehiclesByLicensePlates = new Dictionary<string, IVehicle>();
            this.EntryDateTimesByVehicle = new Dictionary<IVehicle, DateTime>();
            this.VehicleByOwners = new MultiDictionary<string, IVehicle>(false);
            this.Sectors = new int[numberOfSectors];
        }

        public Dictionary<IVehicle, string> PlaceByVehicles { get; set; }

        public int[] Sectors { get; set; }

        public Dictionary<IVehicle, DateTime> EntryDateTimesByVehicle { get; set; }

        public Dictionary<string, IVehicle> VehiclesByLicensePlates { get; set; }

        public MultiDictionary<string, IVehicle> VehicleByOwners { get; set; }

        public Dictionary<string, IVehicle> VehicleByPlace { get; set; }
    }
}
