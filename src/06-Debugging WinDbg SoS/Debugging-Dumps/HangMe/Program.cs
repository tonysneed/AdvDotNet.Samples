using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HangMe
{
    class Program
    {
        static int _timeout;
        static object lockA = new object();
        static object lockB = new object();

        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to start hanging.");
            Console.ReadLine();
            Console.WriteLine("Deadlock? {Y/N}");
            bool retry = Console.ReadLine().ToUpper() != "Y";
            _timeout = retry ? 2000 : Timeout.Infinite;

            lock (lockA)
            {
                Console.WriteLine("Main Thread has Lock A");
                var worker = new Thread(SomeMethod) { Name = "Second Thread" };
                worker.Start();
                Thread.Sleep(TimeSpan.FromSeconds(1)); // Wait a bit
                while (!Monitor.TryEnter(lockB, _timeout))
                {
                    Console.WriteLine("Main Thread trying to get Lock B ...");
                }
            }
        }

        static void SomeMethod()
        {
            lock (lockB)
            {
                Console.WriteLine("Second Thread has Lock B");
                while (!Monitor.TryEnter(lockA, _timeout))
                {
                    Console.WriteLine("Second Thread trying to get Lock A ...");
                }
            }
        }
    }
}
