namespace _01.GringottsDatabase
{
    using _01.GringottsDatabase.Models;
    using System;
    using System.Data.Entity.Validation;

    class GringottsMain
    {
        static void Main(string[] args)
        {
            GringottsApplicationContext dbContext = new GringottsApplicationContext();

            try
            {
                dbContext.WizardDeposits
                .Add(new WizardDeposits()
                {
                    FirstName = "Albus",
                    LastName = "Dumbledore",
                    Age = 150,
                    MagicWandCreator = "Antioch Peverell",
                    MagicWandSize = 15,
                    DepositStartDate = new DateTime(2016, 10, 20),
                    DepositExpirationDate = new DateTime(2020, 10, 20),
                    DepositAmount = 20000.24M,
                    DepositCharge = 0.2M,
                    IsDepositExpired = false,
                });

                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var err in e.EntityValidationErrors)
                {
                    foreach (var er in err.ValidationErrors)
                    {
                        Console.WriteLine(er.ErrorMessage);
                    }
                }
            }
        }
    }
}
