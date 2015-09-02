using System;
using System.Threading;

namespace AsyncLocks.Semaphores
{
    static class Calculator
    {
        public static int Interval = 50;

        public static double CalculatePi(int places)
        {
            for (int i = 0; i < places; i++)
            {
                // Simulate compute-bound operation
                Thread.Sleep(Interval * (i + 1));
            }

            // Round pi to specified number of places
            return Math.Round(Math.PI, places);
        }
    }
}
