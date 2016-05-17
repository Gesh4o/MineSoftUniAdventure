namespace _13.LinqToExcel
{
    public class Student
    {
        public Student(
            int id,
            string firstName,
            string lastName,
            string email,
            string gender,
            string studentType,
            int examResult,
            int homeworkSent,
            double homeworkEvaluated,
            double teamwork,
            double attendaces,
            double bonus)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Gender = gender;
            this.StudentType = studentType;
            this.ExamResult = examResult;
            this.HomeworkSent = homeworkSent;
            this.HomeworkEvaluated = homeworkEvaluated;
            this.Teamwork = teamwork;
            this.Attendaces = attendaces;
            this.Bonus = bonus;
        }

        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Gender { get; private set; }

        public string StudentType { get; private set; }

        public int ExamResult { get; private set; }

        public int HomeworkSent { get; private set; }

        public double HomeworkEvaluated { get; private set; }

        public double Teamwork { get; private set; }

        public double Attendaces { get; private set; }

        public double Bonus { get; private set; }

        public double Result
        {
            get
            {
                double result = GetCurrentResult();
                return result;
            }
        }

        private double GetCurrentResult()
        {
            double result = (this.ExamResult + this.HomeworkSent + this.HomeworkEvaluated + this.Bonus + this.Teamwork + this.Attendaces) / 5.0;

            return result;
        }
    }
}
