using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestThread1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread thread = new Thread(Run1);
            //thread.Start();
            //while (true)
            //{
            //    Console.WriteLine("main thread: " + DateTime.Now);
            //}

            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread(() =>
            //    {
            //        Console.WriteLine("i=" + i);
            //    });
            //    thread.Start();

            //}




            //for (int i = 0; i < 10; i++)
            //{
            //    Thread thread = new Thread((j) =>
            //    {
            //        Console.WriteLine("i=" + j);
            //    });
            //    thread.Start(i);

            //}

            //Thread thread = new Thread(()=>
            //{
            //    while (true)
            //    {
            //        Console.WriteLine("time:" + DateTime.Now);
            //        Thread.Sleep(10000);
            //    }
            //});
            //thread.Start();



            //Thread t1 = new Thread(() => {
            //    Console.WriteLine("t1 will sleep");
            //    Thread.Sleep(5000);
            //    Console.WriteLine("t1 awake");
            //});
            //t1.IsBackground = true;
            //t1.Start();


            int i = 0, j = 0;
            Thread t1 = new Thread(() => {
                while (i<1000000000)
                {
                    i++;
                    Console.WriteLine("t1");
                }
            });
            //t1.Priority = ThreadPriority.Highest;
            t1.Start();
            Thread t2 = new Thread(() => {
                while (j < 1000000000)
                {
                    j++;
                    Console.WriteLine("t2");
                }
            });
            //t2.Priority = ThreadPriority.Highest;
            t2.Start();
            Thread.Sleep(100);
            Console.WriteLine("i=" + i + ",j=" + j);
            //t2.Abort();
            Thread.Sleep(100);
            Console.WriteLine("i=" + i + ",j=" + j);
           
            Console.ReadKey();

            //Console.ReadKey();
        }

            static void Run1()
        {
            while (true)
            {
                Console.WriteLine("sub thread: " + DateTime.Now);
            }
        }

    }
}
