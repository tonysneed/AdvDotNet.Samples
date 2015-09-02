using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Blocker.Service
{
    class Primes
    {
        private int _current;

        public int Next()
        {
            int[] values = Database.GetPrimes();
            if (_current > values.Length - 1)
                _current = 1;
            else
                _current++;
            return values[_current - 1];
        }

        public Task<int> NextAsync()
        {
            return Database.GetPrimesAsync().ContinueWith<int>(t =>
                {
                    if (_current > t.Result.Length - 1)
                        _current = 1;
                    else
                        _current++;
                    return t.Result[_current - 1];
                });
        }
    }
}
