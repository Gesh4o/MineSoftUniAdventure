namespace _03.CompanyHierarchy
{
    public class RegularEmployee : Employee
    {
        public RegularEmployee(string id, string firstName, string lastName, decimal salary, DepartmentType department) 
            : base(id,firstName,lastName,salary,department)
        {

        }
    }
}
