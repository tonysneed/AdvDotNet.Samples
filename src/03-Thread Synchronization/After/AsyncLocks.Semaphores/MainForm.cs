using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AsyncLocks.Semaphores
{
    public partial class MainForm : Form
    {
        private double _pi;
        readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0, 1);

        public MainForm()
        {
            InitializeComponent();
        }

        private async void calcButton_Click(object sender, System.EventArgs e)
        {
            calcButton.Enabled = false;
            placesNumeric.Enabled = false;
            resultTextBox.Text = string.Empty;

            // Calculate pi on a dedicated thread
            var worker = new Thread(CalculatePi);
            worker.Start((int)placesNumeric.Value);

            // Wait for thread to signal semaphore
            await _semaphore.WaitAsync();

            // Display result
            resultTextBox.Text = _pi.ToString(CultureInfo.InvariantCulture);

            calcButton.Enabled = true;
            placesNumeric.Enabled = true;
        }

        private void CalculatePi(object arg)
        {
            // Calculate pi to specified number of places
            int places = (int) arg;
            _pi = Calculator.CalculatePi(places);

            // Signal semaphore
            _semaphore.Release();
        }
    }
}
