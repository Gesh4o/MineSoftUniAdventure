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
        private const bool isCodeFirst = false;
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
    }
}
