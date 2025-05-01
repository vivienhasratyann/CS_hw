using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class task1
    {
        static void Main(string[] args)
        {
            // Value and Reference Types differ in how they store and manage data

            // Value Types
            // - Stored in stack
            // - The actual data is stored 
            // - Changing one variable doesn't affect the other one 
            // - Each one has it's own copy 

            // Examples: int, double, char, bool, struct

            int x = 10;
            int y = 20;
            Console.WriteLine("x = " + x);
            Console.WriteLine("y = " + y);


            x = y;
            Console.WriteLine("\nx = " + x);
            Console.WriteLine("y = " + y);


            x++;

            Console.WriteLine("\nx = " + x);
            Console.WriteLine("y = " + y);

            //when we change x it doesn't affect y

            //Reference Types
            // - Stored in heap 
            // - Changing one affects others
            // - Stores pointer(memory address) to the data, not the data itself
            // - Multiple variables can refer to same object

            // Examples: string, array, class

            Person p1 = new Person();
            p1.Name = "Alice";
            p1.Age = 10;

            Person p2 = new Person();
            p2.Name = "Bob";
            p2.Age = 20;
            Console.WriteLine($"\np1.Name = {p1.Name}; p1.Age = {p1.Age}");
            Console.WriteLine($"p2.Name = {p2.Name}; p2.Age = {p2.Age}");

            p1 = p2;
            Console.WriteLine($"\np1.Name = {p1.Name}; p1.Age = {p1.Age}");
            Console.WriteLine($"p2.Name = {p2.Name}; p2.Age = {p2.Age}");

            p1.Age++;
            Console.WriteLine($"\np1.Name = {p1.Name}; p1.Age = {p1.Age}");
            Console.WriteLine($"p2.Name = {p2.Name}; p2.Age = {p2.Age}");

            // changing p1 data causes p2 also to change, because after p1=p2 they are now refering to the same object
        }
        class Person
        {
            public string Name;
            public int Age;
        }


    }
}
