using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class task4
    {
        public class MyStack<T>
        {
            private List<T> stack = new List<T>();
            
            public void Push(T item)
            {
                stack.Add(item);
            }
            public T Pop()
            {
                T item = stack[stack.Count - 1];
                stack.RemoveAt(stack.Count - 1);
                return item;

            }
            public T Peek()
            {
                return stack[stack.Count - 1];
            }
        }
        static void Main(string[] args)
        {
            MyStack<int> stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Poped item: {stack.Pop()}");
            Console.WriteLine($"Peeked item: {stack.Peek()}");
        }
    }
}
