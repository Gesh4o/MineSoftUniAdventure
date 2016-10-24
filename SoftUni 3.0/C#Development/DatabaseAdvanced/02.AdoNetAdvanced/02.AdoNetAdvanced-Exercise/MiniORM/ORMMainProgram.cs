namespace MiniORM
{
    using Core;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ORMMainProgram
    {
        private const bool isCodeFirst = true;

        public static void Main()
        {
            DatabaseConnectionStringBuilder connectionStringBuilder = new DatabaseConnectionStringBuilder("MiniORM");

            EntityManager entityManager = new EntityManager(connectionStringBuilder.ConnectionString, isCodeFirst);

            string username = Console.ReadLine();

            User user = entityManager.FindAll<User>($"Username = '{username}'").FirstOrDefault();
            user.RegistrationDate = user.RegistrationDate.AddDays(-400);

            entityManager.Persist<User>(user);
            DeleteInactiveUsers(entityManager, username, user);
        }

        private static void DeleteInactiveUsers(EntityManager entityManager, string username, User user)
        {
            if (user.IsActive)
            {
                DisplayLastActiveTime(username, user);
            }
            else
            {
                RequestDelitionOfTheUser(entityManager, username);
            }
        }

        private static void RequestDelitionOfTheUser(EntityManager entityManager, string username)
        {
            Console.WriteLine($"User {username} wast last online more than a year ago");
            Console.WriteLine("Would you like to delete that user? (yes/no)");

            string input = Console.ReadLine();
            if (input == "yes")
            {
                int deletedRows = entityManager.Delete<User>($"Username = '{username}'");
                if (deletedRows == 1)
                {
                    Console.WriteLine($"User {username} was successfully deleted from the database");
                }
                else if (deletedRows == 0)
                {
                    Console.WriteLine("Warning: user delition failed!");
                }
                else
                {
                    Console.WriteLine($"Several users with username: {username} were deleted!");
                }
            }
            else if (input == "no")
            {
                Console.WriteLine($"User {username} was not deleted from the database");
            }
            else
            {
                Console.WriteLine("Command not supported!");
            }
        }

        private static void DisplayLastActiveTime(string username, User user)
        {
            TimeSpan difference = user.LastLoginTime.Subtract(user.RegistrationDate);

            if (difference.TotalSeconds < 1)
            {
                Console.WriteLine($"User {username} wast last online less than a second");
            }
            else if (difference.TotalSeconds < 60)
            {
                Console.WriteLine($"User {username} wast last online less than a minute");
            }
            else if (difference.TotalMinutes < 60)
            {
                Console.WriteLine($"User {username} wast last online {difference.Minutes} minutes ago");
            }
            else if (difference.TotalHours < 24)
            {
                Console.WriteLine($"User {username} wast last online {difference.Hours} hours ago");
            }
            else if (difference.TotalDays < 32 && GetTotalMonthsFrom(user.RegistrationDate, user.LastLoginTime) <= 0)
            {
                Console.WriteLine($"User {username} wast last online {difference.Days} days ago");
            }
            else if (difference.TotalDays < 365)
            {
                Console.WriteLine($"User {username} wast last online {GetTotalMonthsFrom(user.RegistrationDate, user.LastLoginTime)} months ago");
            }
            else if (difference.TotalDays >= 365 && GetTotalMonthsFrom(user.RegistrationDate, user.LastLoginTime) >= 12)
            {
                Console.WriteLine($"User {username} wast last online more than a year ago");
            }
            else
            {
                Console.WriteLine($"Difference in seconds: {difference.Seconds}");
                Console.WriteLine($"Difference in minutes: {difference.Minutes}");
                Console.WriteLine($"Difference in hours: {difference.Hours}");
                Console.WriteLine($"Difference in days: {difference.Days}");
            }
        }

        private static void DeleteRecords(EntityManager entityManager)
        {
            int deletedBooks = entityManager.Delete<Book>($"Rating < 2 AND IsHardCovered = 1");
            Console.WriteLine($"{deletedBooks} has been deleted from database");
        }

        private static void UpdateRecords(EntityManager entityManager)
        {
            int year = int.Parse(Console.ReadLine());

            IEnumerable<Book> books = entityManager.FindAll<Book>($"YEAR(PublishedOn) > {year} AND IsHardCovered = 1");

            Console.WriteLine($"Books released after {year}: {books.Count()}");
            foreach (Book book in books.OrderBy(b=> b.Title))
            {
                book.Title = book.Title.ToUpper();
                entityManager.Persist<Book>(book);

                Console.WriteLine(entityManager.FindById<Book>(book.Id).Title);
            }
        }

        private static void RandomizeBooksRatings(EntityManager entityManager)
        {
            Random rnd = new Random();

            foreach (Book book in entityManager.FindAll<Book>())
            {
                book.Rating = Math.Round((decimal)rnd.NextDouble() * 10, 1);
                entityManager.Persist<Book>(book);
            }
        }

        private static void UpdateEntity(EntityManager entityManager)
        {
            RandomizeBooksRatings(entityManager);

            IEnumerable<Book> books = entityManager.FindAll<Book>().OrderByDescending(b => b.Rating).ThenBy(b => b.Title).Take(3);

            foreach (Book book in books)
            {
                Console.WriteLine($"{book.Title} ({book.Author}) - {book.Rating}/10");
            }
        }

        private static void AddNewEntity(EntityManager entityManager)
        {
            int n = int.Parse(Console.ReadLine());
            int isHardCovered = 1;

            IEnumerable<Book> books = entityManager.FindAll<Book>($"LEN(Title) > {n} AND IsHardCovered = {isHardCovered}");

            int count = 0;
            foreach (Book book in books)
            {
                book.Title = book.Title.Substring(0, n);
                entityManager.Persist<Book>(book);

                count++;
            }

            Console.WriteLine($"{count} books have title length of {n}.");
        }

        public static int GetTotalMonthsFrom(DateTime firstDate, DateTime secondDate)
        {
            DateTime earlierDate = (firstDate > secondDate) ? secondDate.Date : firstDate.Date;
            DateTime laterDate = (firstDate > secondDate) ? firstDate.Date : secondDate.Date;

            // Start with 1 month's difference and keep incrementing
            // until we overshoot the late date
            int monthsDiff = 1;
            while (earlierDate.AddMonths(monthsDiff) <= laterDate)
            {
                monthsDiff++;
            }

            return monthsDiff - 1;
        }
    }
}
