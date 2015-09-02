using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Threading;

namespace RxWrappers.Service
{
    class PrimesService : IPrimesService
    {
        private int[] _primes = { 1, 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 };

        public int[] GetPrimes(string s)
        {
            // Latency
            int delay = new Random().Next(s.Length) * 100;
            Thread.Sleep(delay);

            int factor = 1;
            var result = new int[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                // Loop back on primes array
                if (i > _primes.Length)
                    factor = i / _primes.Length;
                if (i > (_primes.Length * factor) - 1)
                    result[i] = _primes[i - (_primes.Length * factor)];
                else
                    result[i] = _primes[i];
            }
            return result;
        }
    }
}