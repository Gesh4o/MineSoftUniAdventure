namespace Exceptions_Homework.Entities.Exams
{
    using System;

    public class SimpleMathExam : Exam
    {
        private int problemsSolved;

        public SimpleMathExam(int problemsSolved)
        {
            this.ProblemsSolved = problemsSolved;
        }

        public int ProblemsSolved
        {
            get
            {
                return this.problemsSolved;
            }

            private set
            {
                if (value < 0)
                {
                    value = 0;
                }

                const int DefaultMaxProblemSolved = 10; // Life scope ftw.
                if (value > DefaultMaxProblemSolved)
                {
                    value = 10;
                }

                this.problemsSolved = value;
            }
        }

        public override ExamResult Check()
        {
            ExamResult examResult;
            if (this.ProblemsSolved == 0)
            {
                examResult = new ExamResult(2, 2, 6, "Bad result: nothing done.");
                return examResult;
            }
            else if (this.ProblemsSolved == 1)
            {
                examResult = new ExamResult(4, 2, 6, "Average result: nothing done.");
                return examResult;
            }
            else if (this.ProblemsSolved == 2)
            {
                examResult = new ExamResult(6, 2, 6, "Average result: nothing done.");
                return examResult;
            }
            else
            {
                throw new ArgumentException(nameof(this.problemsSolved), "Not valid numbers of solved problems.");
            }
        }
    }
}
