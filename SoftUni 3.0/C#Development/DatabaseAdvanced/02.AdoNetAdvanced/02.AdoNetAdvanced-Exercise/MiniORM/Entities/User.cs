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

        public User(string username, string password, int age, DateTime registrationDate)
        {
            this.username = username;
            this.password = password;
            this.age = age;
            this.registrationDate = registrationDate;
        }

        public int Id => this.id;

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

        public DateTime RegistrationDate => this.registrationDate;
    }
}
