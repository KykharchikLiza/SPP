using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace laba_3
{
    class Mutex
    {
        private int semaphore;

        public Mutex()
        {
            semaphore = 0;
        }

        public void Lock()
        {
            while(Interlocked.CompareExchange(ref semaphore, Thread.CurrentThread.ManagedThreadId, 0) != 0)
            {
                Thread.Sleep(100);
            }
        }

        public void Unlock()
        {
            Interlocked.CompareExchange(ref semaphore, 0, Thread.CurrentThread.ManagedThreadId);
        }
        
    }
}
