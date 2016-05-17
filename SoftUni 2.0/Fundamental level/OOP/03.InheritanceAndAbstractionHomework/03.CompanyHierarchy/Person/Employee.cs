namespace _03.CompanyHierarchy
{
    using System;
    using Interfaces;

    public abstract class Employee : Person, IEmployee
    {
        private decimal salary;
        private DepartmentType department;

        protected Employee(string id, string firstName, string lastName, decimal salary, DepartmentType department) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
            this.department = department;
        }

        public decimal Salary
        {
            get
            {
                return this.salary;
            }

            set
            {
                if (value <0M)
                {
                    throw new ArgumentOutOfRangeException("Salary cannot be negative!");
                }
                this.salary = value;
            }
        }

        public DepartmentType Department {get;}

        public override string ToString()
        {
            string result = string.Format("Name: {0} {1} \nID: {2} \nSalary: {3} \nDepartment: {4}"
                , this.FirstName, this.LastName, this.ID, this.salary, this.department);
            return result;
        }

        private bool CheckLegitimacy(string value, string[] departments)
        {
            bool isLegit = false;
            foreach (var department in departments)
            {
                if (department == value)
                {
                    isLegit = true;
                }
            }
            return isLegit;
        }
    }
}
