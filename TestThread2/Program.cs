using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestThread2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(() =>
            {
                while (true)
                {
                    Console.WriteLine("t1 will sleep");
                    try
                    {
                        Thread.Sleep(5000);
                    }
                    catch (ThreadInterruptedException e)
                    {
                        Console.WriteLine("who interrupt me?"+e.Message);
                    }
                    Console.WriteLine("t1 awake");
                }


            });
            t1.Start();
            Thread.Sleep(1000);
            t1.Interrupt();

            Console.ReadKey();
        }
    }
}
