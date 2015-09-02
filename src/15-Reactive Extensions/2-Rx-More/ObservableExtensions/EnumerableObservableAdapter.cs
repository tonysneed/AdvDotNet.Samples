using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservableExtensions
{
    /// <summary>
    /// Provides an IObservable that iterates over an IEnumerable calling OnNext.
    /// </summary>
    /// <typeparam name="T">Type argument</typeparam>
    class EnumerableObservableAdapter<T> : IObservable<T>
    {
        private IEnumerable<T> _sequence;

        public EnumerableObservableAdapter(IEnumerable<T> sequence)
        {
            _sequence = sequence;
        }

        public IDisposable Subscribe(IObserver<T> observer)
        {
            foreach (var value in _sequence)
            {
                observer.OnNext(value);
            }
            observer.OnCompleted();
            return new NullDisposable();
        }
    }
}
