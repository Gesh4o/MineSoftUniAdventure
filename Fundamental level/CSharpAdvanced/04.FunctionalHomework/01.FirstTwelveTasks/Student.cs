namespace FunctionalProgrammingHomework
{
    using System.Collections.Generic;
    using System.Text;

    public class Student
    {
        public Student(string firstName, string lastName, int age, string facultyNumber, string phone, string email, ICollection<int> marks, int groupNumber, string groupName)
            : this(firstName, lastName, age, facultyNumber, phone, email, groupNumber, groupName)
        {
            this.Marks = marks;
        }

        public Student(string firstName, string lastName, int age, string facultyNumber, string phone, string email, int groupNumber, string groupName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.FacultyNumber = facultyNumber;
            this.Phone = phone;
            this.Email = email;
            this.Marks = new List<int>();
            this.GroupNumber = groupNumber;
            this.GroupName = groupName;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public int Age { get; }

        public string FacultyNumber { get; }

        public string Phone { get; }

        public string Email { get; }

        public ICollection<int> Marks { get; }

        public int GroupNumber { get; }

        public string GroupName { get; }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            string border = "--------------";

            result.AppendFormat("First name: {0}", this.FirstName).AppendLine();
            result.AppendFormat("Last name: {0}", this.LastName).AppendLine();
            result.AppendFormat("Age: {0}", this.Age).AppendLine();
            result.AppendFormat("Faculty number: {0}", this.FacultyNumber).AppendLine();
            result.AppendFormat("Phone number: {0}", this.Phone).AppendLine();
            result.AppendFormat("Email: {0}", this.Email).AppendLine();
            result.AppendFormat("Marks: {0}", string.Join(", ", this.Marks)).AppendLine();
            result.AppendFormat("Group number: {0}", this.GroupNumber).AppendLine();
            result.AppendFormat("Group name: {0}", this.GroupName).AppendLine();

            result.AppendLine(border);

            return result.ToString().Trim();
        }
    }
}