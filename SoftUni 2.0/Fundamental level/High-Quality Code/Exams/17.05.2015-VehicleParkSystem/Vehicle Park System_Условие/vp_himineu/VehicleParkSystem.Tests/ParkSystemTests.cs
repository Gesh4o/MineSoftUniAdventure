namespace VehicleParkSystem.Tests
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    using VehicleParkSystem.Contracts;
    using VehicleParkSystem.Core;
    using VehicleParkSystem.Infrastructure;
    using VehicleParkSystem.Models.Vehicles;

    [TestClass]
    public class ParkSystemTests
    {
        private const int DefaultParkSectors = 3;

        private const int DefaultParkPlacesPerSector = 5;

        private const string DefaultDateTimeToParse = "2015-05-04T10:30:00.0000000";

        private IVehiclePark vehiclePark;

        private IVehicle vehicle;

        private DateTime arrivalDateTime;

        private const string DefaultLicensePlate = "CA4444AH";

        private const string DefaultOwner = "Pesho";

        [TestInitialize]
        public void InitializeVehiclePark()
        {
            this.vehiclePark = new VehiclePark(DefaultParkSectors, DefaultParkPlacesPerSector, new VehicleParkData(DefaultParkSectors));

            this.arrivalDateTime = DateTime.Parse(DefaultDateTimeToParse, null, DateTimeStyles.RoundtripKind);
        }

        [TestCleanup]
        public void ResetVehicle()
        {
            this.vehicle = null;
        }

        [TestMethod]
        public void Park_Car_ShouldReturnSuccessfulMessage()
        {
            int sector = 1;
            int place = 2;
            int hours = 2;

            this.vehicle = new Car("CA4444AH", "Pesho", hours);
            string actualResult = this.vehiclePark.InsertCar((this.vehicle as Car), sector, place, this.arrivalDateTime);

            string expectedResult = string.Format(
                "{0} parked successfully at place ({1},{2})", this.vehicle.GetType().Name, sector, place);

            Assert.AreEqual(expectedResult, actualResult, "Car was not successfully parked.");
        }

        [TestMethod]
        public void Park_Motorbike_ShouldReturnSuccessfulMessage()
        {
            int sector = 1;
            int place = 2;
            int hours = 2;

            this.vehicle = new Motorbike("CA4444AH", "Pesho", hours);
            string actualResult = this.vehiclePark.InsertMotorbike((this.vehicle as Motorbike), sector, place, this.arrivalDateTime);

            string expectedResult = string.Format(
                "{0} parked successfully at place ({1},{2})", this.vehicle.GetType().Name, sector, place);

            Assert.AreEqual(expectedResult, actualResult, "Motorbike was not successfully parked.");
        }

        [TestMethod]
        public void Park_Truck_ShouldReturnSuccessfulMessage()
        {
            int sector= 1;
            int place = 2;
            int hours = 2;

            var actualResult = this.InsertTruck(sector, place, hours);

            string expectedResult = string.Format(
                "{0} parked successfully at place ({1},{2})", this.vehicle.GetType().Name, sector, place);

            Assert.AreEqual(expectedResult, actualResult, "Truck was not successfully parked.");
        }

        [TestMethod]
        public void Park_CarInNonExistingSector_ShouldReturnWarning()
        {
            int sector = 5;
            int place = 3;
            int hours = 2;

            this.vehicle = new Car(DefaultLicensePlate, DefaultOwner, hours);

            string actualResult = this.vehiclePark.InsertCar((Car)this.vehicle, sector, place, this.arrivalDateTime);

            string expectedResult = $"There is no sector {sector} in the park";

            Assert.AreEqual(expectedResult, actualResult, "Vehicle should not be parked in non-existing sector!");
        }

        [TestMethod]
        public void Park_CarInNonExistingPlaceInSector_ShouldReturnWarning()
        {
            int sector = 1;
            int place = 7;
            int hours = 2;

            this.vehicle = new Car(DefaultLicensePlate, DefaultOwner, hours);

            string actualResult = this.vehiclePark.InsertCar((Car)this.vehicle, sector, place, this.arrivalDateTime);

            string expectedResult = $"There is no place {place} in sector {sector}";

            Assert.AreEqual(expectedResult, actualResult, "Vehicle should not be parked in non-existing place in sector!");
        }

        [TestMethod]
        public void Park_CarInOccupiedPlaceInSector_ShouldReturnWarning()
        {
            int sector = 1;
            int place = 2;
            int hours = 2;

            this.vehicle = new Car(DefaultLicensePlate, DefaultOwner, hours);

            var newCar = new Car("AA1234BB",DefaultOwner, hours);

            this.vehiclePark.InsertCar((Car)this.vehicle, sector, place, this.arrivalDateTime);

            string actualResult = this.vehiclePark.InsertCar(
                newCar,
                sector,
                place,
                this.arrivalDateTime.AddHours(1));
                
            string expectedResult = $"The place ({sector},{place}) is occupied";

            Assert.AreEqual(expectedResult, actualResult, "Vehicle should not be parked in occupied place!");
        }

        [TestMethod]
        public void Park_CarWithExistingLicensePlateInPark_ShouldReturnWarning()
        {
            int sector = 1;
            int place = 2;
            int hours = 2;

            this.vehicle = new Car(DefaultLicensePlate, DefaultOwner, hours);

            var newCar = new Car(DefaultLicensePlate, DefaultOwner, hours);

            this.vehiclePark.InsertCar((Car)this.vehicle, sector, place, this.arrivalDateTime);

            string actualResult = this.vehiclePark.InsertCar(
                newCar,
                sector,
                place + 1,
                this.arrivalDateTime.AddHours(1));

            string expectedResult = $"There is already a vehicle with license plate {DefaultLicensePlate} in the park";

            Assert.AreEqual(expectedResult, actualResult, "Vehicle with matching license plate should not be parked!");
        }

        [TestMethod]
        public void Exit_TruckWithNoOverTime_ShouldReturnExpectedTicket()
        {
            int sector = 3;
            int place = 4;
            int hours = 1;
            decimal paid = 10M;

            this.InsertTruck(sector, place, hours);

            string actualTicket = this.vehiclePark.ExitVehicle(DefaultLicensePlate, this.arrivalDateTime.AddHours(hours), paid);

            string expectedTicked = this.BuildExpectedTicket(sector, place, hours, paid, 4.75M, 0);

            Assert.AreEqual(expectedTicked, actualTicket, "Ticket does not have proper format or value!");
        }

        [TestMethod]
        public void Exit_TruckWithOverTime_ShouldReturnExpectedTicket()
        {
            int sector = 3;
            int place = 4;
            int hours = 1;
            decimal paid = 15M;

            this.InsertTruck(sector, place, hours);

            string actualTicket = this.vehiclePark.ExitVehicle(DefaultLicensePlate, this.arrivalDateTime.AddHours(2*hours), paid);

            string expectedTicked = this.BuildExpectedTicket(sector, place, hours, paid, 4.75M, 6.20M);

            Assert.AreEqual(expectedTicked, actualTicket, "Ticket does not have proper format or value!");
        }

        [TestMethod]
        public void Exit_TruckWithInvalidLicensePlate_ShouldReturnWarning()
        {
            int sector = 3;
            int place = 4;
            int hours = 1;
            decimal paid = 15M;

            this.InsertTruck(sector, place, hours);

            string actualTicket = this.vehiclePark.ExitVehicle("AA1234BB", this.arrivalDateTime.AddHours(2 * hours), paid);

            string expectedMessage = $"There is no vehicle with license plate {"AA1234BB"} in the park";

            Assert.AreEqual(expectedMessage, actualTicket, "Cannot exit vehicle with non-existing license plate in data!");
        }

        [TestMethod]
        public void Status_EmptyVehiclePark_ShouldReturnExpectedStatus()
        {
            string actualMessage = this.vehiclePark.GetStatus();
            string expectedMessage =
                "Sector 1: 0 / 5 (0% full)\r\nSector 2: 0 / 5 (0% full)\r\nSector 3: 0 / 5 (0% full)";

            Assert.AreEqual(expectedMessage, actualMessage, "Invalid current status on vehicle park!");
        }

        [TestMethod]
        public void Status_NonEmptyVehiclePark_ShouldReturnExpectedStatus()
        {
            this.InsertTruck(1, 2, 3);
            string actualMessage = this.vehiclePark.GetStatus();
            string expectedMessage =
                "Sector 1: 1 / 5 (20% full)\r\nSector 2: 0 / 5 (0% full)\r\nSector 3: 0 / 5 (0% full)";

            Assert.AreEqual(expectedMessage, actualMessage, "Invalid current status on vehicle park!");
        }

        [TestMethod]
        public void GetVehicleByOwner_WhenMoreThanOneVehicleIsOnOWner_ShouldReturnAllVehicles()
        {
            int sector = 1;
            int place = 2;
            int hours = 2;

            this.vehicle = new Car(DefaultLicensePlate, DefaultOwner, hours);

            var newCar = new Car("AA1234BB", DefaultOwner, hours);

            this.vehiclePark.InsertCar((Car)this.vehicle, sector, place, this.arrivalDateTime);

            this.vehiclePark.InsertCar(newCar, sector, place +1, this.arrivalDateTime.AddHours(1));

            string actualResut = this.vehiclePark.FindVehiclesByOwner(DefaultOwner);

            IVehicle[] vehicles = new[] {this.vehicle, newCar};


            string expectedResult = string.Join(
                Environment.NewLine,
                vehicles.Select(
                    vehicle => string.Format("{0}{1}Parked at ({2},{3})", vehicle.ToString(), Environment.NewLine, sector, place++)));

            Assert.AreEqual(expectedResult, actualResut, "Vehicles were not presented in right format or with right information!");
        }

        [TestMethod]
        public void GetVehicleByOwner_WhenOwnerDoesNotHaveVehiclesInPark_ShouldWarning()
        {
            string actualResut = this.vehiclePark.FindVehiclesByOwner(DefaultOwner);

            string expectedResult = $"No vehicles by {DefaultOwner}";

            Assert.AreEqual(expectedResult, actualResut, "There should not be any vehicle by passed owner!");
        }

        [TestMethod]
        public void FindVehicle_AnExistingLicensePlate_ShouldReturnExpectedVehicle()
        {
            // var mockMOckedData = new Mock<VehicleParkDataMock>(DefaultParkSectors);

            var vehicleParkDataMock = new VehicleParkDataMock(DefaultParkSectors);

            var vehicleParkMocked = new VehiclePark(DefaultParkSectors, DefaultParkPlacesPerSector, vehicleParkDataMock);

            var actualResut = vehicleParkMocked.FindVehicle("CA0001AH");

            var expectedResult = "Car [CA0001AH], owned by Gosho\r\nParked at (0,1)";

            Assert.AreEqual(expectedResult, actualResut, "Did not return proper vehicle.");
        }

        [TestMethod]
        public void FindVehicle_AnNonExistingLicensePlate_ShouldReturnWarning()
        {
            var vehicleParkDataMock = new VehicleParkDataMock(DefaultParkSectors);

            var vehicleParkMocked = new VehiclePark(DefaultParkSectors, DefaultParkPlacesPerSector, vehicleParkDataMock);

            var actualResut = vehicleParkMocked.FindVehicle("CA0003AH");

            var expectedResult = "There is no vehicle with license plate CA0003AH in the park";

            Assert.AreEqual(expectedResult, actualResut, "Did not return proper warning.");
        }

        [TestMethod]
        public void GetVehicleByOwner_WhenOwnerDoesNotHaveVehicles_InMockedPark_ShouldWarning()
        {
            var vehicleParkDataMock = new VehicleParkDataMock(DefaultParkSectors);

            var vehicleParkMocked = new VehiclePark(DefaultParkSectors, DefaultParkPlacesPerSector, vehicleParkDataMock);

            string actualResut = vehicleParkMocked.FindVehiclesByOwner("Stamat");

            string expectedResult = $"No vehicles by Stamat";

            Assert.AreEqual(expectedResult, actualResut, "There should not be any vehicle by passed owner!");
        }

        [TestMethod]
        public void GetVehicleByOwner_WhenOwnerDoesHaveVehicles_InMockedPark_ShouldWarning()
        {
            var vehicleParkDataMock = new VehicleParkDataMock(DefaultParkSectors);

            var vehicleParkMocked = new VehiclePark(DefaultParkSectors, DefaultParkPlacesPerSector, vehicleParkDataMock);

            string actualResut = vehicleParkMocked.FindVehiclesByOwner("Gosho");

            string expectedResult = $"No vehicles by Stamat";

            Assert.AreEqual(expectedResult, actualResut, "There should not be any vehicle by passed owner!");
        }

        private string BuildExpectedTicket(int sector, int place, int hours, decimal paid, decimal rate, decimal overtimeRate)
        {
            string borders = new string('*', 20);
            string separator = new string('-', 20);

            var ticket = new StringBuilder();
            ticket.AppendLine(borders);

            ticket.AppendFormat("{0}", new Truck(DefaultLicensePlate, DefaultOwner, hours)).AppendLine();
            ticket.AppendFormat("at place ({0},{1})",sector, place).AppendLine();
            ticket.AppendFormat("Rate: ${0:F2}", rate).AppendLine();
            ticket.AppendFormat("Overtime rate: ${0:F2}", overtimeRate).AppendLine();

            ticket.AppendLine(separator);

            ticket.AppendFormat("Total: ${0:F2}", rate + overtimeRate).AppendLine();
            ticket.AppendFormat("Paid: ${0:F2}", paid).AppendLine();
            ticket.AppendFormat("Change: ${0:F2}", paid - rate - overtimeRate).AppendLine();

            ticket.Append(borders);

            return ticket.ToString();
        }

        private string InsertTruck(int sector, int place, int hours)
        {
            this.vehicle = new Truck(DefaultLicensePlate, DefaultOwner, hours);
            string actualResult = this.vehiclePark.InsertTruck((this.vehicle as Truck), sector, place, this.arrivalDateTime);
            return actualResult;
        }
    }
}
