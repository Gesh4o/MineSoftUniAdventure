namespace _03.CompanyHierarchy
{
    using Interfaces;
    using System.Collections.Generic;
    using System;

    public class Manager : Employee, IManager
    {
        private List<Employee> comandedEmployees;

        public Manager(string id, string firstName, string lastName,decimal salary,DepartmentType department) 
            : base(id, firstName, lastName, salary, department)
        {
            this.comandedEmployees = new List<Employee>();
        }

        public IEnumerable<Employee> ComandedEmployees
        {
            get
            {
                return this.comandedEmployees;
            }
        }

        public override string ToString()
        {
            string employeesNames = GetNames(this.comandedEmployees);
            string result = string.Format("Name: {0} {1} \nID: {2} \nSalary: {3} \nDepartment: {4}\nList of commanded employees:\n{5}"
                , this.FirstName, this.LastName, this.ID, this.Salary, this.Department, employeesNames);
            return result;
        }

        private string GetNames(IEnumerable<Employee> employees)
        {
            string employeeName = string.Empty;
            foreach (var empoyee in employees)
            {
                Employee tempEmployee = empoyee;
                employeeName += string.Format("Name: {0} {1} \nID:{2}\n", tempEmployee.FirstName, tempEmployee.LastName, tempEmployee.ID);
            }
            return employeeName;
        }

        public void AddEmployeesToCommand(Employee employee)
        {
            if (employee == null)
            {
                throw new ArgumentNullException("Employee cannot be null!");
            }
            comandedEmployees.Add(employee);
        }
    }
}
