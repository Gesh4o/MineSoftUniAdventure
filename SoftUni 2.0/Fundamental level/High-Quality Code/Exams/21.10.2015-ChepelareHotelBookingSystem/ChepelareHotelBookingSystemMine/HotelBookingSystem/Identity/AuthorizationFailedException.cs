namespace HotelBookingSystem.Identity
{
    using System;
    using HotelBookingSystem.Models;

    public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}
