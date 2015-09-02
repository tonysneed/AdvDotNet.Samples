using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HelloObservable
{
    class ObservableEvens : IObservable<int>
    {
        private int[] _ints;
        private bool _async;

        public ObservableEvens(int[] ints, bool async)
	    {
            _ints = ints;
            _async = async;
        }

        public IDisposable Subscribe(IObserver<int> observer)
        {
            foreach (var i in _ints)
            {
                // Even numbers
                if (i % 2 == 0)
                {
                    // Call back observer
                    if (_async)
                        new Action<int>(observer.OnNext).BeginInvoke(i, null, null);
                    else
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
