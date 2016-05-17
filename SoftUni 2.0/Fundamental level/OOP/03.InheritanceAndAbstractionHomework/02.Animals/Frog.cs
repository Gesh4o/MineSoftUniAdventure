namespace _02.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Frog : Animals
    {
        public Frog(string name, string gender, int age) : base(name, gender, age)
        {
            
        }

        public override void ProduceSound()
        {
            Console.WriteLine("Croooak!");
        }
    }
}
