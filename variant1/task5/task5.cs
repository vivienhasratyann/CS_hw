using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task5
{
    internal class task5
    {
        public class customBox<T>
        {
            private List<T> list = new List<T>();

            public void Add(T item)
            {
                list.Add(item);
            }

            public List<T> getAll()
            {
                return new List<T>(list);
            }
        }
        static void Main(string[] args)
        {
            customBox<string> box = new customBox<string>();
            box.Add("Bonjour");
            box.Add("le");
            box.Add("Monde");

            foreach(var item in box.getAll())
            {
                Console.WriteLine(item);
            }
        }
    }
}
