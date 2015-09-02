using System;
using System.Threading;

namespace KernelLocks.Mutexes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start ...");
            Console.WriteLine("Then press any key again to stop ...");
            Console.ReadKey(true);

            // Begin thread affinity
            Thread.BeginThreadAffinity();

            // Create a named mutex
            var mutex = new Mutex(false, "StopNGo");

            Random rng = new Random();
            while (!Console.KeyAvailable)
            {
                try
                {
                    // Request ownership of the mutex
                    mutex.WaitOne();

                    // Change console color to green for a random timespan
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Thread.Sleep(rng.Next(500, 1500));
                }
                finally
                {
                    // Let the other guy have the mutex
                    mutex.ReleaseMutex();

                    // Change console color to red for a random timespan
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Thread.Sleep(rng.Next(500, 1500));
                }
            }

            // End thread affinity
            Thread.EndThreadAffinity();
        }
    }
}
