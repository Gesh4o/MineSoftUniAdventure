﻿namespace _05.BookLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class BookLibraryMain
    {
        public static void Main(string[] args)
        {
            int booksCount = int.Parse(Console.ReadLine());
            Library library = new Library();

            for (int i = 0; i < booksCount; i++)
            {
                string[] bookInfo = Console.ReadLine()
                   .Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                   .ToArray();

                DateTime releaseDate = DateTime.ParseExact(bookInfo[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                decimal price = decimal.Parse(bookInfo[5]);

                library.Books.Add(new Book(bookInfo[0], bookInfo[1], bookInfo[2], releaseDate, bookInfo[4], price));
            }

            // Modification method for task 6.
             PrintAllBooksAfterDate(library);

           // PrintBooksByAuthorAndPrice(library);
        }
 
        private static void PrintBooksByAuthorAndPrice(Library library)
        {
            var grouping = library.Books.GroupBy(b => b.Author);

            foreach (IGrouping<string, Book> bookByAuthor in grouping.OrderByDescending(b => b.Sum(bb => bb.Price)).ThenBy(b => b.Key))
            {
                Console.WriteLine($"{bookByAuthor.Key} -> {bookByAuthor.Sum(b => b.Price):F2}");
            }
        }

        private static void PrintAllBooksAfterDate(Library library)
        {
            string date = Console.ReadLine();
            DateTime afterDate = DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);
            var allAfterDate = library.Books.Where(b => b.ReleaseDate.CompareTo(afterDate) > 0).OrderBy(bb => bb.ReleaseDate).ThenBy(b => b.Title).GroupBy(b => b.Title);

            foreach (IGrouping<string, Book> grouping in allAfterDate)
            {
                foreach (Book book in grouping)
                {
                    Console.WriteLine($"{book.Title} -> {book.ReleaseDate.ToString("dd.MM.yyy")}");
                }
            }
        }
    }

    class Book
    {
        public Book(string title, string author, string publisher, DateTime releaseDate, string isbn, decimal price)
        {
            this.Title = title;
            this.Publisher = publisher;
            this.Author = author;
            this.ReleaseDate = releaseDate;
            this.ISBN = isbn;
            this.Price = price;
        }

        public string Title { get; set; }

        public string Publisher { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }
    }

    class Library
    {
        public Library()
        {
            this.Books = new List<Book>();
        }

        public List<Book> Books { get; set; }
    }
}
