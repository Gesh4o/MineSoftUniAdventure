namespace MiniORM.Entities
{
    using Attribute;
    using System;

    [Entity("Users")]
    public class User
    {
        [Id]
        private int id;

        [Column("Username")]
        private string username;

        [Column("Password")]
        private string password;

        [Column("Age")]
        private int age;

        [Column("RegistrationDate")]
        private DateTime registrationDate;

        [Column("LastLoginTime")]
        private DateTime lastLoginTime;

        [Column("IsActive")]
        private bool isActive;

        public User(string username, string password, int age, DateTime registrationDate) : this(username, password,age, registrationDate, DateTime.Now, true)
        {
        }

        public User(string username, string password, int age, DateTime registrationDate, DateTime loginDate, bool isActive)
        {
            this.Username = username;
            this.Password = password;
            this.Age = age;
            this.registrationDate = registrationDate;
            this.LastLoginTime = loginDate;
            this.IsActive = isActive;
        }

        public int Id => this.id;

        public bool IsActive
        {
            get
            {
                this.isActive = this.LastLoginTime.Subtract(this.RegistrationDate).Days <= 365;
                return this.isActive;
            }
            set { this.isActive = value; }
        }

        public DateTime LastLoginTime
        {
            get { return lastLoginTime; }
            set { lastLoginTime = value; }
        }

        public string Username
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public string Password
        {
            get { return this.password; }
            set { this.password = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public DateTime RegistrationDate
        {
            get { return this.registrationDate; }
            set { this.registrationDate = value; }
        }
    }
}
