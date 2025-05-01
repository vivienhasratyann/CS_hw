using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class task5
    {
        static void Main(string[] args)
        {
            // Rectangle
            rectangle myRectangle = new rectangle(5, 10); // width = 5, length = 10
            myRectangle.calculate_area();

            // Circle
            circle myCircle = new circle(7); // radius = 7
            myCircle.calculate_area();

        }

        public abstract class Shape
        {
            public abstract void calculate_area();
        }

        public class rectangle : Shape
        {
            public int width { get; set;}
            public int height { get; set;}
            public rectangle (int Width, int Height)
            {
                width = Width;
                height = Height;
            }
            public override void calculate_area()
            {
                Console.WriteLine($"The area = {width * height}");
            }
        }

        public class circle : Shape
        {
            public int radius {  get; set; }
            public circle(int Radius)
            {
                radius = Radius;
            }
            
            public override void calculate_area()
            {
                Console.WriteLine($"The area = {Math.PI*radius*radius}");
            }
        }

    }
}
