namespace _02.LaptopShop
{
    using System;

    public class Battery
    {
        private string batteryName;
        private double batteryLife;

        public Battery(string batteryName) 
        {
            this.BatteryName = batteryName;
        }

        public Battery(string batteryName, double batteryLife)
            : this(batteryName)
        {
            this.BatteryLife = batteryLife;
        }

        public string BatteryName
        {
            get { return this.batteryName; }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Batery name not valid!");
                }

                this.batteryName = value;
            }
        }

        public double BatteryLife
        {
            get { return this.batteryLife; }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Batter power life can't be negative or zero!");
                }

                this.batteryLife = value;
            }
        }
    }
}