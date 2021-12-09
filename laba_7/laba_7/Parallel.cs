using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace laba_7
{
    class Parallel
    {
        static CountdownEvent countOfActions;
        public static void WaitAll(Task[] Tasks)
        {
            countOfActions = new CountdownEvent(Tasks.Length);
            foreach(Task task in Tasks)
            {
                ThreadPool.QueueUserWorkItem(Execute, task);
            }
            countOfActions.Wait();
        }

        private static void Execute(object task)
        {
            Task method = (Task)task;
            method.Invoke();
            countOfActions.Signal();
        }
    }
}
