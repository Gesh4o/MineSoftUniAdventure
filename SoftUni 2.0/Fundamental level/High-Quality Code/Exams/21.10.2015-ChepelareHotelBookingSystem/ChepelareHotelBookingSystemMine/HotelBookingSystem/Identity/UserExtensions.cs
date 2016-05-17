namespace HotelBookingSystem.Identity
{
    using Enums;

    using Models;

    public static class UserExtensions
    {
        public static bool IsInRole(this User user, Roles role)
        {
            bool isInRole = user.Role == role;
            return isInRole;
        }
    }
}
