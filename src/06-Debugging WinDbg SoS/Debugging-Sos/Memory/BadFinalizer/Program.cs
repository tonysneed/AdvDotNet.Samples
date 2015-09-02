using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BadFinalizer
{
    class GCMe
    {
        bool _beEvil;

        public GCMe(bool beEvil)
        {
            _beEvil = beEvil;

            Console.WriteLine("Ctor on Thread {0}",
                Thread.CurrentThread.ManagedThreadId);
        }
        ~GCMe()
        {
            if (_beEvil)
                Thread.Sleep(Timeout.Infinite);

            Console.WriteLine("Finalizer on Thread {0}",
                Thread.CurrentThread.ManagedThreadId);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Bad Finalizer";
            Console.WriteLine("Be evil? {Y/N}");
            bool beEvil = Console.ReadLine().ToUpper() == "Y";

            while (!Console.KeyAvailable)
            {
                new GCMe(beEvil);
                Thread.Sleep(TimeSpan.FromTicks(100));
            }
        }
    }
}
