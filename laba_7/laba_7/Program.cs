using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace laba_7
{
    delegate void Task();
    class Program
    {
        static void Main(string[] args)
        {
            Task[] Tasks = new Task[2];
            Tasks[0] = Task_1;
            Tasks[1] = Task_2;
           

            Parallel.WaitAll(Tasks);
            Console.WriteLine("Program finish");
            Console.ReadLine();
        }

        public static void Task_1()
        {
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Поток:" + Thread.CurrentThread.ManagedThreadId + "   " + i);
            }
        }

        public static void Task_2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Поток:" + Thread.CurrentThread.ManagedThreadId + "   " + i);
            }
        }

    }
}
