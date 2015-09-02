using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Threading;

namespace HelloObservable
{
    class EnumerableEvens : IEnumerable<int>
    {
        private int[] _ints;
        private int _delaySeconds;

        public EnumerableEvens(int[] ints, int delaySeconds)
        {
            _ints = ints;
            _delaySeconds = delaySeconds;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return new EvensEnumerator(_ints, _delaySeconds);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class EvensEnumerator : IEnumerator<int>
        {
            private int _index = -1;
            private int[] _ints;
            private TimeSpan _delay;

            public EvensEnumerator(int[] ints, int delaySeconds)
            {
                _ints = ints;
                _delay = TimeSpan.FromSeconds(delaySeconds);
            }

            public int Current
            {
                get
                {
                    // Add delay if item is multiple of 4
                    if (_ints[_index] % 4 == 0) Program.Delay(_delay);

                    // Return current item
                    return _ints[_index];
                }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                // Stop iterating if we're at the end
                if (_index == _ints.Length - 1) return false;

                // Increment index
                _index++;

                // If odd number, move to next item
                if (!(_ints[_index] % 2 == 0)) _index++;

                // Advance to next item
                return true;
            }

            public void Reset() { }
            public void Dispose() { }
        }
    }
}
