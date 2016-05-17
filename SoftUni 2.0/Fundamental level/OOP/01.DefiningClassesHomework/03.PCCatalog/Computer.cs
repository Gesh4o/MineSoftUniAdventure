using System;

namespace _03.PCCatalog
{
     class Computer
    {
        private string name;
        private Component processor;
        private Component videoCard;
        private Component hdd;
        private Component motherboard;
        private decimal price;

        public Computer(string name, Component processor, Component videoCard, Component motherboard, Component hdd, decimal price)
            : this(name, processor, videoCard, price)
        {
            this.Motherboard = motherboard;
            this.Hdd = hdd;
        }

        public Computer(string name, Component processor, Component videoCard, decimal price) 
            : this(name,price)
        {
            this.Processor = processor;
            this.VideoCard = videoCard;

        }

        public Computer(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Computer's name cannot be null!");
                }

                 this.name =value;
            }
        }
        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <0M)
                {
                    throw new ArgumentNullException("Computer's price can't be 0 or negative!");
                }
                this.price = value;
            }
        }

        public Component Processor
        {
            get { return this.processor; }
            set
            {
                this.processor = value;
            }
        }

        public Component VideoCard
        {
            get { return this.videoCard; }
            set { this.videoCard = value; }
        }

        public Component Motherboard
        {
            get { return this.motherboard; }
            set { this.motherboard = value; }
        }

        public Component Hdd
        {
            get { return this.hdd; }
            set { this.hdd = value; }
        }

        public override string ToString()
        {
            string output = String.Format("Computer's name: {0} \n\nParameters:\nProcessor:{1} \nVideo card: {2} \nMotherboard: {3} \nHDD: {4} \nTotal computer price: {5:#.##}lv.\n\n", this.name, this.Processor, this.VideoCard, this.Motherboard,this.Hdd, this.price);
            return output;
        }

        public static void PrintComponentsAndDisplaySum(Computer comp)
        {
            if (comp.videoCard == null)
            {
                Console.WriteLine("Computer name: {0}\nComponents: N/A \nComponent's price: N/A \nComputer's price: {1:#.##}lv.", comp.name, comp.price);
            }
            else if (comp.videoCard.Name != null)
            {
                if (comp.motherboard != null)
                {
                    Console.WriteLine("Computer name: {0}\nComponents: \nProcessor: {1} - {2:#.##}lv.\nVideo card: {3} - {4:#.##}lv.\nMotherboard: {5} - {6:#.##}lv.\nHDD: {7} - {8:#.##}lv.",
                    comp.name, comp.processor.Name, comp.processor.Price, comp.videoCard.Name, comp.videoCard.Price,
                    comp.motherboard.Name, comp.motherboard.Price, comp.hdd.Name, comp.hdd.Price);
                    decimal sum = comp.processor.Price + comp.videoCard.Price + comp.motherboard.Price + comp.hdd.Price;
                    Console.WriteLine("Total component price is {0:##}lv.\n", sum);
                }
                else
                {
                    Console.WriteLine("Computer name: {0}\nComponents: \nProcessor: {1} - {2:#.##}lv.\nVideo card: {3} - {4:#.##}lv.",
                    comp.name, comp.processor.Name, comp.processor.Price, comp.videoCard.Name, comp.videoCard.Price);
                    decimal sum = comp.processor.Price + comp.videoCard.Price;
                    Console.WriteLine("The component's price are {0:##}lv.\n", sum);
                }
            }
        }

    }
}
