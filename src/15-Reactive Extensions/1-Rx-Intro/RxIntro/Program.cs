using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace RxIntro
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadName = "Main Thread";
            //CreateObservable();
            //FromEnumerable();
            //FromTask().Wait();
            //Console.ReadLine();
            //TaskToObservable();
            //int i = ObservableFromAsync().Result;
            //Console.WriteLine(i);
            //Cold();
            //Hot();
            //Console.ReadLine();
            //Compose();
            SchedulingObseveOn();
            Console.ReadLine();
        }

        static Task<string> GetHelloAsync()
        {
            return Task.Run(
                async () =>
                {
                    await Task.Delay(500);
                    return "Hello";
                });
        }

        static void Cold()
        {
            var cold = Observable.Interval(TimeSpan.FromSeconds(1));
            cold.Subscribe(i => Console.WriteLine(i));
        }

        static void Hot()
        {
            var timer = new System.Timers.Timer(1000);
            //timer.Elapsed += (sender, args) => Console.WriteLine(args.SignalTime);
            

            var hot = Observable.FromEventPattern<ElapsedEventArgs>(timer, "Elapsed");
            hot.Subscribe(p => Console.WriteLine(p.EventArgs.SignalTime));
            timer.Start(); // Starts notifications

            hot.Wait();
        }

        private static void SchedulingSubscribeOn()
        {
            // Create observable and filter on even values
            IObservable<int> observable = Observable.Range(1, 10);

            // Observe and print
            observable.SubscribeOn(TaskPoolScheduler.Default)
                .Subscribe(i => Console.WriteLine("{0} - {1}", i, ThreadName));
        }

        private static void SchedulingObseveOn()
        {
            var timer = new System.Timers.Timer(1000);
            var observable = Observable.FromEventPattern<ElapsedEventArgs>
                (timer, "Elapsed");
            //observable.Subscribe(ie => Console.WriteLine(ie.EventArgs.SignalTime));
            timer.Start(); // Timer fires notifications

            // Observe and print
            observable
                .ObserveOn(CurrentThreadScheduler.Instance)
                .Subscribe(i => Console.WriteLine("{0} - {1}", i.EventArgs.SignalTime,
                    Thread.CurrentThread.ManagedThreadId));
        }

        static void Merge()
        {
            var obs1 = new[] { 1, 3, 5, 7, 9 }.ToObservable();
            var obs2 = new[] { 2, 4, 6, 8, 10 }.ToObservable();

            var both = obs1.Merge(obs2);
            both.Subscribe(i => Console.WriteLine(i));
        }

        static void Compose()
        {
            var obs1 = new[] { 1, 2, 3 }.ToObservable();
            var obs2 = new[] { 1, 2, 3 }.ToObservable();

            var combined = from i1 in obs1
                from i2 in obs2
                select i1 + i2;
            combined.Subscribe(i => Console.WriteLine(i));
        }

        class Worker
        {
            public event Action<int> WorkProgressed;

            public void Work()
            {
                for (int i = 0; i < 5; i++)
                {
                    if (WorkProgressed != null)
                        WorkProgressed(i + 1);
                }
            }
        }

        private static void TaskToObservable()
        {
            Task<int> task = GetNumberAsync();

            IObservable<int> observable = task.ToObservable();
            observable.Subscribe(
                i => Console.WriteLine("{0}: {1}", ThreadName, i), // onNext
                () => Console.WriteLine("{0}: Done", ThreadName)); // onCompleted

            observable.Wait(); // block main thread until completion
        }

        private static async Task<int> GetNumberAsync()
        {
            // Simulate I/O bound async operation
            await Task.Delay(TimeSpan.FromSeconds(1));
            return 42; // Continuation callback
        }

        private static async Task<int> ObservableFromAsync()
        {
            IObservable<int> observable = Observable.FromAsync(GetNumberAsync);
            return await observable.FirstAsync();
        }

        private static async Task<int> TaskToObservableAsync()
        {
            Task<int> task = GetNumberAsync();

            IObservable<int> observable = task.ToObservable();
            observable.Subscribe(
                i => Console.WriteLine("{0}: {1}", ThreadName, i), // onNext
                () => Console.WriteLine("{0}: Done", ThreadName)); // onCompleted
            return await observable;
        }

        private static void FromEnumerable()
        {
            IEnumerable<int> ints = new[] {1, 2, 3, 4, 5, 6, 7, 8};
            IObservable<int> observable = ints.ToObservable();

            observable.Subscribe(
                i => Console.WriteLine(i), // onNext
                () => Console.WriteLine("Done")); // onCompleted
        }

        static void CreateObservable()
        {

            IObservable<int> observable = Observable.Create<int>(observer =>
            {
                observer.OnNext(1);
                observer.OnNext(2);
                observer.OnNext(3);
                //observer.OnError(new Exception("Doh!"));
                observer.OnCompleted();
                return Disposable.Empty;
            });

            observable.Subscribe(
                onNext:i => Console.WriteLine("{0}: {1}", ThreadName, i),
                onError: e => Console.WriteLine("{0}: {1}", ThreadName, e.Message),
                onCompleted: () => Console.WriteLine("{0}: Done", ThreadName));
        }

        static public string ThreadName
        {
            get { if (Thread.CurrentThread.IsThreadPoolThread)
                    return "Thread Pool";
                return Thread.CurrentThread.Name; }
            set { Thread.CurrentThread.Name = value; }
        }
    }
}
