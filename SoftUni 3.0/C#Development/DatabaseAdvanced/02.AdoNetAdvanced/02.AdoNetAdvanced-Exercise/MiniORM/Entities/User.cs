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

        public string Username => this.username;

        public string Password => this.password;

        public int Age => this.age;

        public DateTime RegistrationDate => this.registrationDate;
    }
}
