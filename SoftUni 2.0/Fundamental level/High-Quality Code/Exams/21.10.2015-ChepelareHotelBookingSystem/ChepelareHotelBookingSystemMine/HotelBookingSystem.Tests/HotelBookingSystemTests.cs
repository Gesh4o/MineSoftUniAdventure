namespace HotelBookingSystem.Tests
{
    using System;
    using System.Text;

    using HotelBookingSystem.Contracts;
    using HotelBookingSystem.Controllers;
    using HotelBookingSystem.Data;
    using HotelBookingSystem.Enums;
    using HotelBookingSystem.Identity;
    using HotelBookingSystem.Infrastructure;
    using HotelBookingSystem.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class HotelBookingSystemTests
    {
        private const string UsernameOne = "Pesho";
        private const string UsernameTwo = "Gosho";

        private const string PasswordOne = "password";

        private IRepository<User> users;

        [TestInitialize]
        public void InitializeUsernames()
        {
            this.users = new Repository<User>();
        }

        [TestMethod]
        public void Get_AnExistingElementInRepository_ShouldReturnExpectedValue()
        {
            var firstUser = new User(UsernameOne, PasswordOne, Roles.User);
            var secondUser = new User(UsernameTwo, PasswordOne, Roles.User);

            this.users.Add(firstUser);
            this.users.Add(secondUser);

            var actualValue = this.users.Get(1);
            var expectedValue = firstUser;

            Assert.AreEqual(expectedValue, actualValue, "Did not return proper data entity!");
        }

        [TestMethod]
        public void Get_WithNegativeID_ShouldThrowException()
        {
            var firstUser = new User(UsernameOne, PasswordOne, Roles.User);

            this.users.Add(firstUser);

            var actualValue = this.users.Get(-1);

            Assert.IsNull(actualValue, "Did not return default value");
        }

        [TestMethod]
        public void Get_WithOverlappingID_ShouldThrowException()
        {
            var firstUser = new User(UsernameOne, PasswordOne, Roles.User);
            var secondUser = new User(UsernameTwo, PasswordOne, Roles.VenueAdmin);

            this.users.Add(secondUser);
            this.users.Add(firstUser);

            var actualValue = this.users.Get(11);

            Assert.IsNull(actualValue, "Did not return default value");
        }

        [TestMethod]
        public void Authorize_RightRole_ShouldNotThrowException()
        {
            var data = new HotelBookingSystemData();
            var controller = new Controller(data, new User(UsernameOne, PasswordOne, Roles.User));

            controller.Authorize(Roles.User);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Authorize_WrongRole_ShouldThrowException()
        {
            var data = new HotelBookingSystemData();
            var controller = new Controller(data, new User(UsernameOne, PasswordOne, Roles.User));

            controller.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Authorize_NonLoggedUser_ShouldThrowException()
        {
            var data = new HotelBookingSystemData();
            var controller = new Controller(data, null);

            controller.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void Authorize_NonIntializeDataWithWrongRole_ShouldThrowException()
        {
            var controller = new Controller(null, new User(UsernameOne, PasswordOne, Roles.User));

            controller.Authorize(Roles.VenueAdmin);
        }

        [TestMethod]
        public void Authorize_NonIntializeDataWithRightRole_ShouldNotThrowException()
        {
            var controller = new Controller(null, new User(UsernameOne, PasswordOne, Roles.User));

            controller.Authorize(Roles.User);
        }

        [TestMethod]
        public void Logout_LoggedInUser_ShouldReturnLogoutView()
        {
            var data = new HotelBookingSystemData();
            var user = new User(UsernameOne, PasswordOne, Roles.User);

            var userController = new UsersController(data, user);

            var view = userController.Logout();

            var actualResult = view.Display();

            var expectedResult = string.Format($"The user {user.Username} has logged out.");

            Assert.AreEqual(expectedResult, actualResult, "Does not log out logged in user.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_NotLoggedInUser_ShouldThrowException()
        {
            var data = new HotelBookingSystemData();

            var userController = new UsersController(data, null);

            var view = userController.Logout();

        }

        [TestMethod]
        public void Logout_LoggedVenueAdmin_ShouldReturnLogoutView()
        {
            var data = new HotelBookingSystemData();
            var user = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);

            var userController = new UsersController(data, user);

            var view = userController.Logout();

            var actualResult = view.Display();

            var expectedResult = string.Format($"The user {user.Username} has logged out.");

            Assert.AreEqual(expectedResult, actualResult, "Does not log out logged in user.");
        }

        [TestMethod]
        public void Logout_LoggedVenueAdminWhileDataIsNotInitialized_ShouldReturnLogoutView()
        {
            var user = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);

            var userController = new UsersController(null, user);

            var view = userController.Logout();

            var actualResult = view.Display();

            var expectedResult = string.Format($"The user {user.Username} has logged out.");

            Assert.AreEqual(expectedResult, actualResult, "Does not log out logged in user.");
        }

        [TestMethod]
        public void Logout_LoggedUserWhileDataIsNotInitialized_ShouldReturnLogoutView()
        {
            var user = new User(UsernameOne, PasswordOne, Roles.User);

            var userController = new UsersController(null, user);

            var view = userController.Logout();
            var actualResult = view.Display();

            var expectedResult = string.Format($"The user {user.Username} has logged out.");

            Assert.AreEqual(expectedResult, actualResult, "Does not log out logged in user.");
        }

        [TestMethod]
        public void VenuesAll_VenuesInDataWithLoggedInUser_ShouldReturnExpectedView()
        {
            var data = new HotelBookingSystemData();
            var user = new User(UsernameOne, PasswordOne, Roles.User);

            var venuesController = new VenuesController(data, user);

            venuesController.Add("Valentin", "Sveti", "Praznik, na koito vsichki praznuvat, no ne i az.");
            venuesController.Add("Halloween", "USA", "Praznika, na koito rupsitata izglejdat po-dobre - kop-kop.");

            var view = venuesController.All();
            string actualResult = view.Display();

            var expectedResult = new StringBuilder();
            expectedResult.AppendFormat($"*[{1}] {"Valentin"}, located at {"Sveti"}").AppendLine();
            expectedResult.AppendLine("Free rooms: 0");
            expectedResult.AppendFormat($"*[{2}] {"Halloween"}, located at {"USA"}").AppendLine();
            expectedResult.Append("Free rooms: 0");

            Assert.AreEqual(expectedResult.ToString(), actualResult, "All venues did not return expected view!");

        }

        [TestMethod]
        public void VenuesAll_VenuesInDataWithNoLoggedInUser_ShouldReturnExpectedView()
        {
            var data = new HotelBookingSystemData();
            var venuesController = new VenuesController(data, null);

            venuesController.Add("Valentin", "Sveti", "Praznik, na koito vsichki praznuvat, no ne i az.");

            var view = venuesController.All();
            string actualResult = view.Display();

            var expectedResult = new StringBuilder();
            expectedResult.AppendFormat($"*[{1}] {"Valentin"}, located at {"Sveti"}").AppendLine();
            expectedResult.Append("Free rooms: 0");

            Assert.AreEqual(expectedResult.ToString(), actualResult, "All venues did not return expected view!");

        }

        [TestMethod]
        public void ViewAll_NoVenuesWithLoggedUser_ShouldReturnExpectedMessage()
        {
            var data = new HotelBookingSystemData();
            var user = new User(UsernameOne, PasswordOne, Roles.User);

            var venuesController = new VenuesController(data, user);

            var view = venuesController.All();
            string actualResult = view.Display();

            var expectedResult = "There are currently no venues to show.";

            Assert.AreEqual(expectedResult, actualResult, "All venues did not return expected view!");

        }

        [TestMethod]
        public void ViewAll_VenuesWithNotLoggedInUser_ShouldReturnExpectedMessage()
        {
            var data = new HotelBookingSystemData();

            var venuesController = new VenuesController(data, null);

            var view = venuesController.All();
            string actualResult = view.Display();

            var expectedResult = "There are currently no venues to show.";

            Assert.AreEqual(expectedResult, actualResult, "All venues did not return expected view!");

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ViewAll_NoVenuesWithLoggedUserAndNoData_ShouldReturnExpectedMessage()
        {
            var user = new User(UsernameOne, PasswordOne, Roles.User);

            var venuesController = new VenuesController(null, user);

            var view = venuesController.All();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ViewAll_NoVenuesWithNoLoggedUserAndNoData_ShouldReturnExpectedMessage()
        {
            var venuesController = new VenuesController(null, null);

            var view = venuesController.All();
        }

        [TestMethod]
        public void AddRoom_ToVenueByAdmin_ShouldReturnExpectedViewAndReturnProperCount()
        {
            var user = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);
            var mock = new Mock<IHotelBookingSystemData>();
            mock.Setup(db => db.Venues.Get(It.IsAny<int>()))
                .Returns(new Venue("dddd", "dddb", "check", user));
            mock.Setup(db => db.Rooms.Add(It.IsAny<Room>()));

            var roomsController = new RoomsController(mock.Object, user);
            var view = roomsController.Add(3, 2, 10M);
            var actualResult = view.Display();

            var expectedResult = $"The room with ID {0} has been created successfully.";

            Assert.AreEqual(expectedResult, actualResult, "Did not add new room to venue!");

            var venue = mock.Object.Venues.Get(231);

            var actualRoomCount = venue.Rooms.Count;
            var expectedRoomCount = 1;
            Assert.AreEqual(expectedRoomCount, actualRoomCount, "Rooms count of the venue is invalid!");
        }

        [TestMethod]
        public void AddRoom_ToVenueWithOverlappingID_ShouldReturnWarningMessage()
        {
            var admin = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);
            var mock = new Mock<IHotelBookingSystemData>();
            mock.Setup(db => db.Venues.Get(1))
                .Returns(new Venue("dddd", "dddb", "check", admin));
            mock.Setup(db => db.Rooms.Add(It.IsAny<Room>()));

            var roomsController = new RoomsController(mock.Object, admin);
            var view = roomsController.Add(2, 2, 10M);
            var actualResult = view.Display();

            var expectedResult = $"Something happened!!1\r\nThe venue with ID {2} does not exist.";

            Assert.AreEqual(expectedResult, actualResult, "Adding a room to not existing venue should return error message!");
        }

        [TestMethod]
        public void AddRoom_ToVenueWithNegativeID_ShouldReturnWarningMessage()
        {
            var admin = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);
            var mock = new Mock<IHotelBookingSystemData>();
            mock.Setup(db => db.Venues.Get(1))
                .Returns(new Venue("dddd", "dddb", "check", admin));
            mock.Setup(db => db.Rooms.Add(It.IsAny<Room>()));

            var roomsController = new RoomsController(mock.Object, admin);
            var view = roomsController.Add(-7, 2, 10M);
            var actualResult = view.Display();

            var expectedResult = $"Something happened!!1\r\nThe venue with ID {-7} does not exist.";

            Assert.AreEqual(expectedResult, actualResult, "Adding a room to not existing venue should return error message!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddRoom_ToVenueWithNotLoggedInUser_ShouldThrowException()
        {
            var admin = new User(UsernameOne, PasswordOne, Roles.VenueAdmin);
            var mock = new Mock<IHotelBookingSystemData>();
            mock.Setup(db => db.Venues.Get(1))
                .Returns(new Venue("dddd", "dddb", "check", admin));
            mock.Setup(db => db.Rooms.Add(It.IsAny<Room>()));

            var roomsController = new RoomsController(mock.Object, null);
            var view = roomsController.Add(2, 2, 10M);
        }
    }
}
