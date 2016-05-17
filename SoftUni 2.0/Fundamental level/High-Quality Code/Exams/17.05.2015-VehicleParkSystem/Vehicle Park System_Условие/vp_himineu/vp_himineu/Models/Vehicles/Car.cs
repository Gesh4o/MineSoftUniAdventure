namespace VehicleParkSystem.Models.Vehicles
{
    public class Car : Vehicle
    {
        private const decimal DefaultCarOverTimeRate = 3.50M;
        private const decimal DefaultCarRegularRate = 2.00M;

        public Car(
            string licensePlate,
            string owner,
            int reservedHours)

            : base(
                  licensePlate,
                  owner,
                  DefaultCarRegularRate,
                  DefaultCarOverTimeRate,
                  reservedHours)
        {
        }
    }
}
