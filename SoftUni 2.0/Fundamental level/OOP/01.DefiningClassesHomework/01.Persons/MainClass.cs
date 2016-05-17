namespace _01.Persons
{
    using System;

    public class MainClass
    {
        private static void Main()
        {
            Person tom = new Person("Tom", 43, "tomsemail@abv.bg");
            Person ted = new Person("Ted", 1);

            Console.WriteLine(tom);
            Console.WriteLine(ted);
        }
    }
}