using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task4
{
    internal class task4
    {
        public class MyQueue<T>
        {
            private List<T> queue = new List<T>();

            public void Enqueue(T item)
            {
                queue.Add(item);
            }
            public T Dequeue()
            {
                if(queue.Count == 0)
                {
                    T element = default;
                    return element;
                }
                T item = queue[0];
                queue.RemoveAt(0);
                return item;
            }
            public T Peek()
            {
                return queue[0];
            }
        }


        static void Main(string[] args)
        {
            MyQueue<int> queue = new MyQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            Console.WriteLine($"Dequeued value: {queue.Dequeue()}");
            Console.WriteLine($"Peeked value: {queue.Peek()}");
        }


    }
}
