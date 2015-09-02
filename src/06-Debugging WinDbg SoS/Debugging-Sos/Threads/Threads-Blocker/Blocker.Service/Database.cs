using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;

namespace Blocker.Service
{
    static class Database
    {
        private const int _factor = 2;
        private static int _request = 1;
        private static Random _rng = new Random();
        private static object _sharedLock = new object();
        private static int[] _primes = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public static int[] GetPrimes()
        {
            int duration = _rng.Next(_request * _factor);
            Console.WriteLine("Database request: {0} miliseconds", duration);
            lock (_sharedLock)
            {
                // Simulate blocking IO operation
                Thread.Sleep(duration);
                _request++;
                return _primes;
            }
        }

        public static Task<int[]> GetPrimesAsync()
        {
            int duration = _rng.Next(_request * _factor);
            Console.WriteLine("Database request: {0} miliseconds", duration);
            lock (_sharedLock)
            {
                // Simulate non-blocking IO operation
                return Delay(duration).ContinueWith<int[]>(t =>
                {
                    _request++;
                    return _primes;
                });
            }
        }

        private static Task Delay(int miliseconds)
        {
            var tcs = new TaskCompletionSource<bool>();
            var timer = new Timer();
            timer.Elapsed += (obj, args) =>
            {
                tcs.TrySetResult(true);
            };
            if (miliseconds == 0) miliseconds = 1;
            timer.Interval = miliseconds;
            timer.AutoReset = false;
            timer.Start();
            return tcs.Task;
        }
    }
}
