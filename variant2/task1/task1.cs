using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class task1
    {
        static void Main(string[] args)
        {
            // Polymorphism in OOP allows methods to behave differently based on the object that is calling them.

            // Overriding
            // same name and parameters 
            // uses 'virtual' in the base class, and 'override' in the derived class 
            // decided at runtime
            Dog myDog = new Dog();
            myDog.Sound();

            //Overloading
            // same method name, but different parameters 
            // occurs within the same class
            // decided at compile time
            Calculator calc = new Calculator();

            int result1 = calc.Add(3, 6);
            double result2 = calc.Add(2.5, 5.3);

            Console.WriteLine($"Result 1: {result1}");
            Console.WriteLine($"Result 2: {result2}");
        }
        class Animal
        {
            public virtual void Sound()
            {
                Console.WriteLine("Animal's sound");
            }
        }
        class Dog : Animal
        {
            public override void Sound()
            {
                Console.WriteLine("Dog barks");
            }
        }

        class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public double Add(double a, double b)
            {
                return a + b;
            }
        }
    }
}
