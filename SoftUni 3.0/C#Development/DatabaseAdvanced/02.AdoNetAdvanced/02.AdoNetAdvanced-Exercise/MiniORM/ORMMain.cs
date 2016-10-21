namespace MiniORM
{
    using Core;
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ORMMain
    {
        private const bool isCodeFirst = true;

        public static void Main()
        {
            DatabaseConnectionStringBuilder connectionStringBuilder = new DatabaseConnectionStringBuilder("MiniORM");

            EntityManager entityManager = new EntityManager(connectionStringBuilder.ConnectionString, isCodeFirst);
        

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
    }
}
