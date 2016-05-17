namespace VehicleParkSystem.Models.Vehicles
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    using VehicleParkSystem.Contracts;

    public abstract class Vehicle : IVehicle
    {
        private string licensePlate;
        private string owner;
        private decimal regularRate;
        private decimal overtimeRate;
        private int reservedHours;

        protected Vehicle(string licensePlate, string owner, decimal regularRate, decimal overTimeRate, int reservedHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.RegularRate = regularRate;
            this.OvertimeRate = overTimeRate;
            this.ReservedHours = reservedHours;
        }

        public string LicensePlate
        {
            get
            {
                return this.licensePlate;
            }

            private set
            {
                if (!Regex.IsMatch(value, @"^[A-Z]{1,2}\d{4}[A-Z]{2,}$"))
                {
                    throw new ArgumentException("The license plate number is invalid."); 
                }

                this.licensePlate = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The owner is required.");
                }

                this.owner = value;
            }
        }

        public decimal RegularRate
        {
            get
            {
                return this.regularRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The regular rate must be non-negative.");
                }

                this.regularRate = value;
            }
        }

        public decimal OvertimeRate
        {
            get
            {
                return this.overtimeRate;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The overtime rate must be non-negative.");
                }

                this.overtimeRate = value;
            }
        }

        public int ReservedHours
        {
            get
            {
                return this.reservedHours;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("The reserved hours must be positive.");
                }

                this.reservedHours = value;
            }
        }

        public override string ToString()
        {
            var vehicle = new StringBuilder();
            vehicle.AppendFormat("{0} [{1}], owned by {2}", GetType().Name, this.LicensePlate, this.Owner);
            return vehicle.ToString();
        }
    }
}
