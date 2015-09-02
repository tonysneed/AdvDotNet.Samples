using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ObservableExtensions
{
    class ObservableEvens : IObservable<int>
    {
        private int[] _ints;

        public ObservableEvens(int[] ints)
	    {
            _ints = ints;
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            foreach (var i in _ints)
            {
                // Even numbers
                if (i % 2 == 0)
                {
                    // Call back observer
                    observer.OnNext(i);
                }
            }
            observer.OnCompleted();
            return new NullDisposable();
        }
    }

    class NullDisposable : IDisposable
    {
        public void Dispose() { }
    }
}
