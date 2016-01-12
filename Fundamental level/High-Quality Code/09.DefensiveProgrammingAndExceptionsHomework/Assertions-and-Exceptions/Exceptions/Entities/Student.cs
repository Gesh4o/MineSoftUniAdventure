namespace Exceptions_Homework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Exceptions_Homework.Entities.Exams;

    public class Student
    {
        private string firstName;
        private string lastName;
        private IList<Exam> exams;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.exams = new List<Exam>();
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.firstName), "First name cannot be null or empty!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.lastName), "Last name cannot be null! ");
                }

                this.lastName = value;
            }
        }

        public IEnumerable<Exam> Exams => this.exams;

        public void AddExam(Exam exam)
        {
            if (exam == null)
            {
                throw new ArgumentNullException(nameof(exam),"Exam is null, cannot be added.");
            }
            this.exams.Add(exam);
        }

        public IList<ExamResult> CheckExams()
        {
            IList<ExamResult> results = new List<ExamResult>();
            for (int i = 0; i < this.exams.Count; i++)
            {
                results.Add(this.exams[i].Check());
            }

            return results;
        }

        public double CalcAverageExamResultInPercents()
        {
            if (this.exams.Count == 0)
            {
                throw new InvalidOperationException("Cannot calculate avarage exam result with no exam taken!");
            }

            double[] examScore = new double[this.exams.Count];
            IList<ExamResult> examResults = this.CheckExams();
            for (int i = 0; i < examResults.Count; i++)
            {
                double studentScore = examResults[i].Grade - examResults[i].MinGrade;
                double perfectScore = examResults[i].MaxGrade - examResults[i].MinGrade;
                examScore[i] = studentScore / perfectScore;
            }

            return examScore.Average();
        }
    }
}
