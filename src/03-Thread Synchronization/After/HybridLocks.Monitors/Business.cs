using System;
using System.Threading;

namespace HybridLocks.Monitors
{
    class Business
    {
        public int Cash { get; private set; }
        public int Receivables { get; private set; }
        private readonly Random _rng = new Random();

        private readonly object _sharedLock = new object();

        public Business()
        {
            Cash = 0;
            Receivables = 1000;
        }

        public void Payment(int amount)
        {
            //lock (_sharedLock)
            bool success = Monitor.TryEnter(_sharedLock, 1000);
            if (!success)
            {
                Console.WriteLine("Failed to acquire lock");
                return;
            }

            try
            {
                Cash += amount;

                // Cause a deadlock
                if (Cash == 500) Thread.Sleep(Timeout.Infinite);

                Thread.Sleep(_rng.Next(1000));
                Receivables -= amount;
                Console.WriteLine("Cash: {0} Receivables: {1}",
                    Cash.ToString("C"),
                    Receivables.ToString("C"));
            }
            finally
            {
                Monitor.Exit(_sharedLock);
            } 
        }
    }
}
