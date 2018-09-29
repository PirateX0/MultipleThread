using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 打印问题
{
    class Program
    {
        static object locker = new object();
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(()=> 
            {
                for (int i = 0; i < 50; i++)
                {
                    Out("1111111111111");
                }
            });
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 50; i++)
                {
                    Out("2222222222222");
                }
            });

            thread1.Start();
            thread2.Start();

            Console.ReadKey();
        }

        //[MethodImpl(MethodImplOptions.Synchronized)]
        static void Out(String str)
        {
            lock (locker)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    Console.Write(str[i]);
                }
                Console.WriteLine("");
            }
        }
    }
}
