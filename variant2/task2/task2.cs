using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    internal class task2
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = SumEven(array);

            Console.WriteLine($"Array = {string.Join(", ", array)}");
            Console.WriteLine(sum);
        }
        public static int SumEven(int[] array) 
        {
            int sum = 0;
            foreach (int i in array)
            {
                if( i % 2 == 0)
                {
                    sum = sum + i;
                }
            }
            return sum;
        }
    }
}
