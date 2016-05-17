namespace buls.Data
{
    using data;
    using System.Collections.Generic;
    using System.Linq;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public User GetByUsername(string username)
        {
            return this.items.FirstOrDefault(u => u.usr == username);
        }
    }
}
