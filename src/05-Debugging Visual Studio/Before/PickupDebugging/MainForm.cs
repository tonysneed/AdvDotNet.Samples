using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PickupLib;
using System.Threading.Tasks;
using System.Threading;

namespace PickupDebugging
{
    public partial class MainForm : Form
    {
        PickupHelper _pickup = new PickupHelper();
        TaskScheduler _contextScheduler;

        public MainForm()
        {
            InitializeComponent();
            _contextScheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            pickupLinesComboBox.DataSource = new List<string>();
            if (!asyncCheckBox.Checked)
            {
                var lines = new List<string>();
                for (int i = 0; i < _pickup.LineCount; i++)
                {
                    lines.Add(_pickup.GetLine(i));
                }
                pickupLinesComboBox.DataSource = lines;
                return;
            }

            pickupLinesComboBox.Enabled = false;
            asyncCheckBox.Enabled = false;
            goButton.Enabled = false;

            var tasks = new List<Task<string>>();
            for (int i = 0; i < _pickup.LineCount; i++)
            {
                var task = _pickup.GetLineAsync(i);
                tasks.Add(task);
            }

            Task.Factory.ContinueWhenAll<string>(tasks.ToArray(), tsks =>
            {
                var lines = new List<string>();
                foreach (var t in tsks)
                {
                    lines.Add(t.Result);
                }

                pickupLinesComboBox.DataSource = lines;
                pickupLinesComboBox.Enabled = true;
                asyncCheckBox.Enabled = true;
                goButton.Enabled = true;
            }, new CancellationTokenSource().Token,
               TaskContinuationOptions.None, _contextScheduler);
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            if (pickupLinesComboBox.SelectedIndex == -1) return;
            if (!asyncCheckBox.Checked)
            {
                responseTextBox.Text = _pickup.GetResponse(pickupLinesComboBox.SelectedIndex);
                return;
            }

            goButton.Enabled = false;
            responseTextBox.Text = null;

            _pickup.GetResponseAsync(pickupLinesComboBox.SelectedIndex)
                .ContinueWith(t =>
                {
                    responseTextBox.Text = t.Result;
                    goButton.Enabled = true;
                }, _contextScheduler)
                .ContinueWith(t =>
                {
                    goButton.Enabled = true;
                    throw t.Exception; // exception is swallowed by runtime
                    string excMessage = GetErrorMessage(t.Exception);
                    MessageBox.Show(excMessage, "Error");
                }, new CancellationTokenSource().Token, 
                    TaskContinuationOptions.OnlyOnFaulted, _contextScheduler);
        }

        private string GetErrorMessage(Exception exception)
        {
            var aggExc = exception as AggregateException;
            if (aggExc != null)
            {
                var exc = aggExc.Flatten().InnerExceptions.FirstOrDefault();
                if (exc != null)
                    return exc.Message;
            }
            return exception.Message;
        }
    }
}
