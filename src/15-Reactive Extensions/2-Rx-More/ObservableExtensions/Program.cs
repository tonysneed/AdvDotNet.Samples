using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

/* First, we would like to eliminate the need to create a separate class that implements
 * IObserver. For this we create a generic DelegatingObserver which implements IObserver<T>
 * and accepts delegates which are called when observer is called back.
 * 
 * Second, we use an Enumerable-Observable Adapter to eliminate a separate class that
 * implements IObservable. For this we create a generic EnumerableObservableAdapter which
 * implements IObservable<T> and iterates over an IEnumerable<T> calling OnNext.
 */

namespace ObservableExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegating Observer {1}, Enumerating Observable {2}:");
            int opt = int.Parse(Console.ReadLine());
            switch (opt)
            {
                case 1:
                    Delegating();
                    break;
                case 2:
                    Adapting();
                    break;
                default:
                    Console.WriteLine("Invalid selection: {0}", opt);
                    break;
            }

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        private static void Delegating()
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;
            var delay = TimeSpan.FromSeconds(delaySeconds);

            // Get ints to observe
            int[] ints = GetInts();
            Console.WriteLine("\n\nEven numbers:");

            // Create observer and observable
            IObservable<int> observable = new ObservableEvens(ints);

            // Observe even ints
            //var observer = new EvensObserver(delaySeconds);
            observable.Subscribe(value =>
                {
                    // Add delay if item is multiple of 4
                    if (value % 4 == 0) Program.Delay(delay);

                    // Print value
                    Console.WriteLine(value);
                }, () => Console.WriteLine("Done"));
        }

        private static void Adapting()
        {
            // Get seconds to delay
            int delaySeconds = GetDelay();
            if (delaySeconds == 0) return;
            var delay = TimeSpan.FromSeconds(delaySeconds);

            // Get ints to observe
            int[] ints = GetInts();
            Console.WriteLine("\n\nEven numbers:");

            // Create observer and observable
            //var observable = new ObservableEvens(ints, async);
            IObservable<int> observable = ints.ToObservable();

            // Observe even ints
            //var observer = new EvensObserver(delaySeconds);
            observable.Subscribe(value =>
            {
                // Add delay if item is multiple of 4
                if (value % 4 == 0) Program.Delay(delay);

                // If event print value
                if (value % 2 == 0) Console.WriteLine(value);
            }, () => Console.WriteLine("Done"));
        }

        #region Helper Methods

        private static int[] GetInts()
        {
            int[] ints = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            return ints;
        }

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
