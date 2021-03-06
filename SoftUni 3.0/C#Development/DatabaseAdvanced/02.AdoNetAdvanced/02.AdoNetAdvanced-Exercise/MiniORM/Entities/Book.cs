﻿namespace MiniORM.Entities
{
    using Attribute;
    using System;

    [Entity("Books")]
    public class Book
    {
        [Id]
        private int id;

        [Column("Title")]
        private string title;

        [Column("Author")]
        private string author;

        [Column("PublishedOn")]
        private DateTime publishedOn;

        [Column("Language")]
        private string language;

        [Column("IsHardCovered")]
        private bool isHardCovered;

        [Column("Rating")]
        private decimal rating;

        public Book(string title,
            string author,
            DateTime publishedOn,
            string language,
            bool isHardCovered)
        {
            this.Title = title;
            this.Author = author;
            this.PublishedOn = publishedOn;
            this.Language = language;
            this.IsHardCOvered = isHardCovered;
            this.Rating = 0;
        }

        public Book(string title,
           string author,
           DateTime publishedOn,
           string language,
           bool isHardCovered,
           decimal rating) : this(title, author, publishedOn, language, isHardCovered)
        {
            this.Rating = rating;
        }

        public decimal Rating
        {
            get { return rating; }
            set { rating = value; }
        }

        public bool IsHardCOvered
        {
            get { return isHardCovered; }
            set { isHardCovered = value; }
        }

        public string Language
        {
            get { return language; }
            set { language = value; }
        }

        public DateTime PublishedOn
        {
            get { return publishedOn; }
            set { publishedOn = value; }
        }

        public string Author
        {
            get { return author; }
            set { author = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}
