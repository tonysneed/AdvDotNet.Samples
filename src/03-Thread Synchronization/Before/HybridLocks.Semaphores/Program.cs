using System;
using System.Threading;

namespace HybridLocks.Semaphores
{
    class Program
    {
        static void Main(string[] args)
        {
            // Schedule some work on a background thread
            var worker = new Thread(DoWork)
            {
                Name = "Worker Thread",
                IsBackground = true
            };

            // Start the thread
            worker.Start();
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
        }
    }
}