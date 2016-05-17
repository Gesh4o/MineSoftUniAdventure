namespace _01.HumanStudentWorker
{
    using System;

    public class Worker : Human
    {
        private int workHoursPerDay;
        private double weekSalary;

        public Worker(string firstName, string lastName, int workHoursPerDay, double weekSalary) :base(firstName,lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Work hours cannot be negative!");
                }

                this.workHoursPerDay = value;
            }
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Week salary cannot be negative!");
                }

                this.weekSalary = value;
            }
        }

        public override string ToString()
        {
            string result = string.Format("Name: {0} {1}\nWork hours per day: {2}\nWeek salary: {3}"
                , this.FirstName, this.LastName, this.workHoursPerDay, this.weekSalary);
            return result;
        }
    }
}
