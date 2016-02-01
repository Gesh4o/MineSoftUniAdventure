namespace VehicleParkSystem.Models.Vehicles
{
    public class Motorbike : Vehicle
    {
        private const decimal DefaultMotorbikeOverTimeRate = 3.00M;
        private const decimal DefaultMotorbikeRegularRate = 1.35M;

        public Motorbike(
            string licensePlate,
            string owner,
            int reservedHours)
            
            : base(
                  licensePlate,
                  owner,
                  DefaultMotorbikeRegularRate,
                  DefaultMotorbikeOverTimeRate,
                  reservedHours)
        {
        }
    }
}
