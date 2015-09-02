using System;
using System.Threading;

namespace KernelLocks.WaitHandles
{
    class Program
    {
        private const int ThreadCount = 3;

        static void Main(string[] args)
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                var worker = new Thread(DoWork)
                {
                    Name = string.Format("Worker Thread {0}", i + 1),
                    IsBackground = true
                };
                worker.Start();
            }
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
