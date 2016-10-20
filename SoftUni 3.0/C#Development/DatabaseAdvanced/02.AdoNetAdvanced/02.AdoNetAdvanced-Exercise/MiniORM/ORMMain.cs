namespace MiniORM
{
    using Core;
    using Entities;
    using System;

    public class ORMMain
    {
        private const bool isCodeFirst = true;

        public static void Main()
        {
            DatabaseConnectionStringBuilder connectionStringBuilder = new DatabaseConnectionStringBuilder("MiniORM");

            EntityManager entityManager = new EntityManager(connectionStringBuilder.ConnectionString, isCodeFirst);
            User toni = entityManager.FindById<User>(-1);

            Console.WriteLine(toni.Username);
        }
    }
}
