namespace _03.AsynchronousTimer
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
            AsyncTimer timer = new AsyncTimer(Console.WriteLine, 3, 1000);
            Console.WriteLine(timer);
            
        }
    }
}
