using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace AsyncLocks.Semaphores
{
    public partial class MainForm : Form
    {
        private double _pi;

        public MainForm()
        {
            InitializeComponent();
        }

        private void calcButton_Click(object sender, System.EventArgs e)
        {
            calcButton.Enabled = false;
            placesNumeric.Enabled = false;
            resultTextBox.Text = string.Empty;

            // Calculate pi on a dedicated thread
            var worker = new Thread(CalculatePi);
            worker.Start((int)placesNumeric.Value);

            // Wait for processing to finish (non-responsive)
            worker.Join();
            
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
        }
    }
}
