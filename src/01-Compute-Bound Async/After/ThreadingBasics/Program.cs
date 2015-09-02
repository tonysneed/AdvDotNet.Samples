using System;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            UseMainThread();
            //UseManualThread();
            //UseAsyncDelegates();
            //UseTasks();
        }

        private static void UseMainThread()
        {
            // Synchronous invocation
            Thread.CurrentThread.Name = "Main Thread";

            const int units = 5;
            Console.WriteLine("Number of workers:");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int result = DoWork(units);
                Console.WriteLine("{0} completed: {1}", "Main Thread", result);
            }
        }

        private static void UseManualThread()
        {
            // Manual threads:
            // - long running operation
            // - changing a property of the thread (interop, priority, etc)

            const int units = 5;
            Console.WriteLine("Number of workers:");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                var workerName = string.Format("Worker Thread {0}", i + 1);
                var worker = new Thread(u =>
                {
                    int result = DoWork(u);
                    Console.WriteLine("{0} completed: {1}", workerName, result);
                });
                worker.Name = workerName;
                worker.Start(units);
            }
        }

        private static void UseAsyncDelegates()
        {
            // Pooled threads using delegates:
            // - short running operation
            // - no need to change a property of the thread

            Console.WriteLine("Number of workers:");
            int count = int.Parse(Console.ReadLine());

            const int units = 5;
            var waits = new WaitHandle[count];

            for (int i = 0; i < count; i++)
            {
                var workerName = string.Format("Worker Thread {0}", i + 1);
                Func<object, int> worker = DoWork;
                waits[i] = worker.BeginInvoke(units, WorkCompleted, workerName).AsyncWaitHandle;
            }
            WaitHandle.WaitAll(waits);
        }

        private static void WorkCompleted(IAsyncResult ar)
        {
            var workerName = (string)ar.AsyncState;
            var worker = (Func<object, int>) ((AsyncResult) ar).AsyncDelegate;
            int result = worker.EndInvoke(ar);
            Console.WriteLine("{0} completed: {1}", workerName, result);
        }

        private static void UseTasks()
        {
            // Pooled threads using tasks:
            // - async return values better with Funcs
            // - continuation callbacks are cleaner as lambda
            // - captures local variables

            const int units = 5;
            Console.WriteLine("Number of workers:");

            int count = int.Parse(Console.ReadLine());
            var tasks = new Task[count];

            for (int i = 0; i < count; i++)
            {
                var workerName = string.Format("Worker Thread {0}", i + 1);
                var task = new Task<int>(DoWork, units);
                tasks[i] = task;

                task.ContinueWith(t =>
                {
                    Console.WriteLine("{0} completed: {1}", workerName, t.Result);
                });

                task.Start();
            }
            Task.WaitAll(tasks);
        }

        private static int DoWork(object arg)
        {
            string threadName = Thread.CurrentThread.IsThreadPoolThread
                ? "Thread Pool Thread"
                : Thread.CurrentThread.Name;
            int max = (int)arg;

            int result = 1;
            for (int i = 0; i < max; i++)
            {
                Console.WriteLine("{0} working {1} ...", threadName, i + 1);
                Thread.Sleep(100);
                result++;
            }
            return result;
        }
    }
}
