using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RxWrappers.WinFormsClient.PrimesService;
using System.ServiceModel;
using System.Threading;
using System.Reactive.Linq;
using System.Reactive.Concurrency;

/* DONE:
 * 1) Wrap TextChanged event with Rx to get a string
 * 2) Use DistinctUntilChanged to avoid service calls when retyping same text
 * 3) Throttle observed TextChanged event for 500 ms pause in typing
 * 4) Handle thread marshalling with ObserveOn
 * 5) Wrap async service call with Rx
 * 6) Compose both observables using SelectMany (LINQ syntax with multiple from's)
 * 7) Address unordered results problem (due to service latency) with TakeUntil and Switch
 */

namespace RxWrappers.WinFormsClient
{
    public partial class MainForm : Form
    {
        SynchronizationContext _syncRoot;
        PrimesServiceClient _proxy = new PrimesServiceClient();

        public MainForm()
        {
            InitializeComponent();
            _syncRoot = SynchronizationContext.Current;

            // 1. Wrap TextChanged event in an observable (1st overload)
            // - Don't forget to remove existing event handler
            var ts = Observable.FromEventPattern(inputTextBox, "TextChanged");

            // Use LINQ to project an observable of strings
            var eventObs = (from e in ts
                       select ((TextBox)e.Sender).Text)
                       // 2. Filter out event if text has not changed
                      .DistinctUntilChanged()
                      // 3. Filter events occurring less than 1/2 second apart
                      .Throttle(TimeSpan.FromSeconds(.5));

            // 4. Marshal OnNext to the UI thread
            //eventObs.ObserveOn(new SynchronizationContextScheduler(_syncRoot));
            eventObs.ObserveOn(this)                                 // Add Rx-WinForms Nuget package
            .Subscribe(s => lengthLabel.Text = s.Length.ToString()); // Set label to string length

            // 5. Wrap WCF async call in an observable
            // - Must specify types of method args and return
            Func<string, IObservable<int[]>> asyncFunc = 
                Observable.FromAsyncPattern<string, int[]>
                    (_proxy.BeginGetPrimes, _proxy.EndGetPrimes);

            /* // Replaced by #6 below
            // Call svc on event observer's OnNext
            eventObs.Subscribe(s =>
            {
                // Call async func to get back observable for result
                // - Remember to observe on the UI thread
                asyncFunc(s).ObserveOn(this).Subscribe(primes =>
                    {
                        // Process primes
                        string primesString = string.Empty;
                        foreach (var i in primes)
                        {
                            if (primesString.Length > 0) primesString += ", ";
                            primesString += i.ToString();
                        }

                        // Update primes label
                        primesLabel.Text = string.Format("Count: {0}\n{1}",
                            primes.Length, primesString);
                    });
            });
             */

            /*  Replaced by # 7 below
            // 6. Compose both event and async observables
            var composedObs = from s in eventObs
                              from ints in asyncFunc(s)
                              // Discard pending async result when new one arrives
                              .TakeUntil(eventObs)
                              select ints; */

            // 7. Use switch to discard pending async result when new one arrives
            // - Use select to project observable of observables and switch between them
            //   when one arrives before another finishes
            var composedObs = (from s in eventObs
                               select asyncFunc(s))
                              .Switch();

            // Handle OnNext for composed observable
            composedObs.ObserveOn(this).Subscribe(primes =>
                {
                    // Process primes
                    string primesString = string.Empty;
                    foreach (var i in primes)
                    {
                        if (primesString.Length > 0) primesString += ", ";
                        primesString += i.ToString();
                    }

                    // Update primes label
                    primesLabel.Text = string.Format("Count: {0}\n{1}",
                        primes.Length, primesString);
                });
        }

        /* // Replaced by Rx code in ctor
        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            // Set label to string length
            lengthLabel.Text = inputTextBox.Text.Length.ToString();

            // Invoke Primes service
            _proxy.BeginGetPrimes(inputTextBox.Text, ar =>
            {
                int[] primes = _proxy.EndGetPrimes(ar);
                string primesString = string.Empty;
                foreach (var i in primes)
                {
                    if (primesString.Length > 0) primesString += ", ";
                    primesString += i.ToString();
                }

                // Marshal call to UI thread
                _syncRoot.Post(o =>
                {
                    // Update primes label
                    primesLabel.Text = string.Format("Count: {0}\n{1}",
                        primes.Length, primesString);
                }, null);
            }, null);
        }
         */

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                _proxy.Close();
            }
            catch (CommunicationException)
            {
                _proxy.Abort();
            }
        }
    }
}
