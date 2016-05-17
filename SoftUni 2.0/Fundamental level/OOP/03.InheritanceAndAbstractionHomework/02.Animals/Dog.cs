namespace _02.Animals
{
    using System;

    public class Dog : Animals
    {
        public Dog(string name, string gender, int age) : base(name, gender, age)

        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Bayyy-bayyyy!");
        }
    }
}
