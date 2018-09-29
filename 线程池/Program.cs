using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadPool.QueueUserWorkItem(state=>
            //{
            //    for (int i = 0; i < 500; i++)
            //    {
            //        Console.WriteLine(i);
            //    }
            //});

            //for (int i = 0; i < 500; i++)
            //{
            //    Console.WriteLine("hi");
                
            //}

            for (int i = 0; i < 500; i++)
            {
                Console.WriteLine("hi");
                ThreadPool.QueueUserWorkItem(state =>
                {
                    Console.WriteLine(state);
                },i);
            }

            Console.ReadKey();
        }
    }
}
