using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.ServiceModel;
using FormsTimer = System.Windows.Forms.Timer;
using System.Diagnostics;

namespace Blocker.Client
{
    public partial class MainForm : Form
    {
        const int TimerInterval = 500;
        SynchronizationContext _syncRoot;
        List<FormsTimer> _timers = new List<FormsTimer>();
        List<IBlockingService> _clients = new List<IBlockingService>();

        public MainForm()
        {
            InitializeComponent();
            _syncRoot = SynchronizationContext.Current;
        }

        void goButton_Click(object sender, EventArgs e)
        {
            // Add to clients and timers lists
            goButton.Enabled = false;
            stopButton.Enabled = false;
            clientsUpDown.Enabled = false;
            int start = _clients.Count;
            int max = (int)clientsUpDown.Value;
            ChannelFactory<IBlockingService> factory;
            if (asyncCheckBox.Checked)
                factory = new ChannelFactory<IBlockingService>("async");
            else
                factory = new ChannelFactory<IBlockingService>("sync");
            for (int i = 0; i < max; i++)
            {
                _clients.Add(factory.CreateChannel());
                var timer = new FormsTimer { Interval = TimerInterval };
                timer.Tick += OnTick;
                _timers.Add(timer);
            }

            // Start each timer
            int count = 1;
            var buttonTimer = new FormsTimer { Interval = 500 };
            buttonTimer.Start();
            buttonTimer.Tick += (s, ea) =>
                {
                    if (count > max)
                    {
                        DisposeTimer(buttonTimer);
                        goButton.Text = "Go";
                        goButton.Enabled = true;
                        stopButton.Enabled = true;
                        clientsUpDown.Enabled = true;
                        return;
                    }
                    goButton.Text = count.ToString();
                    var index = start + count - 1;
                    var timer = _timers[index];
                    timer.Start();
                    count++;
                };
        }

        void stopButton_Click(object sender, EventArgs e)
        {
            // Disable controls
            clientsUpDown.Enabled = false;
            goButton.Enabled = false;
            stopButton.Enabled = false;

            Action stopDel = StopClients;
            stopDel.BeginInvoke(ar =>
                {
                    // Clear timers and clients lists
                    _timers.Clear();
                    _clients.Clear();

                    // Update UI
                    _syncRoot.Post(ClientsStopped, null);
                }, null);
        }

        void StopClients()
        {
            // Dispose timers
            foreach (var timer in _timers)
            {
                DisposeTimer(timer);
            }

            // Dispose clients
            for (int i = _clients.Count - 1; i > -1; i--)
            {
                _syncRoot.Post(ClientStopping, i + 1);
                var client = _clients[i];
                DisposeClient(client);
            }
        }

        void ClientStopping(object arg)
        {
            // Show client number
            var index = (int)arg;
            stopButton.Text = index.ToString();
        }

        void ClientsStopped(object arg)
        {
            // Enable controls
            clientsUpDown.Enabled = true;
            goButton.Enabled = true;
            stopButton.Enabled = true;
            stopButton.Text = "Stop";

            // Clear list
            primesListBox.Items.Clear();
        }

        void OnTick(object sender, EventArgs e)
        {
            var timer = (FormsTimer)sender;
            int requestNum = _timers.IndexOf(timer) + 1;
            var client = _clients[requestNum - 1];
            var request = new NextPrimeRequest
            {
                RequestNumber = requestNum,
                Client = client
            };
            if (request.RequestNumber > primesListBox.Items.Count)
            {
                primesListBox.Items.Add(string.Empty);
            }
            try
            {
                client.BeginNext(GetNextPrimeComplete, request);
            }
            catch (CommunicationException comEx)
            {
                Debug.Print("Client Begin Request Error: {0}", comEx.Message);
            }
        }

        void GetNextPrimeComplete(IAsyncResult ar)
        {
            int nextPrime = 0;
            var request = (NextPrimeRequest)ar.AsyncState;
            try
            {
                nextPrime = request.Client.EndNext(ar);
            }
            catch (TimeoutException)
            {
                Debug.Print("Client Request Timeout");
                return;
            }
            catch (CommunicationException comEx)
            {
                Debug.Print("Client End Request Error: {0}", comEx.Message);
                return;
            }
            var result = new NextPrimeResult
            {
                RequestNumber = request.RequestNumber,
                NextPrime = nextPrime
            };
            _syncRoot.Post(UpdateList, result);
        }

        void UpdateList(object arg)
        {
            var result = (NextPrimeResult)arg;
            var numList = (string)primesListBox.Items[result.RequestNumber - 1];
            if (numList.Length > 0) numList += ", ";
            numList += result.NextPrime;
            primesListBox.Items[result.RequestNumber - 1] = numList;
        }

        private void DisposeTimer(FormsTimer timer)
        {
            timer.Stop();
            timer.Dispose();
        }

        private void DisposeClient(IBlockingService client)
        {
            var disposable = client as IDisposable;
            if (disposable != null)
            {
                try
                {
                    disposable.Dispose();
                }
                catch (CommunicationException)
                {
                    ((IClientChannel)client).Abort();
                }
            }
        }
    }
}
