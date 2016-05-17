namespace _04.StudentClass
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MainClass
    {
        public static void Main()
        {
            Student Pesho = new Student("Pesho",13);
            Student Gosho = new Student("Gosho", 8);

            Pesho.OnStudentParamsChanged += Pesho_OnStudentParamsChanged;
            Pesho.Name = "Minka";
            Pesho.Age = 19;


        }

        private static void Pesho_OnStudentParamsChanged(Student student, StudentParamChangedEventAgs eventArgs)
        {
            Console.WriteLine("Property changed: {0} (from {1} to {2})", eventArgs.PropertyName, eventArgs.OldValue, eventArgs.NewValue);

        }
    }
}
