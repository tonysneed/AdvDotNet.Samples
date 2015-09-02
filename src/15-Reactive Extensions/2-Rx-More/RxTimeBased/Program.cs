using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reactive.Linq;
using System.Threading;

namespace RxTimeBased
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to exit ...");
            Console.WriteLine("Interval {1}, Buffering {2}, Buffering with Timeout {3}, Sampling {4}:");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Interval();
                    break;
                case 2:
                    Buffering();
                    break;
                case 3:
                    BufferingWithTimeout();
                    break;
                case 4:
                    Sampling();
                    break;
                default:
                    Console.WriteLine("Invalid selection: {0}", opt);
                    break;
            }
            Console.ReadLine();
        }

        private static void Interval()
        {
            Console.WriteLine("Generate 1/2 event stream:");
            var obs = Observable.Interval(TimeSpan.FromSeconds(.5)).Timestamp();

            obs.Subscribe(ts => Console.WriteLine("{0}: {1}", ts.Value, ts.Timestamp));

            //obs.Subscribe(ts => Console.WriteLine(
            //    "{0} on {1} at {2}", ts.Value,
            //    Thread.CurrentThread.IsThreadPoolThread ? "Thread Pool Thread" : "Main Thread",
            //    ts.Timestamp));
        }

        private static void Buffering()
        {
            Console.WriteLine("Buffer 1/2 second stream every two seconds:");
            var obs = Observable.Interval(TimeSpan.FromSeconds(.5))
                .Buffer(TimeSpan.FromSeconds(2));

            int count = 1;
            obs.Subscribe(values => 
                {
                    Console.WriteLine("Batch {0}:", count);
                    foreach (var i in values)
	                {
                        Console.WriteLine("\t{0}", i);
                    }
                    count++;
                });
        }

        private static void BufferingWithTimeout()
        {
            Console.WriteLine("Buffer 1/2 second stream every four seconds with 2 second timeout:");
            var obs = Observable.Interval(TimeSpan.FromSeconds(.5))
                .Buffer(TimeSpan.FromSeconds(4));
            var timeout = obs.Timeout(TimeSpan.FromSeconds(2));

            int count = 1;
            timeout.Subscribe(values =>
            {
                Console.WriteLine("Batch {0}:", count);
                foreach (var i in values)
                {
                    Console.WriteLine("\t{0}", i);
                }
                count++;
            }, ex => Console.WriteLine(ex.Message));
        }

        private static void Sampling()
        {
            Console.WriteLine("Sample 1/2 second stream every two seconds:");
            var obs = Observable.Interval(TimeSpan.FromSeconds(.5))
                .Sample(TimeSpan.FromSeconds(2)).Timestamp();

            obs.Subscribe(ts => Console.WriteLine("{0}: {1}", ts.Value, ts.Timestamp));
        }
    }
}
