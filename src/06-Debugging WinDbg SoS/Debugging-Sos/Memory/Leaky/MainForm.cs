using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Leaky
{
    public partial class MainForm : Form
    {
        List<HogForm> _hogs = null;

        public event EventHandler PigOut;

        public MainForm()
        {
            InitializeComponent();
        }

        private void createHogsButton_Click(object sender, EventArgs e)
        {
            if (_hogs == null)
                _hogs = new List<HogForm>();

            int count = (int)hogsUpDown.Value;
            for (int i = 0; i < count; i++)
            {
                var hog = new HogForm(this);
                _hogs.Add(hog);
                hog.Show();
            }
        }

        private void pigOutButton_Click(object sender, EventArgs e)
        {
            if (PigOut != null)
                PigOut(this, EventArgs.Empty);
        }

        private void killHogsButton_Click(object sender, EventArgs e)
        {
            foreach (var hog in _hogs)
            {
                hog.Close();
            }
            _hogs = null;
        }

        private void collectGarbageButton_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
