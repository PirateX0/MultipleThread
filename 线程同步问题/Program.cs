using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程同步问题
{
    class Program
    {
        private static int counter = 0;
        static void Main(string[] args)
        {
          
              Thread t1 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    counter++;
                      Thread.Sleep(1);
                  }
            });
            t1.Start();
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    counter++;
                    Thread.Sleep(1);
                }
            });
            t2.Start();

            //while (t1.IsAlive) { };
            //while (t2.IsAlive) { };

            t1.Join();
            t2.Join();

            //if (t1.IsAlive==false&&t2.IsAlive==false)
            //{
            //    Console.WriteLine(counter);
            //}


            Console.WriteLine(counter);

            Console.ReadKey();

        }
    }
}
