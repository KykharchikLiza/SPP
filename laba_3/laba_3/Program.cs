using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba_3
{
    class Program
    {

        private static Mutex mutex = new Mutex();
        static void Main(string[] args)
        {
           
            for(int i = 0; i < 6; i++)
            {
                Thread myThread = new Thread(proc);
                myThread.Start();
            }
            Console.ReadLine();
        }

        public static void proc()
        {
            mutex.Lock();
            Console.WriteLine("Start thread " + Thread.CurrentThread.ManagedThreadId);
            for(int i = 0; i < 3; i++)
            {
                Console.WriteLine("thread " + Thread.CurrentThread.ManagedThreadId + " step " + i);
            }
            Console.WriteLine("Finish thread " + Thread.CurrentThread.ManagedThreadId);
            mutex.Unlock();
        }
    }
}
