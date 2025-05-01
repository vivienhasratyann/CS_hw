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
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 2, 4, 6, 8 };
            int[] result = SumTwoArrays(array1, array2);

            Console.WriteLine($"Array 1: {string.Join(", ", array1)}");
            Console.WriteLine($"Array 1: {string.Join(", ", array2)}");
            Console.WriteLine($"Result Array: {string.Join(", ", result)}");

        }

        public static int[] SumTwoArrays(int[] array1, int[] array2)
        {
            int length = Math.Max(array1.Length, array2.Length);
            int[] sumArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                int val1 = (i < array1.Length) ? array1[i] : 0;
                int val2 = (i < array2.Length) ? array2[i] : 0;
                sumArray[i] = val1 + val2;
            }
            return sumArray;
        }
    }
}
