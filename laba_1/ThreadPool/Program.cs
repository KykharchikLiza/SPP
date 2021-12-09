using System;
using System.Threading;

namespace ThreadPool
{
    delegate void TaskDelegate();

    class Program
    {
        static void Main(string[] args)
        {
            TaskQueue taskQueue = new TaskQueue(7); //создает указанное количество потоков пула

            taskQueue.EnqueueTask(One);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Two);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Three);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(One);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Two);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Three);
            Thread.Sleep(100);

           /* taskQueue.EnqueueTask(One);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Two);
            Thread.Sleep(100);

            taskQueue.EnqueueTask(Three);
            Thread.Sleep(100);*/

            Console.ReadLine();
        }

        private static void One()
        {
            Console.WriteLine($"TaskOne - {Thread.CurrentThread.Name}");
        }
        private static void Two()
        {
            Console.WriteLine($"TaskTwo - {Thread.CurrentThread.Name}");
        }
        private static void Three()
        {
            Console.WriteLine($"TaskThree - {Thread.CurrentThread.Name}");
        }
    }
}
