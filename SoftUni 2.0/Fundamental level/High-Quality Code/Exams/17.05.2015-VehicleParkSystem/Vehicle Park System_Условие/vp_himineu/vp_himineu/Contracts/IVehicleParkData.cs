namespace VehicleParkSystem.Contracts
{
    using System;
    using System.Collections.Generic;

    using Wintellect.PowerCollections;

    public interface IVehicleParkData
    {
        Dictionary<IVehicle, string> PlaceByVehicles { get; set; }

        int[] Sectors { get; set; }

        Dictionary<IVehicle, DateTime> EntryDateTimesByVehicle { get; set; }

        Dictionary<string, IVehicle> VehiclesByLicensePlates { get; set; }

        MultiDictionary<string, IVehicle> VehicleByOwners { get; set; }

        Dictionary<string, IVehicle> VehicleByPlace { get; set; }
    }
}
