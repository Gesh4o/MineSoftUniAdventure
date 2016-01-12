namespace Exceptions_Homework.Entities.Exams
{
    using System;

    public class CSharpExam : Exam
    {
        private const int DefaultMaxScore = 100;
        private int score;

        public CSharpExam(int score)
        {
            this.Score = score;
        }

        public int Score
        {
            get
            {
                return this.score;
            }

            private set
            {
                if (value < 0 || value > DefaultMaxScore)
                {
                    throw new ArgumentOutOfRangeException();
                }

                this.score = value;
            }
        }

        public override ExamResult Check()
        {
            return new ExamResult(this.Score, 0, DefaultMaxScore, "Exam results calculated by score.");
        }
    }
}
