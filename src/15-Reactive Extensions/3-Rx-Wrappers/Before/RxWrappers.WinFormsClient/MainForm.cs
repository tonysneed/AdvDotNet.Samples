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

/* TODO:
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
        }

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
