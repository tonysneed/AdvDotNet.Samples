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

            // Create a semaphore with init count of 0 and max count of 1
            var semaphore = new SemaphoreSlim(0, 1);

            // Start the thread
            worker.Start(semaphore);

            // Wait to thread to signal semaphore
            semaphore.Wait();
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

            // Get SemaphoreSlim from arg and signal it (call Release)
            var semaphore = (SemaphoreSlim)arg;
            semaphore.Release();
        }
    }
}