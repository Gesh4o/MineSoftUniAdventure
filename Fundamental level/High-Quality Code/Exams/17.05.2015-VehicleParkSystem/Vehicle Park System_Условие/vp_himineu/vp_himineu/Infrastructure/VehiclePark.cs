namespace VehicleParkSystem.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using VehicleParkSystem.Contracts;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Models.Vehicles;

    public class VehiclePark : IVehiclePark
    {
        private const string DataIsValidMessage = "Data is valid.";

        private IVehicleParkData vehicleParkData;

        private Layout layout;

        public VehiclePark(int numberOfSectors, int placesPerSector, IVehicleParkData vehicleParkData)
        {
            this.layout = new Layout(numberOfSectors, placesPerSector);
            this.vehicleParkData = vehicleParkData;
        }

        public string ExitVehicle(string leavingVehicleLicensePlate, DateTime timeWhenLeaving, decimal moneyPaid)
        {
            IVehicle leavingVehicle;
            if (this.vehicleParkData.VehiclesByLicensePlates.ContainsKey(leavingVehicleLicensePlate))
            {
                leavingVehicle = this.vehicleParkData.VehiclesByLicensePlates[leavingVehicleLicensePlate];
            }
            else
            {
                return $"There is no vehicle with license plate {leavingVehicleLicensePlate} in the park";
            }

            var timeWhenEntered = this.vehicleParkData.EntryDateTimesByVehicle[leavingVehicle];
            int spendedTime = (int)Math.Round((timeWhenLeaving - timeWhenEntered).TotalHours);
            var ticket = this.BuildTicket(moneyPaid, leavingVehicle, spendedTime);

            this.RemoveVehicleFromParkData(leavingVehicle);

            return ticket;
        }

        public string FindVehicle(string searchedLicensePlate)
        {
            IVehicle vehicle;
            if (this.vehicleParkData.VehiclesByLicensePlates.ContainsKey(searchedLicensePlate))
            {
                vehicle = this.vehicleParkData.VehiclesByLicensePlates[searchedLicensePlate];
            }
            else
            {
                return $"There is no vehicle with license plate {searchedLicensePlate} in the park";
            }

            string vehicleInformation = this.Input(new[] { vehicle });
            return vehicleInformation;
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!this.vehicleParkData.VehicleByOwners.ContainsKey(owner))
            {
                return $"No vehicles by {owner}";
            }

            var allVehiclesByOwner = this.vehicleParkData.VehicleByOwners[owner]
                    .OrderBy(v => this.vehicleParkData.EntryDateTimesByVehicle[v])
                    .ThenBy(v => v.LicensePlate);

            return string.Join(Environment.NewLine, this.Input(allVehiclesByOwner));
        }

        public string GetStatus()
        {
            var places =
                this.vehicleParkData.Sectors.Select(
                    (placesCount, sector) =>
                    string.Format(
                        "Sector {0}: {1} / {2} ({3}% full)",
                        sector + 1,
                        placesCount,
                        this.layout.OccupiedPlacesInSector,
                        Math.Round(((double)placesCount / this.layout.OccupiedPlacesInSector) * 100)));

            return string.Join(Environment.NewLine, places);
        }

        // Only if you look CLOSELY you will notice that these 3 method below may be refactored to 1 method.
        public string InsertCar(Car car, int sector, int place, DateTime arrivalDateTime)
        {
            string dataValidationMessage = this.ValidateVehicleInformation(car, sector, place);

            if (DataIsValidMessage != dataValidationMessage)
            {
                return dataValidationMessage;
            }

            this.AddVehicleToParkData(car, sector, place, arrivalDateTime);

            string result = this.SuccessfulAddMessage(car, sector, place);
            return result;
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime arrivalDateTime)
        {
            string dataValidationMessage = this.ValidateVehicleInformation(motorbike, sector, place);

            if (DataIsValidMessage != dataValidationMessage)
            {
                return dataValidationMessage;
            }

            this.AddVehicleToParkData(motorbike, sector, place, arrivalDateTime);

            string result = this.SuccessfulAddMessage(motorbike, sector, place);
            return result;
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime arrivalDateTime)
        {
            string dataValidationMessage = this.ValidateVehicleInformation(truck, sector, place);

            if (DataIsValidMessage != dataValidationMessage)
            {
                return dataValidationMessage;
            }

            this.AddVehicleToParkData(truck, sector, place, arrivalDateTime);

            string result = this.SuccessfulAddMessage(truck, sector, place);
            return result;
        }

        private string ValidateVehicleInformation(IVehicle vehicle, int sector, int place)
        {
            if (sector > this.layout.SectorsCount)
            {
                return $"There is no sector {sector} in the park";
            }

            if (place > this.layout.OccupiedPlacesInSector)
            {
                return $"There is no place {place} in sector {sector}";
            }

            if (this.vehicleParkData.VehicleByPlace.ContainsKey($"({sector},{place})"))
            {
                return $"The place ({sector},{place}) is occupied";
            }

            if (this.vehicleParkData.VehiclesByLicensePlates.ContainsKey(vehicle.LicensePlate))
            {
                return string.Format(
                    "There is already a vehicle with license plate {0} in the park",
                    vehicle.LicensePlate);
            }

            return DataIsValidMessage;
        }

        private string SuccessfulAddMessage(IVehicle vehicle, int sector, int place)
        {
            return string.Format("{0} parked successfully at place ({1},{2})", vehicle.GetType().Name, sector, place);
        }

        private string Input(IEnumerable<IVehicle> vechicles)
        {
            return string.Join(
                Environment.NewLine,
                vechicles.Select(
                    vehicle =>
                    string.Format(
                        "{0}{1}Parked at {2}",
                        vehicle.ToString(),
                        Environment.NewLine,
                        this.vehicleParkData.PlaceByVehicles[vehicle])));
        }

        private void AddVehicleToParkData(IVehicle vehicle, int sector, int place, DateTime arrivalDateTime)
        {
            this.vehicleParkData.PlaceByVehicles[vehicle] = $"({sector},{place})";

            this.vehicleParkData.VehicleByPlace[$"({sector},{place})"] = vehicle;
            this.vehicleParkData.VehiclesByLicensePlates[vehicle.LicensePlate] = vehicle;
            this.vehicleParkData.EntryDateTimesByVehicle[vehicle] = arrivalDateTime;
            this.vehicleParkData.VehicleByOwners[vehicle.Owner].Add(vehicle);
            this.vehicleParkData.Sectors[sector - 1]++;
        }

        private void RemoveVehicleFromParkData(IVehicle leavingVehicle)
        {
            // ToDo: This may have bugs too.
            int sector =
                int.Parse(
                    this.vehicleParkData.PlaceByVehicles[leavingVehicle].Split(
                        new[] { "(", ",", ")" },
                        StringSplitOptions.RemoveEmptyEntries)[0]);

            this.vehicleParkData.VehicleByPlace.Remove(this.vehicleParkData.PlaceByVehicles[leavingVehicle]);
            this.vehicleParkData.PlaceByVehicles.Remove(leavingVehicle);

            this.vehicleParkData.VehiclesByLicensePlates.Remove(leavingVehicle.LicensePlate);
            this.vehicleParkData.EntryDateTimesByVehicle.Remove(leavingVehicle);

            this.vehicleParkData.VehicleByOwners.Remove(leavingVehicle.Owner, leavingVehicle);
            this.vehicleParkData.Sectors[sector - 1]--;
        }

        private string BuildTicket(decimal moneyPaid, IVehicle leavingVehicle, int spendedTime)
        {
            decimal overTimeRate = 0;
            if (spendedTime > leavingVehicle.ReservedHours)
            {
                overTimeRate = (spendedTime - leavingVehicle.ReservedHours) * leavingVehicle.OvertimeRate;
            }

            // ToDo: If bug is found, search here.
            decimal overtimePrice = 0;
            if (spendedTime > leavingVehicle.ReservedHours)
            {
                overtimePrice = (spendedTime - leavingVehicle.ReservedHours) * leavingVehicle.OvertimeRate;
            }

            decimal totalPrice = leavingVehicle.ReservedHours * leavingVehicle.RegularRate + overtimePrice;

            // PERFORMANCE: Building ticket process was making several identical operation which may cause huge performance slow
            // when building multiple tickets(e.g. multiple times calculating the total price).
            string borders = new string('*', 20);
            string separator = new string('-', 20);
            var ticket = this.BuildTicketLetter(moneyPaid, leavingVehicle, borders, overTimeRate, separator, totalPrice);

            return ticket;
        }

        private string BuildTicketLetter(
            decimal moneyPaid,
            IVehicle leavingVehicle,
            string borders,
            decimal overTimeRate,
            string separator,
            decimal totalPrice)
        {
            var ticket = new StringBuilder();
            ticket.AppendLine(borders);

            ticket.AppendFormat("{0}", leavingVehicle).AppendLine();
            ticket.AppendFormat("at place {0}", this.vehicleParkData.PlaceByVehicles[leavingVehicle]).AppendLine();
            ticket.AppendFormat("Rate: ${0:F2}", leavingVehicle.ReservedHours * leavingVehicle.RegularRate).AppendLine();
            ticket.AppendFormat("Overtime rate: ${0:F2}", overTimeRate).AppendLine();

            ticket.AppendLine(separator);

            ticket.AppendFormat("Total: ${0:F2}", totalPrice).AppendLine();
            ticket.AppendFormat("Paid: ${0:F2}", moneyPaid).AppendLine();
            ticket.AppendFormat("Change: ${0:F2}", moneyPaid - totalPrice).AppendLine();

            ticket.Append(borders);

            return ticket.ToString();
        }
    }
}
