using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    class Program
    {
        private static int counter = 0;
        private static object locker = new object();

        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                    Thread.Sleep(1);
                }
            });
            t1.Start();
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    lock (locker)
                    {
                        counter++;
                    }
                    Thread.Sleep(1);
                }
            });
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(counter);
            Console.ReadKey();

        }
    }
}
