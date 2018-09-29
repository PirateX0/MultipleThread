using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 取钱问题
{
    class Program
    {
        static int money = 10000;

        static void QuQian(string name)
        {
            Console.WriteLine(name + " yuE: " + money);

            int yue = money - 1;
            Thread.Sleep(1);
            money = yue;//故意这样写，写成money--其实就没问题
            //大龙注：这样写增加了运算时间，导致线程1还没有给money赋值9999，线程2就已经给money赋值了9997，然后线程1才给money赋值9999，最终错误的计算了余额的数量。

            Console.WriteLine(name + "take 1 yuan");
            Console.WriteLine(name + " new yuE: " + money);
        }


        static void Main(string[] args)
        {
            Thread t1 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    QuQian("t1");
                }
            });
            Thread t2 = new Thread(() => {
                for (int i = 0; i < 1000; i++)
                {
                    QuQian("t2");
                }
            });
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine("yuE: " + money);
            Console.ReadKey();

        }
    }
}
