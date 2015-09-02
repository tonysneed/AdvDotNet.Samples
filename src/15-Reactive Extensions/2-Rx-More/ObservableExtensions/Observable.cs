using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservableExtensions
{
    static class Observable
    {
        // Subscribe to an IObservable using Delegating Observer
        public static IDisposable Subscribe<T>(this IObservable<T> source,
            Action<T> onNext, Action onCompleted)
        {
            return source.Subscribe(new DelegatingObserver<T>(onNext, onCompleted, e => { }));
        }

        // Provide IObservable that iterates over an IEnumerable calling OnNext
        public static IObservable<T> ToObservable<T>(this IEnumerable<T> source)
        {
            return new EnumerableObservableAdapter<T>(source);
        }
    }
}
