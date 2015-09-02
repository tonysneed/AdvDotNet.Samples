using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace RxBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Event Filtering {1}, Projection {2}, Buffering {3}, Windowing {4}, Grouping {5}:");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Filtering();
                    break;
                case 2:
                    Projection();
                    break;
                case 3:
                    Buffering();
                    break;
                case 4:
                    Windowing();
                    break;
                case 5:
                    Grouping();
                    break;
                default:
                    Console.WriteLine("Invalid selection: {0}", opt);
                    break;
            }

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        private static void Filtering()
        {
            // Get ints to observe
            int[] ints = GetInts();
            Console.WriteLine("\nEven numbers:");

            // Create observable and filter on even values
            IObservable<int> observable = ints.ToObservable()
                .Where(value => value % 2 == 0);

            // Observe and print
            observable.Subscribe(value =>
            {
                Console.WriteLine(value);
            }, () => Console.WriteLine("Done"));
        }

        private static void Projection()
        {
            // Create observable, then filter and project
            Console.WriteLine("\nInts projected as strings:");
            IObservable<string> observable =
                from i in Observable.Range(1, 12)
                where i % 2 == 0
                select i.ToString("C");

            // Observe and print
            observable.Subscribe(value =>
            {
                Console.WriteLine(value);
            }, () => Console.WriteLine("Done"));
        }

        private static void Buffering()
        {
            // Get ints to observe
            int[] ints = GetInts();
            Console.WriteLine("\nEven numbers buffered by 3:");

            // Create observable and filter on even values
            IObservable<IList<int>> observable = ints.ToObservable()
                .Buffer(3);

            // Observe and print
            var count = 1;
            observable.Subscribe(values =>
            {
                Console.WriteLine("Batch {0}:", count);
                foreach(var i in values)
                    Console.WriteLine("\t{0}", i);
                count++;
            }, () => Console.WriteLine("Done"));
        }

        private static void Windowing()
        {
            // Create observable, then filter and project
            Console.WriteLine("\nStrings in 2-member windows:");
            var observable = Names().ToObservable().Window(2);

            // Observe and print
            int count = 1;
            observable.Subscribe(w =>
            {
                // New window
                Console.WriteLine("Window: {0}", count);

                // Print window members
                w.Subscribe(n => Console.WriteLine("\t{0}", n));
                count++;
            });
        }

        private static void Grouping()
        {
            // Create observable, then filter and project
            Console.WriteLine("\nStrings grouped by length:");
            var observable =
                from n in Names().OrderBy(n => n.Length).ToObservable()
                group n by n.Length;

            // Observe and print
            observable.Subscribe(g =>
            {
                // Print group key
                Console.WriteLine("Group: {0}", g.Key);

                // Print group members
                g.Subscribe(n => Console.WriteLine("\t{0}", n));
            }, () => Console.WriteLine("Done"));
        }

        static IEnumerable<string> Names()
        {
            string[] names = { "Burke", "Connor", "Frank",
                "Everett", "Albert", "Johnny", "Harris", "Jeremy" };
            return names;
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

        private static int[] GetInts()
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return ints;
        }

        public static void Delay(TimeSpan delay)
        {
            string name = Thread.CurrentThread.Name;
            if (name == null)
                name = Thread.CurrentThread.IsThreadPoolThread
                    ? "Thread Pool Thread"
                    : "Main Thread";
            Console.WriteLine("{0} waiting {1} seconds for next item ...",
                name, delay.TotalSeconds);
            Thread.Sleep(delay);
        }
        #endregion
    }
}
