using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task3
{
    internal class task3
    {
        static void Main(string[] args)
        {
            int x = 6;
            int Factorial = Fact(x);
            Console.WriteLine($"Factorial of {x} = {Factorial}");
        }
        public static int Fact(int n)
        {
            if (n > 0)
            {
                return n * Fact(n - 1); 
            }
            if (n == 0) 
            {
                return n = 1;
            }
            else
            {
                Console.WriteLine($"Error: Factorial is not defined for negative numbers ({n}). Returning -1.");
                return -1;
            }
        }
    }
}
