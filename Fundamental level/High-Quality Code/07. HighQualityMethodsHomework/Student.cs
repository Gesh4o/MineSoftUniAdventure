namespace Methods
{
    using System;

    public class Student
    {
        private string birthDate;
         
        public Student(string firstName, string lastName, string birthDate, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.BirthDate = birthDate;
            this.OtherInfo = otherInfo;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string BirthDate
        {
            get
            {
                return this.birthDate;
            }
            set
            {
                DateTime studentBirthDate;
                bool isDateProper = DateTime.TryParse(value, out studentBirthDate);
                if (isDateProper)
                {
                    this.birthDate = value;
                }
                else
                {
                    throw new ArgumentException(nameof(this.BirthDate), "Birth date is not valid!");
                }
            }
        }

        public string OtherInfo { get; set; }

        public bool IsOlderThan(Student other)
        {
            DateTime firstDate =
                DateTime.Parse(this.birthDate);
            DateTime secondDate =
                DateTime.Parse(other.BirthDate);

            bool isOlder = firstDate > secondDate;
            return isOlder;
        }
    }
}
