namespace Exercise
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Threading;

    class ExerciseMain
    {
        private static DataModel dbContext = new DataModel();
        static void Main(string[] args)
        {
        }

        private static void RemoveAddressesByTown()
        {
            string townName = Console.ReadLine();

            IEnumerable<Employee> employees = dbContext.Employees.Where(e => e.Address.Town.Name == townName);

            foreach (Employee e in employees)
            {
                e.Address.TownID = null;
            }

            IEnumerable<Address> addresses = dbContext.Addresses.Where(t => t.Town.Name == townName);
            int count = addresses.Count();

            foreach (Address address in addresses)
            {
                dbContext.Addresses.Remove(address);
            }

            dbContext.SaveChanges();
            if (count == 1)
            {
                Console.WriteLine($"1 address in {townName} was deleted");
            }
            else
            {
                Console.WriteLine($"{count} addresses in {townName} were deleted");
            }
        }

        private static void FindEmployeesWithFirstNameStarting()
        {
            IEnumerable<Employee> employees = dbContext.Employees.Where(e => e.FirstName.StartsWith("SA"));
            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary})");
            }
        }

        private static void IncreaseSalaries()
        {
            IEnumerable<Employee> employees = dbContext.Employees
                .Where(
                e => e.Department.Name == "Engineering" ||
                    e.Department.Name == "Tool Design" ||
                    e.Department.Name == "Marketing" ||
                    e.Department.Name == "Information Services");

            foreach (Employee e in employees)
            {
                e.Salary += e.Salary * 0.12M;

                Console.WriteLine($"{e.FirstName} {e.LastName} (${e.Salary})");
            }

            dbContext.SaveChanges();
        }

        private static void FindLastTenProjects()
        {
            CultureInfo ci = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = ci;
            var projects = dbContext.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(
                p => new
                {
                    Name = p.Name,
                    Description = p.Description,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                });

            foreach (var p in projects)
            {
                string endDate = p.EndDate.HasValue ? p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : string.Empty;
                Console.WriteLine($"{p.Name} {p.Description} {p.StartDate.ToString("M/d/yyyy h:mm:ss tt")} {endDate}");
            }
        }

        private static void NativeSqlQuery()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var names = dbContext.Database.SqlQuery<string>(
                "SELECT DISTINCT FirstName FROM Employees AS e LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID  INNER JOIN Projects AS p ON p.ProjectID = ep.ProjectID  WHERE YEAR(p.StartDate) = 2002");
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
            sw.Reset();

            sw.Start();
            var namesInLinq = dbContext.Employees.Where(e => e.Projects.Any(p => p.StartDate.Year == 2002)).Select(e => e.FirstName);
            sw.Stop();

            Console.WriteLine(sw.Elapsed);
        }

        private static void DepartmentsWithMoreThanFive()
        {
            var departments = dbContext.Departments
                  .Where(d => d.Employees.Count > 5)
                  .OrderBy(d => d.Employees.Count);

            foreach (var dep in departments)
            {
                Console.WriteLine($"{dep.Name} {dep.Manager.FirstName}");
                foreach (var em in dep.Employees)
                {
                    Console.WriteLine($"{em.FirstName} {em.LastName} {em.JobTitle}");
                }
            }
        }

        private static void EmployeeWithIdProjects()
        {
            Employee e = dbContext.Employees.Find(147);

            Console.WriteLine($"{e.FirstName} {e.LastName} {e.JobTitle}");

            foreach (Project p in e.Projects.OrderBy(p => p.Name))
            {
                Console.WriteLine($"{p.Name}");
            }
        }

        private static void AddressesByTownName()
        {
            var addresses = dbContext.Addresses
                .Select(
                a =>
                new
                {
                    TownName = a.Town.Name,
                    AddresText = a.AddressText,
                    Count = dbContext.Employees
                        .Count(e => e.AddressID == a.AddressID)
                })
                .OrderByDescending(a => a.Count)
                .ThenBy(a => a.TownName)
                .Take(10);

            foreach (var address in addresses)
            {
                Console.WriteLine($"{address.AddresText}, {address.TownName} - {address.Count} employees");
            }
        }

        private static void EmpoyeesWithProjects()
        {
            IEnumerable<Employee> employees = dbContext.Employees
                .Where(e => e.Projects.Count(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003) > 0)
                .Take(30);

            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.Manager.FirstName}");
                foreach (Project p in e.Projects)
                {
                    Console.WriteLine($"--{p.Name} {p.StartDate} {p.EndDate}");
                }
            }
        }

        private static void DeleteProject()
        {
            Project p = dbContext.Projects.Find(2);
            foreach (Employee e in p.Employees)
            {
                e.Projects.Remove(p);
            }

            dbContext.Projects.Remove(p);
            dbContext.SaveChanges();

            IEnumerable<string> projects = dbContext.Projects.Take(10).Select(pr => pr.Name);

            foreach (string project in projects)
            {
                Console.WriteLine(project);
            }
        }

        private static void AddNewAddressUpdateEntity()
        {
            Address ad = new Address()
            {
                AddressText = "Vitoshka 15",
                TownID = 4
            };

            Employee nakov = dbContext.Employees.FirstOrDefault(e => e.LastName == "Nakov");
            nakov.Address = ad;

            dbContext.SaveChanges();

            IEnumerable<string> addresses = dbContext.Employees.OrderByDescending(e => e.AddressID).Take(10).Select(e => e.Address.AddressText);

            foreach (var address in addresses)
            {
                Console.WriteLine(address);
            }
        }

        private static void AllEmployeesFromDepartment()
        {
            IEnumerable<Employee> employees = dbContext.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName);

            foreach (Employee employee in employees)
            {
                Console.WriteLine(
                    $"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:F2}");
            }
        }

        private static void EmployeesWithSalariesOverSomeValue()
        {
            IEnumerable<string> employeeNames = dbContext.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => e.FirstName);

            foreach (string employee in employeeNames)
            {
                Console.WriteLine(employee);
            }
        }

        private static void AllEmployeesInfo()
        {
            IEnumerable<Employee> employees = dbContext.Employees;
            foreach (Employee e in employees)
            {
                Console.WriteLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary}");
            }
        }
    }
}
