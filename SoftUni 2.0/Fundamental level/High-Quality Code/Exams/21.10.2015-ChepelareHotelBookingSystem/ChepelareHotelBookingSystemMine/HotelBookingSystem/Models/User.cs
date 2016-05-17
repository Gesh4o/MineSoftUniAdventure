namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Enums;
    using Utilities;

    public class User : IDatabaseEntity
    {
        private string username;
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int Id { get; set; }

        public string Username
        {
            get
            {
                return this.username;
            } 

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The name must not be null or emtpy!");
                }

                const int DefaultMinNameSymbolCount = 5;
                if (value.Length < DefaultMinNameSymbolCount)
                {
                    throw new ArgumentException(string.Format($"The username must be at least {DefaultMinNameSymbolCount} symbols long."));
                }

                this.username = value;
            }
        }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("The password must not be null or emtpy!");
                }

                const int DefaultMinPasswordSymbolCount = 6;
                if (value.Length < DefaultMinPasswordSymbolCount)
                {
                    throw new ArgumentException(
                        string.Format($"The password must be at least {DefaultMinPasswordSymbolCount} symbols long."));
                }

                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}
