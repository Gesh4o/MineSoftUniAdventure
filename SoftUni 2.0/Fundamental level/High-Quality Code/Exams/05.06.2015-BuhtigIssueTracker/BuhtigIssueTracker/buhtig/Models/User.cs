namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string username, string password)
        {
            this.UserName = username;
            this.PasswordHash = HashPassword(password);
        }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public static string HashPassword(string password)
        {
            string hashedPassword = string.Join(string.Empty, SHA1.Create().ComputeHash(Encoding.Default.GetBytes(password)).Select(x => x.ToString()));
            return hashedPassword;
        }
    }

}
