namespace _02.CreateUser
{
    using _02.CreateUser.Models;
    using System;
    using System.Data.Entity.Validation;

    class CreateUserMain
    {
        static void Main(string[] args)
        {
            try
            {
                AppDbContext dbContext = new AppDbContext();

                dbContext.Users.Add(new User()
                {
                    Username = "pesewq23ho",
                    Password = "a4qS*aaa",
                    Age = 2,
                    Email = "peeesho@gmail.com"
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
