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

            Random rng = new Random();
            while (!Console.KeyAvailable)
            {
                try
                {
                    // Change console color to green for a random timespan
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.Clear();
                    Thread.Sleep(rng.Next(500, 1500));
                }
                finally
                {
                    // Change console color to red for a random timespan
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.Clear();
                    Thread.Sleep(rng.Next(500, 1500));
                }
            }
        }
    }
}
