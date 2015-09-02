using System;
using System.Threading;

namespace HybridLocks.Monitors
{
    class Program
    {
        static void Main(string[] args)
        {
            var business = new Business();
            Console.WriteLine("Starting Cash: {0} Receivables: {1}",
                business.Cash.ToString("C"),
                business.Receivables.ToString("C"));

            int count = 10;
            Thread[] workers = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                workers[i] = new Thread(() =>
                {
                    business.Payment(100);
                });
                workers[i].Start();
            }

            for (int i = 0; i < count; i++)
            {
                workers[i].Join();
            }

            Console.WriteLine("Ending Cash: {0} Receivables: {1}",
                business.Cash.ToString("C"),
                business.Receivables.ToString("C"));
        }
    }
}
