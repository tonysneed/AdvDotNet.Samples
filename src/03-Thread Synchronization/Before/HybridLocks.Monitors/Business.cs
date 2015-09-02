using System;
using System.Threading;

namespace HybridLocks.Monitors
{
    class Business
    {
        public int Cash { get; private set; }
        public int Receivables { get; private set; }
        private readonly Random _rng = new Random();

        public Business()
        {
            Cash = 0;
            Receivables = 1000;
        }

        public void Payment(int amount)
        {
            Cash += amount;
            Thread.Sleep(_rng.Next(1000));
            Receivables -= amount;

            Console.WriteLine("Cash: {0} Receivables: {1}",
                Cash.ToString("C"),
                Receivables.ToString("C"));
        }
    }
}
