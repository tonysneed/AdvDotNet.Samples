using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObservableExtensions
{
    /// <summary>
    /// Helper class that acts as an observer by calling back methods.
    /// </summary>
    /// <typeparam name="T">Type argument</typeparam>
    class DelegatingObserver<T> : IObserver<T>
    {
        private readonly Action<T> onNext;
        private readonly Action onCompleted;
        private readonly Action<Exception> onError;

        public DelegatingObserver(Action<T> onNext, Action onCompleted, Action<Exception> onError)
        {
            this.onNext = onNext;
            this.onCompleted = onCompleted;
            this.onError = onError;
        }

        public void OnCompleted()
        {
            onCompleted();
        }

        public void OnError(Exception error)
        {
            onError(error);
        }

        public void OnNext(T value)
        {
            onNext(value);
        }
    }
}
