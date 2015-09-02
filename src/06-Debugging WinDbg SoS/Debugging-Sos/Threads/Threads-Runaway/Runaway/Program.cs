using System;
using System.Threading;

namespace Runaway
{
    class Program
    {
        static long _ticks;
        const int Factor = 2;

        static void Main(string[] args)
        {
            Console.WriteLine("Interval (1-10):");
            Console.WriteLine("Press any key to exit ...");
            string numberString = Console.ReadLine();
            int numberInt = int.Parse(numberString);
            _ticks = numberInt * 1000;

            var worker1 = new Thread(SomeMethod) { Name = "Worker 1 Thread" };
            worker1.Start(numberInt);

            var worker2 = new Thread(SomeMethod) { Name = "Worker 2 Thread" };
            worker2.Start(numberString);
        }

        static void SomeMethod(object arg)
        {
            while (!Console.KeyAvailable)
            {
                try
                {
                    int i = (int)arg;
                    Thread.Sleep(TimeSpan.FromTicks(_ticks));
                }
                catch (Exception)
                {
                    Thread.Sleep(TimeSpan.FromTicks(_ticks * Factor));
                }
            }
        }
    }
}
