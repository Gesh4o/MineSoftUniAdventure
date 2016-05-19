namespace _08.EmployeeData
{
    using System;

    public class EmployeeDataMain
    {
        public static void Main(string[] args)
        {
            string firstName = Console.ReadLine();
            string secondName = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            char gender = Console.ReadLine()[0];
            long id = long.Parse(Console.ReadLine());
            long employeeNumber = long.Parse(Console.ReadLine());

            string outputFormat = @"First name: {0}
Last name: {1}
Age: {2}
Gender: {3}
Personal ID: {4}
Unique Employee number: {5}
";
            Console.WriteLine(outputFormat, firstName, secondName, age, gender, id, employeeNumber);
        }
    }
}
