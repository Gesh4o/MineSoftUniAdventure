using System;

namespace _03.PCCatalog
{
    class Component
    {
        private string name;
        private string detail;
        private decimal price;

        public Component(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        } 

        public Component(string name, string detail, decimal price) : this(name,price)
        {
            this.Detail = detail;
        }

        public string Name
        {
            get {return this.name; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Component's name could not be null!");
                }
                this.name = value;
            }

        }

        public string Detail
        {
            get { return this.detail; }
            set { this.detail = value; }
        }

        public decimal Price
        {
            get { return this.price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Value can't be 0 or negative!");
                }
                this.price = value;
            }
        }

        public override string ToString()
        {
            string output = String.Format(" {0} \nComponent's details (optional): {1} \nComponent's price : {2:#.##}lv. ",this.name,this.detail??"N/A",this.price);
            return output;
        }

    }
}
