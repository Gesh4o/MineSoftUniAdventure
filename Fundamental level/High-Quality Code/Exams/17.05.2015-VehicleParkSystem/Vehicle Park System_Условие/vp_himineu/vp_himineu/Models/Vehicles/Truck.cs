namespace VehicleParkSystem.Models.Vehicles
{
    public class Truck : Vehicle
    {
        private const decimal DefaultTruckOverTimeRate = 6.20M;
        private const decimal DefaultTruckRegularRate = 4.75M;

        public Truck(
            string licensePlate,
            string owner,
            int reservedHours)
            
            : base(
                  licensePlate,
                  owner,
                  DefaultTruckRegularRate,
                  DefaultTruckOverTimeRate,
                  reservedHours)
        {
        }
    }
}
