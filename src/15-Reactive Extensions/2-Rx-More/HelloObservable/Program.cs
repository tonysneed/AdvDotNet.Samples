using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/* First we look at Enumerable for pulling data from a source, which controls how enumeration
 * takes place. Here we are enumerating even integers with a delay for multiples of 4.
 * 
 * Then we implement IObservable for pushing even integers to an IObserver, also with a delay
 * for multiples of 4. In addition, we specify an async option for pushing on background threads.
 */

namespace HelloObservable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enumerate {1}, Observe {2}, Observe Async {3}:");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Enumerate();
                    break;
                case 2:
                    Observe(false);
                    break;
                case 3:
                    Observe(true);
                    break;
                default:
                    Console.WriteLine("Invalid selection: {0}", opt);
                    break;
            }

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        /// <summary>
        /// Demonstrates standard enumeration pattern.
        /// </summary>
        static void Enumerate()
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;

            // Get ints to enumerate
            int[] ints = GetInts();

            // Enumerate even ints
            Console.WriteLine("\n\nEven numbers:");
            IEnumerable<int> evens = new EnumerableEvens(ints, delaySeconds);
            foreach (var i in evens)
            {
                Console.WriteLine(i);
            }
        }

        /// <summary>
        /// Demonstrates standard observer pattern.
        /// </summary>
        /// <param name="async">True for async callbacks</param>
        private static void Observe(bool async)
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;

            // Get ints to observe
            int[] ints = GetInts();

            // Create observable and observer
            IObservable<int> observable = new ObservableEvens(ints, async);
            IObserver<int> observer = new EvensObserver(delaySeconds);

            // Observe even ints
            Console.WriteLine("\n\nEven numbers:");
            observable.Subscribe(observer);
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
