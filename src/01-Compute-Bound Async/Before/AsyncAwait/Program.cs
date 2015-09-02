using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            UseTasks();
        }

        private static void UseTasks()
        {
            const int units = 5;
            Console.WriteLine("Number of tasks:");

            int count = int.Parse(Console.ReadLine());
            var tasks = new Task[count];

            for (int i = 0; i < count; i++)
            {
                var workerName = string.Format("Task {0}", i + 1);
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
