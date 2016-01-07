namespace _02.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cat : Animals
    {
        public Cat(string name, string gender, int age) : base(name, gender, age)

        {

        }

        public override void ProduceSound()
        {
            Console.WriteLine("Meeeeow!");
        }

    }
}
