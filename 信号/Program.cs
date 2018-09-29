using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 信号
{
    class Program
    {
        static void Main(string[] args)
        {
            //ManualResetEvent mre = new ManualResetEvent(false);
            ////构造函数false表示“初始状态为关门”，设置为true则初始化为开门状态
            //Thread t1 = new Thread(() => {
            //    Console.WriteLine("wait for opening the door");
            //    mre.WaitOne();
            //    Console.WriteLine("run");
            //});
            //t1.Start();
            //Console.WriteLine("press any key to open the door");
            //Console.ReadKey();
            //mre.Set();//开门
            //Console.ReadKey();


            //ManualResetEvent mre = new ManualResetEvent(false);
            ////false表示“初始状态为关门”
            //Thread t1 = new Thread(() => {
            //    Console.WriteLine("wait for opening the door");
            //    if (mre.WaitOne(5000))
            //    {
            //        Console.WriteLine("run");
            //    }
            //    else
            //    {
            //        Console.WriteLine("5 seconds passed. I will leave.");
            //    }
            //});
            //t1.Start();
            //Console.WriteLine("press any key to open the door");
            //Console.ReadKey();
            //mre.Set();//开门
            //Console.ReadKey();

            //ManualResetEvent mre = new ManualResetEvent(false);
            ////false表示“初始状态为关门”
            //Thread t1 = new Thread(() => {
            //    while (true)
            //    {
            //        Console.WriteLine("wait for opening the door");
            //        mre.WaitOne();
            //        Console.WriteLine("run");
            //    }
            //});
            //t1.Start();
            //Console.WriteLine("press any key to open the door");
            //Console.ReadKey();
            //mre.Set();//开门
            //Console.ReadKey();
            //mre.Reset();//关门
            //Console.ReadKey();

            AutoResetEvent are = new AutoResetEvent(false);
            Thread t1 = new Thread(() => {
                while (true)
                {
                    Console.WriteLine("wait for opening the door");
                    are.WaitOne();
                    Console.WriteLine("run");
                }
            });
            t1.Start();
            Console.WriteLine("press any key to open the door");
            Console.ReadKey();
            are.Set();//开门
            Console.WriteLine("press any key to open the door");
            Console.ReadKey();
            are.Set();
            Console.WriteLine("press any key to open the door");
            Console.ReadKey();
            are.Set();
            Console.ReadKey();

        }
    }
}
