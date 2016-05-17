namespace BULS.Test
{
    using System;
    using System.Text;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using UniversityLearningSystem.Contracts;
    using UniversityLearningSystem.Controllers;
    using UniversityLearningSystem.Data;
    using UniversityLearningSystem.Models;
    using UniversityLearningSystem.Views.Users;

    using Moq;

    using UniversityLearningSystem.Exceptions;

    [TestClass]
    public class UniversitySystemTests
    {
        private const string FirstUsername = "username";
        private const string SecondUsername = "username0";
        private const string ThirdUsername = "username1";

        private const string FirstCourse = "CourseA";
        private const string SecondCourse = "CourseA";
        private const string ThirdCourse = "CourseB";
        private const string FourthCourse = "CourseC";

        private IRepository<string> usernames;

        [TestInitialize]
        public void InitializeRepository()
        {
            this.usernames = new Repository<string>();
        }

        [TestMethod]
        public void Get_ByIdInExistingIdInRepository_ShouldReturnExpectedElement()
        {
            this.usernames.Add(FirstUsername);
            this.usernames.Add(SecondUsername);
            this.usernames.Add(ThirdUsername);

            string actualUsername = this.usernames.Get(3);
            string expectedUsername = ThirdUsername;

            Assert.AreEqual(expectedUsername, actualUsername, "Did not return expected value!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_ByZeroIndex_ShouldThrowException()
        {
            this.usernames.Add(FirstUsername);

            this.usernames.Get(0);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_ByNegativeIndex_ShouldThrowException()
        {
            this.usernames.Add(FirstUsername);

            this.usernames.Get(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Get_ByOverlappingIndex_ShouldThrowException()
        {
            this.usernames.Add(FirstUsername);

            this.usernames.Get(14);
        }

        [TestMethod]
        public void Add_AnItemInRepository_ShouldReturnExpected()
        {
            this.usernames.Add(FirstUsername);

            StringBuilder actualResult = new StringBuilder();
            actualResult.Append(string.Join(", ", this.usernames.GetAll()));

            Assert.AreEqual(FirstUsername, actualResult.ToString(), "Unsuccessful element adding!");
        }

        [TestMethod]
        public void Display_LogInView_ShouldReturnExpectedView()
        {
            User user = new User(FirstUsername, "password", Role.Student);
            IView view = new Login(user);
            string actualView = view.Display();
            string expectedView =string.Format($"User {user.Username} logged in successfully.");

            Assert.AreEqual(expectedView, actualView, "Unsuccessful view within the login operation!");
        }

        [TestMethod]
        public void Display_LogoutView_ShouldReturnExpectedView()
        {
            User user = new User(FirstUsername, "password", Role.Student);
            IView logoutView = new Logout(user);

            string actualView = logoutView.Display();
            string expectedView = string.Format($"User {user.Username} logged out successfully.");

            Assert.AreEqual(expectedView, actualView, "Unsuccessful view within the login operation!");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Logout_NotLoggedInUser_ShouldThrowException()
        {
            User user = new User(FirstUsername, "password", Role.Student);
            UsersController controller = new UsersController(new BangaloreUniversityData(), null);
            IView logoutView = controller.Logout();
        }

        [TestMethod]
        public void Logout_LoggedInUser_ShouldReturnExpectedView()
        {
            User user = new User(FirstUsername, "password", Role.Student);
            UsersController controller = new UsersController(new BangaloreUniversityData(), user);
            IView logoutView = controller.Logout();
            string actualView = logoutView.Display();
            string expectedView = string.Format($"User {user.Username} logged out successfully.");

            Assert.AreEqual(expectedView, actualView, "Unsuccessful log out operation!");
        }

        [TestMethod]
        public void ViewAllCourse_WhereAreNoCourses_ShouldReturnExpectedMessage()
        {
            User user = new User(FirstUsername, "password", Role.Student);

            CoursesController coursecoController = new CoursesController(new BangaloreUniversityData(), user);
            IView courseView = coursecoController.All();
            string actualView = courseView.Display();
            string expectedView = "No courses.";

            Assert.AreEqual(expectedView, actualView, "Does not return proper view when there are no views!");
        }

        [TestMethod]
        public void ViewAllCourse_WhereAreCourses_ShouldReturnCoursesOrderedByNameAndStudents()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);
            User secondUser = new User(SecondUsername, "password", Role.Student);
            User thirdUser = new User(SecondUsername, "password", Role.Student);

            var db = new BangaloreUniversityData();
            CoursesController coursesController = new CoursesController(db, firstUser);
            coursesController.Create(FirstCourse);
            coursesController.Create(SecondCourse);
            coursesController.Create(ThirdCourse);
            coursesController.Create(FourthCourse);
            coursesController.Enroll(1);

            Enroll_InCourse(db, secondUser, 1);
            Enroll_InCourse(db, thirdUser, 1);
            Enroll_InCourse(db, secondUser, 2);
            Enroll_InCourse(db, firstUser, 2);

            IView courseView = coursesController.All();
            string actualView = courseView.Display();

            StringBuilder expectedView = new StringBuilder();
            expectedView.AppendLine("All courses:");
            expectedView.AppendLine("CourseA (3 students)");
            expectedView.AppendLine("CourseA (2 students)");
            expectedView.AppendLine("CourseB (0 students)");
            expectedView.Append("CourseC (0 students)");

            Assert.AreEqual(expectedView.ToString(), actualView, "Does not return proper view(course order) when there are no views!");
        }

        [TestMethod]
        public void ViewAllCourse_WhereAreCoursesWithNoStudent_ShouldReturnCoursesOrderedByName()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);

            var db = new BangaloreUniversityData();
            CoursesController coursesController = new CoursesController(db, firstUser);
            coursesController.Create(FirstCourse);
            coursesController.Create(SecondCourse);
            coursesController.Create(ThirdCourse);
            coursesController.Create(FourthCourse);

            IView courseView = coursesController.All();
            string actualView = courseView.Display();

            StringBuilder expectedView = new StringBuilder();
            expectedView.AppendLine("All courses:");
            expectedView.AppendLine("CourseA (0 students)");
            expectedView.AppendLine("CourseA (0 students)");
            expectedView.AppendLine("CourseB (0 students)");
            expectedView.Append("CourseC (0 students)");

            Assert.AreEqual(expectedView.ToString(), actualView, "Does not return proper view(course order) when there are no views!");
        }

        [TestMethod]
        public void ViewAllCourse_WhereAreCoursesWithSameNameButDifferenStudentsCount_ShouldReturnCoursesOrderedByStudents()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);
            User secondUser = new User(SecondUsername, "password", Role.Student);
            User thirdUser = new User(SecondUsername, "password", Role.Student);

            var db = new BangaloreUniversityData();
            CoursesController coursesController = new CoursesController(db, firstUser);
            coursesController.Create(FirstCourse);
            coursesController.Create(FirstCourse);
            coursesController.Create(FirstCourse);
            coursesController.Create(FirstCourse);
            coursesController.Enroll(1);

            Enroll_InCourse(db, secondUser, 1);
            Enroll_InCourse(db, thirdUser, 1);
            Enroll_InCourse(db, secondUser, 2);
            Enroll_InCourse(db, firstUser, 2);

            Enroll_InCourse(db, secondUser, 3);
            Enroll_InCourse(db, firstUser, 3);

            Enroll_InCourse(db, firstUser, 4);

            IView courseView = coursesController.All();
            string actualView = courseView.Display();

            StringBuilder expectedView = new StringBuilder();
            expectedView.AppendLine("All courses:");
            expectedView.AppendLine("CourseA (3 students)");
            expectedView.AppendLine("CourseA (2 students)");
            expectedView.AppendLine("CourseA (2 students)");
            expectedView.Append("CourseA (1 students)");

            Assert.AreEqual(expectedView.ToString(), actualView, "Does not return proper view(course order) when there are no views!");
        }

        private static void Enroll_InCourse(BangaloreUniversityData db, User user, int courseId)
        {
            CoursesController controller = new CoursesController(db, user);
            controller.Enroll(courseId);
        }

        [TestMethod]
        public void AddLecture_ToAnExistingCourse_ShouldAddLecture()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);
            
            var dbMock = new Mock<IBangaloreUniversityDate>();
            dbMock.Setup(d => d.Courses.Add(It.IsAny<Course>()));
            dbMock.Setup(db => db.Courses.Get(It.IsAny<int>())).Returns(new Course(FirstCourse));

            CoursesController courseController = new CoursesController(dbMock.Object, firstUser);
            courseController.Enroll(1);
            courseController.AddLecture(1, "Inheritance");
            IView view = courseController.Details(1);
            string actualResut = view.Display();

            string expectedResult = "CourseA\r\n- Inheritance";

            Assert.AreEqual(expectedResult,actualResut, "Add lecture does not return proper view.");

        }

        [TestMethod]
        public void AddLecture_ToAnExistingCourse_ShouldAddLectures()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);

            var dbMock = new Mock<IBangaloreUniversityDate>();
            dbMock.Setup(d => d.Courses.Add(It.IsAny<Course>()));
            dbMock.Setup(db => db.Courses.Get(It.IsAny<int>())).Returns(new Course(FirstCourse));

            CoursesController courseController = new CoursesController(dbMock.Object, firstUser);
            courseController.Enroll(1);
            courseController.AddLecture(1, "Inheritance");
            courseController.AddLecture(1, "Polymorphism");
            courseController.AddLecture(1, "Abstraction");
            courseController.AddLecture(1, "Encapsulation");

            IView view = courseController.Details(1);
            string actualResut = view.Display();

            string expectedResult = "CourseA\r\n- Inheritance\r\n- Polymorphism\r\n- Abstraction\r\n- Encapsulation";

            Assert.AreEqual(expectedResult, actualResut, "Add lecture does not return proper view.");

        }

        [TestMethod]
        [ExpectedException(typeof(AuthorizationFailedException))]
        public void AddLecture_ToNonExistingCourse_ShouldThrowException()
        {
            User firstUser = new User(FirstUsername, "password", Role.Student);

            var dbMock = new Mock<IBangaloreUniversityDate>();
            dbMock.Setup(d => d.Courses.Add(It.IsAny<Course>()));

            CoursesController courseController = new CoursesController(dbMock.Object, firstUser);
            courseController.AddLecture(2, "Inheritance");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLecture_ByNotLoggedGuestToNonExistingCourse_ShouldThrowException()
        {
            var dbMock = new Mock<IBangaloreUniversityDate>();
            dbMock.Setup(d => d.Courses.Add(It.IsAny<Course>()));

            CoursesController courseController = new CoursesController(dbMock.Object, null);
            courseController.AddLecture(2, "Inheritance");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddLecture_ByStudentToNonExistingCourse_ShouldThrowException()
        {
            User firstUser = new User(FirstUsername, "password", Role.Lecturer);

            var dbMock = new Mock<IBangaloreUniversityDate>();
            dbMock.Setup(d => d.Courses.Add(It.IsAny<Course>()));

            CoursesController courseController = new CoursesController(dbMock.Object, firstUser);
            courseController.AddLecture(2, "Inheritance");
        }
    }
}
