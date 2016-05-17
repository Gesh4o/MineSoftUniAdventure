namespace _02.Animals
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gender = "female") 
            : base(name, gender, age)
        {

        }
        
    }

}
