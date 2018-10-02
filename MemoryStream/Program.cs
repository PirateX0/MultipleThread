using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryStream
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person { Name = "dalong", Age = 18 });
            persons.Add(new Person { Name = "ava", Age = 17 });

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            using (StreamWriter writer = new StreamWriter(ms))
            using (FileStream fs = File.OpenWrite(@"c:\temp\1.txt"))
            {
                    foreach (var p in persons)
                    {
                        writer.WriteLine(p.Name + ":" + p.Age);
                    }
                writer.Flush();
                ms.Position = 0;
                ms.CopyTo(fs);
            }
        }


    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
