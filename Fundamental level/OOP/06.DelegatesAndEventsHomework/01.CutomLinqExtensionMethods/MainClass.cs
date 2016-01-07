namespace _01.CutomLinqExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class MainClass
    {
        static void Main()
        {
            List<int> intList = new List<int>() { 1, 3, 4, 5, 67, 8, 17 };
            string result = string.Join(", ", intList.WhereNot(number => number % 2 == 0));
            Console.WriteLine(result);
            Student Pesho = new Student("Pesho", 2);
            Student Gosho = new Student("Gosho", 3);
            List<Student> stList = new List<Student>() { Pesho, Gosho };
            Console.WriteLine(stList.Max(st => st.Grade));



        }
    }
}
