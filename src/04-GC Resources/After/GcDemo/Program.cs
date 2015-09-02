using System;
using System.Diagnostics;

namespace GcDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to Start");
            Console.ReadLine();

            var sw = new Stopwatch();
            var rng = new Random();
            int count = 10000000;
            sw.Start();
            var objects = new object[count]; // root
            for (int i = 0; i < count; i++)
            {
                //new object(); // no root
                //objects[i] = new object();
                objects[rng.Next(count)] = new object();
            }
            sw.Stop();
            Console.WriteLine("Elapsed milliseconds: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("Gen0 collections: {0}", GC.CollectionCount(0));
            Console.WriteLine("Gen1 collections: {0}", GC.CollectionCount(1));
            Console.WriteLine("Gen2 collections: {0}", GC.CollectionCount(2));
        }

        private static object r1 = new object();
        static void Main1(string[] args)
        {
            r1 = null;
            var w1 = new WeakReference(r1);
            GC.Collect(2);
            Console.WriteLine("r1 is alive: {0}", w1.IsAlive);

            object r2 = new object();
            var w2 = new WeakReference(r2);
            GC.Collect(2);
            Console.WriteLine("r2 is alive: {0}", w2.IsAlive);

            object r3 = new object();
            var w3 = new WeakReference(r3);
            GC.Collect(2);
            Console.WriteLine("r3 is alive: {0}", w3.IsAlive);

            r3.ToString();
        }
    }
}
