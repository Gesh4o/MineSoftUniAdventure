namespace PizzaMore.Utility
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            return "SECRET" + password;
        }
    }
}
