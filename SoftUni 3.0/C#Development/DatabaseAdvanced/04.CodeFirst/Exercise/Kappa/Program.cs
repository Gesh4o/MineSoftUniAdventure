using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kappa
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0, k = 3; i < 3; i++, k--)
            {
                Console.Write(i ^ k);
            }

        }
    }
}
