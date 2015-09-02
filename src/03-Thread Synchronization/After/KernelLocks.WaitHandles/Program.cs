using System;
using System.Threading;

namespace KernelLocks.WaitHandles
{
    class Program
    {
        // Use auto reset event to block main thread until signaled
        private const int ThreadCount = 3;
        static readonly WaitHandle[] Waits = new WaitHandle[ThreadCount];

        static void Main(string[] args)
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                // Init array element to an auto reset event
                Waits[i] = new AutoResetEvent(false);

                var worker = new Thread(DoWork)
                {
                    Name = string.Format("Worker Thread {0}", i + 1),
                    IsBackground = true
                };

                // Pass index as parameter to Start
                worker.Start(i);
            }
            WaitHandle.WaitAll(Waits);
        }

        static void DoWork(object arg)
        {
            for (int i = 0; i < 5; i++)
            {
                // Simulate work
                Console.WriteLine("{0} working {1} ...",
                    Thread.CurrentThread.Name, i + 1);
                Thread.Sleep(100);
            }

            // Get auto reset event from array and signal it (call Set)
            AutoResetEvent wait = (AutoResetEvent)Waits[(int) arg];
            wait.Set();
        }
    }
}
