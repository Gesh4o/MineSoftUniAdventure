using System;

class WorkHours
{
    static void Main()
    {
        int hours = int.Parse(Console.ReadLine());
        int days = int.Parse(Console.ReadLine());
        int percentProductivity = int.Parse(Console.ReadLine());
        double percent = percentProductivity *0.01;
        double workDays = (days - days * 0.1);
        double estimatedWorkHours = workDays * 12;
        double realWorkHours = Math.Floor(estimatedWorkHours*percent);

         if (hours <= realWorkHours)
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0}",realWorkHours - hours);
        } 
        else
        {
            Console.WriteLine("No");
            Console.WriteLine("{0}",realWorkHours - hours);
        }
    }
}