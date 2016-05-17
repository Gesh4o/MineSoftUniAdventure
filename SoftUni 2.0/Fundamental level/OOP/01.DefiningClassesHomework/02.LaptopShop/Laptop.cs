using System;

namespace _02.LaptopShop
{
    public class Laptop
    {
        private static bool isBaterryInfoAvaible = true;
        private string model;
        private decimal price;
        private string manufacturer;
        private string processor;
        private string RAM;
        private string graphicCard;
        private string HDD;
        private string screen;
        private Battery batery;

        public Laptop(string model, string manufacturer, string processor, string RAM, string graphicCard, string HDD, string screen, Battery batery, decimal price) 
            : this(model,  manufacturer,  processor,  RAM,  graphicCard, HDD,  screen,  price)
        {
            this.Batery = batery;
        }

        public Laptop(string model, string manufacturer, string processor, string RAM, string graphicCard, string HDD, string screen, decimal price) 
            :this(model,price)
        {
            this.Manufactorer = manufacturer;
            this.Processor = processor;
            this.LRAM = RAM;
            this.GraphicCard = graphicCard;
            this.LHDD = HDD;
            this.Screen = screen;
        }

        public Laptop(string model, decimal price)
        {
            this.Model = model;
            this.Price = price;

            if (batery == null)
            {
                isBaterryInfoAvaible = false;
            }
        }

        public string Model
        {
            get { return this.model; }
            set
            {
                if (value == string.Empty)
                {
                    throw new Exception("Model name should consist alphabets!");
                }

                this.model = value;
            }

        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (price < 0.0M)
                {
                    throw new IndexOutOfRangeException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public string Manufactorer
        {
            get { return this.manufacturer; }

            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Manufactorer's name is not valid!");
                }
                this.manufacturer = value;
            }
        }

        public string Processor
        {
            get { return this.processor; }
            set
        {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Processor's name  is not valid!");
                }
                this.processor = value;
            }
        }

        public string LRAM
        {
            get { return this.RAM; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("RAM's name is not valid!");
                }
                this.RAM = value;
            }
        }

        public string GraphicCard
        {
            get { return this.graphicCard; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Graphic card's name  is not valid!");
                }
                this.graphicCard = value;
            }
        }

        public string LHDD
        {
            get { return this.HDD; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("HDD's name  is not valid!");
                }
                this.HDD = value;
            }
        }

        public string Screen
        {
            get { return this.screen; }
            set
            {
                if (value == string.Empty)
                {
                    throw new ArgumentException("Screen's properties are not valid!");
                }

                this.screen = value;
            }
        }

        public Battery Batery
        {
            get { return this.batery; }
            set { this.batery = value; }

        }

        public override string ToString()
        {
            string unknown = "unknown";
            string batteryType = string.Empty;
            double batteryLife = 0;
            if (isBaterryInfoAvaible)
            {
                batteryType = this.batery.BatteryName;
                batteryLife = this.batery.BatteryLife;

            }
            string result = "Model: " + (this.model) + "\nManifacturer: " + (this.manufacturer ?? "unknown") + "\nProcessor: " +
                (this.processor ?? unknown) + "\nRAM: " + (this.RAM ?? unknown) + "\nGraphic card: " + (this.graphicCard ?? unknown) +
                "\nHDD: " + (this.HDD ?? unknown) + "\nScreen: " + (this.screen ?? unknown) + "\nBattery type: " + (batteryType ?? unknown) + 
                "\nBattery life: " + batteryLife  + "\nPrice: " + (this.price) + "lv.\n";
            return result;
        }
    }
}
