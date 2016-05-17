namespace UniversityLearningSystem.Data
{
    using System.Collections.Generic;

    using UniversityLearningSystem.Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> usersByUsername;

        public UsersRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            // Performance: This method was using the list insted of the dictionary which made searching by username slower.
            return this.usersByUsername.ContainsKey(username) ? this.usersByUsername[username] : null;
        }

        public override void Add(User item)
        {
            base.Add(item);
            this.usersByUsername.Add(item.Username, item);
        }
    }
}
