namespace MiniORM.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using MiniORM.Entities;
    using MiniORM.Core;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Using MiniORM.Entities and not mocked db.
    /// </summary>
    [TestClass]
    public class EntityManagerTests
    {
        private const bool isCodeFirst = true;
        private DatabaseConnectionStringBuilder connectionStringBuilder;

        private EntityManager entityManager;

        [TestInitialize]
        public void Initialize()
        {
            this.connectionStringBuilder = new DatabaseConnectionStringBuilder("MiniORM");
            this.entityManager = new EntityManager(connectionStringBuilder.ConnectionString, isCodeFirst);
        }

        [TestMethod]
        public void GetEntityBy_AfterInsert_ShouldReturnObjectWithSameValues()
        {
            User user = new User("Toshko", "password", 45, DateTime.Now);
            this.entityManager.Persist<User>(user);

            User returnedUser = this.entityManager.FindById<User>(user.Id);
            bool areEqual = AreEqual(user, returnedUser);

            Assert.IsTrue(areEqual, "Entities added by Id an then returned with the same Id ar not same!");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetEntityById_WithInvalidId_ShouldThrowException()
        {
            this.entityManager.FindById<User>(-1);
        }

        [TestMethod]
        public void UpdateExistingEntity_FoundById_ShouldChangeState()
        {
            int age = 31;
            int id = 1;
            User user = this.entityManager.FindById<User>(id);
            user.Age = age;
            this.entityManager.Persist<User>(user);

            User updatedUser = this.entityManager.FindById<User>(id);

            Assert.IsTrue(updatedUser.Age == age, "Entity values were not updated properly!");
        }

        [TestMethod]
        public void FilterAllEntitiesByCondition_ShouldReturnProperCollection()
        {
            int age = 18;
            IEnumerable<User> users = this.entityManager.FindAll<User>($"Age > {age}");

            foreach (User user in users)
            {
                Assert.IsTrue(user.Age > 18);
            }
        }

        [TestMethod]
        public void InsertEntity_WithQuatationMark_ShouldReturn_ExactlySameObject()
        {
            Book[] books = new Book[15];
            books[0] = new Book("Da Vinci Code", "Dan Braun", new DateTime(2000, 9, 11), "International", true);
            books[1] = new Book("To kill a mockingbird", "Eva Braun", new DateTime(1999, 9, 11), "English", false);
            books[2] = new Book("Introducing to programming", "Svetlin Nakov", new DateTime(2008, 10, 12), "Bulgarian", true);
            books[3] = new Book("The Pra'gmatic Programer", "Andrews Hunt", new DateTime(1990, 1, 11), "English", false);
            books[4] = new Book("Refactoring: Improving the Design of \"Existing Code", "Martin Fowler", new DateTime(1999, 9, 11), "English", true);
            books[5] = new Book("Code Complete: A Practical Handbook of Software Construction", "Steve McConnell", new DateTime(2000, 9, 11), "International", false);
            books[6] = new Book("Clean' Code: A Handbook of Agile Software Craftsmanship", "Robert C.Martin", new DateTime(1997, 3, 11), "English", false);
            books[7] = new Book("Harry Potter and the Cursed Child..", "J.K.Rowling", new DateTime(2011, 9, 11), "International", true);
            books[8] = new Book("The Whistler", "John Grisham", new DateTime(2003, 8, 9), "International", true);
            books[9] = new Book("Good Clean Fun: Misadventures in Sawd..", "Nick Offerman", new DateTime(2010, 3, 17), "English", false);
            books[10] = new Book("The Book with No Pictures", "B.J.Novak", new DateTime(2000, 9, 11), "International", true);
            books[11] = new Book("Suck Less: Where There's a Willam", "Belli, Willam", new DateTime(2000, 9, 11), "German", true);
            books[12] = new Book("Fantastic Beasts and Where to Find Them", "J.K.Rowling", new DateTime(2013, 8, 22), "English", true);
            books[13] = new Book("World of Warcraft: The Official Cookbook", "Chelsea Monroe - Cassel", new DateTime(2015, 1, 11), "Englsh", true);
            books[14] = new Book("Inferno (Robert Langdon)", "Dan Brown", new DateTime(2011, 11, 11), "International", false);

            foreach (Book book in books)
            {
                entityManager.Persist<Book>(book);

                Book savedBook = this.entityManager.FindById<Book>(book.Id);

                Assert.AreEqual(book.Title, savedBook.Title, "Entity with special chars not saved properly!");
            }           
        }

        [TestMethod]
        public void UpdateEntity_WithQuatationMark_ShouldReturn_ExactlySameObject()
        {
            int id = 1;
            Book book = this.entityManager.FindById<Book>(id);
            book.Title = "Very stange quatation mark'";
            this.entityManager.Persist<Book>(book);

            Book savedBook = this.entityManager.FindById<Book>(id);
            Assert.AreEqual(book.Title, savedBook.Title, "Entity with special chars not updated properly!");
            
        }

        private static bool AreEqual(User user, User returnedUser)
        {
            // Note that after putting DateTime into SQL Server it slightly differs from the original one (in terms of ticks only, other fields remain same).
            // ToDo: Compare dates more precisly with comparint days, hours and minutes.
            bool areDatesSame = user.RegistrationDate.DayOfYear == returnedUser.RegistrationDate.DayOfYear;
            return user.Id == returnedUser.Id &&
                            user.Username == returnedUser.Username &&
                            user.Password == returnedUser.Password &&
                            user.Age == returnedUser.Age &&
                            areDatesSame;
        }

        [TestMethod]
        public void DeleteEntity_AfterInsert_ShouldRemoveEntityFromDatabase()
        {
            Book book = new Book("Pesho", "Gosho", DateTime.Now, "BG", false);
            this.entityManager.Persist<Book>(book);
            bool hasDeleted = this.entityManager.Delete<Book>($"Id = {book.Id}");

            Assert.IsTrue(hasDeleted);
        }
    }
}
