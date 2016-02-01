namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using HotelBookingSystem.Contracts;

    public class Venue : IDatabaseEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new List<Room>();
        }

        public int Id { get; set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The venue name cannot be null or empty!");
                }

                const int DefaultNameSymbolCount = 3;
                if (value.Length < DefaultNameSymbolCount)
                {
                    throw new ArgumentException(string.Format($"The venue name must be at least {DefaultNameSymbolCount} symbols long."));
                }

                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The Venue address cannot be null or empty!");
                }

                const int DefaultAddressSymbolCount = 3;
                if (value.Length < DefaultAddressSymbolCount)
                {
                    throw new ArgumentException(string.Format($"The venue address must be at least {DefaultAddressSymbolCount} symbols long."));
                }

                this.address = value;
            }
        }

        public string Description { get; set; }

        public User Owner { get; set; }

        public ICollection<Room> Rooms { get; set; }
    }
}
