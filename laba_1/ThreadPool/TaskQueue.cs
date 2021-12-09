using System;
using System.Collections.Generic;
using System.Threading;

namespace ThreadPool
{
    class TaskQueue
    {
        private Queue<Thread> threadPool;
        private TaskDelegate taskDelegate;

        public TaskQueue(int count)
        {
            threadPool = new Queue<Thread>();
            InitPool(count);
        }

        private void InitPool(int count)
        {
            for(int i = 0; i < count; i++)
            {
                Thread myThread = new Thread(new ThreadStart(ThreadProc));//создаем новый поток
                myThread.Name = $"{i}";//имя потока
                myThread.Start(); //запускаем поток
                threadPool.Enqueue(myThread); //добавляем в конец очереди
            }
        }

        public void EnqueueTask(TaskDelegate task) //постановка в очередь и послед выполнение
        {
            lock (this)
            {
                taskDelegate += task;
            }
        }

        private void ThreadProc()
        {
            while (true)
            {
                lock (this)
                {
                    if (taskDelegate != null)
                    {
                        taskDelegate();
                        taskDelegate = null;
                    }
                }
            }
        }
    }
}
