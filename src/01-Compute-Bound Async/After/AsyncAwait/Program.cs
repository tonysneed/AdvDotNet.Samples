using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = UseTasks();
            task.Wait();
        }

        private async static Task UseTasks()
        {
            const int units = 5;
            Console.WriteLine("Number of tasks:");

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var workerName = string.Format("Task {0}", i + 1);

                int result = await Task.Run(() => DoWork(units));

                // Compiled as a continuation callback
                Console.WriteLine("{0} completed: {1}", workerName, result);
            }
        }

        private static Task<int> DoWork(object arg)
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
            return Task.FromResult(result);
        }
    }
}
