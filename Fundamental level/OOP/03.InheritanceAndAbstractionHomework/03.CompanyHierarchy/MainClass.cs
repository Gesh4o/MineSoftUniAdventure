namespace _03.CompanyHierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MainClass
    {
        private static void Main()
        {
            Sale motor = new Sale("Harly-Marly", "01.12.2006", 1500M);
            Sale car = new Sale("Peugeot", "02.04.2007", 25000M);
            Sale britanik = new Sale("Britanik", "03.03.2005", 2005340000M);
            Sale plane = new Sale("Boeing 747", "05.03.2010", 41341341413M);

            SalesEmployee lili = new SalesEmployee("dasdasda", "Lilia", "Vulkova", 1000M,DepartmentType.Accountng);
            SalesEmployee georgi = new SalesEmployee("dasd213", "Georgi", "Botushkov", 4500M, DepartmentType.Marketing);
            SalesEmployee georgiNikol = new SalesEmployee("dasd213", "Georgi-Kolio", "Kop-kop", 4500M, DepartmentType.Marketing);

            lili.AddSale(motor);
            lili.AddSale(car);

            georgi.AddSale(plane);

            georgiNikol.AddSale(britanik);
            georgiNikol.AddSale(plane);

            Project softwareCar = new Project("Software: Peugeot", "22.11.2013", "Software for car", "open");
            Project softwareMotor = new Project("Software: Harly-Marly", "23.03.2013", "Software for motor", "closed");

            Developer maik = new Developer("sad3441","Maik","Taison",5000M,DepartmentType.Sales);

            maik.AddProject(softwareCar);
            maik.AddProject(softwareMotor);

            Manager tosho = new Manager("122121", "Tihomir", "Spasov", 1200M, DepartmentType.Accountng);
            Manager sasho = new Manager("21435", "Sasho", "Todorov", 1550, DepartmentType.Sales);

            tosho.AddEmployeesToCommand(maik);
            tosho.AddEmployeesToCommand(georgiNikol);

            sasho.AddEmployeesToCommand(georgi);

            Employee[] allEmployees = new Employee[6] { lili, georgi, georgiNikol, maik, tosho, sasho };

            foreach (var employee in allEmployees)
            {
                Console.WriteLine(employee);
            }

            //Here trying the exception
            //Sale ship = new Sale("Titanik", "03.03.1995", 2000000000M);

            //Exception
            //Developer ronda = new Developer("Shtetenabiq", "Ronda", "Rousey", 21443M, "Poboinicite", projectsMotor);

            //Exception
            //Project softwareShip = new Project("Software: Britanik", "23.03.2004", "Software for ship", "ne go znam");
        }
    }
}
