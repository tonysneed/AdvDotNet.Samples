using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Threading;

namespace RxAsync
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to exit ...");
            Console.WriteLine("Scheduling {1}, Scheduling with Latency {2}, Async {3}:");
            int opt = int.Parse(Console.ReadLine());
            IScheduler scheduler = null;
            switch (opt)
            {
                case 1:
                    scheduler = GetScheduler();
                    Scheduling(scheduler);
                    break;
                case 2:
                    scheduler = GetScheduler();
                    SchedulingWithLatency(scheduler);
                    break;
                case 3:
                    Async();
                    break;
                default:
                    Console.WriteLine("Invalid selection: {0}", opt);
                    break;
            }
            Console.ReadLine();
        }

        private static void Scheduling(IScheduler scheduler)
        {
            // Create observable and filter on even values
            IObservable<int> obs = from value in GetInts().ToObservable()
                                   where value % 2 == 0
                                   select value;

            // Observe and print
            Console.WriteLine("\nEven numbers:");
            obs.SubscribeOn(scheduler) // schedule callbacks
               .Subscribe(value =>
                {
                    Console.WriteLine("{0} - {1}", value, CurrentThreadName());
                }, () => Console.WriteLine("Done"));
        }

        private static void SchedulingWithLatency(IScheduler scheduler)
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;
            var delay = TimeSpan.FromSeconds(delaySeconds);

            // Create observable and filter on even values
            IObservable<int> obs = from value in GetInts(4, delay).ToObservable()
                                   where value % 2 == 0
                                   select value;

            // Observe and print
            Console.WriteLine("\n\nEven numbers:");
            obs.SubscribeOn(scheduler)
               .Subscribe(value =>
               {
                   Console.WriteLine("{0} on Thread {1}", value,
                       Thread.CurrentThread.ManagedThreadId);
               }, () => Console.WriteLine("Done"));
        }

        private static void Async()
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;
            var delay = TimeSpan.FromSeconds(delaySeconds);

            // Create observable and filter on even values
            IObservable<int> obs = from value in GetInts().ToObservable()
                                   where value % 2 == 0
                                   select value;

            // Observe and print
            Console.WriteLine("\n\nEven numbers:");
            obs.Subscribe(value =>
               {
                   var o = Observable.Start(() =>
                       {
                           if (value % 4 == 0)
                           {
                               Console.WriteLine("Sleeping on {1} {2} ...",
                                    new Random().Next(delay.Seconds),
                                    CurrentThreadName(),
                                    Thread.CurrentThread.ManagedThreadId);
                               Thread.Sleep(delay); 
                           }
                           return value;
                       });
                   o.Subscribe(i => 
                   Console.WriteLine("{0} on Thread {1}", i,
                       Thread.CurrentThread.ManagedThreadId));
               }, () => Console.WriteLine("{0} Done", CurrentThreadName()));
        }

        private static IScheduler GetScheduler()
        {
            Console.WriteLine("New Thread {N}, Thread Pool {T}, Task Pool {P}:");
            string schedOpt = Console.ReadLine().ToUpper();
            if (schedOpt == "N")
                return new NewThreadScheduler
                    (ts => new Thread(ts) { Name = "Worker Thread" });
            if (schedOpt == "T")
                return ThreadPoolScheduler.Instance;
            if (schedOpt == "P")
                return TaskPoolScheduler.Default;
            return NewThreadScheduler.Default;
        }

        private static IEnumerable<int> GetInts(int? divisor = null,
            TimeSpan? delay = null)
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            foreach (var i in ints)
            {
                if (divisor.HasValue && delay.HasValue)
                {
                    if (i % divisor == 0)
                    {
                        Console.WriteLine("Sleeping {0} seconds on {1} {2} ...",
                            delay.Value.Seconds,
                            CurrentThreadName(),
                            Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(delay.Value);
                    }
                }
                yield return i;
            }
        }

        #region Helper Methods

        private static int GetDelay()
        {
            int secondsDelay;
            Console.WriteLine("Seconds to delay:");
            string secsStr = Console.ReadKey(true).KeyChar.ToString();
            Console.Write(secsStr);
            Console.ReadKey(true);
            if (!int.TryParse(secsStr, out secondsDelay))
            {
                Console.WriteLine("Cannot convert '{0}' to an int.", secsStr);
                return 0;
            }
            return secondsDelay;
        }

        private static string CurrentThreadName()
        {
            string name = Thread.CurrentThread.Name;
            if (name == null)
                name = Thread.CurrentThread.IsThreadPoolThread
                    ? "Thread Pool Thread"
                    : "Main Thread";
            return name;
        }
        #endregion
    }
}
