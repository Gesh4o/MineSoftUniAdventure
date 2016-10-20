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
            User toni = new User("TonyButtony", "TainoObichamAzis14", 13, DateTime.Now);

            Console.WriteLine(entityManager.Persist<User>(toni));
        }
    }
}
