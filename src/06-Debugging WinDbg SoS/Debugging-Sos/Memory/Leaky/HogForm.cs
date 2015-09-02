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
    public partial class HogForm : Form
    {
        int count = 0;
        List<int[]> _buffers = new List<int[]>();
        MainForm _mainForm;

        public HogForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.PigOut += OnPigOut;
        }

        void OnPigOut(object sender, EventArgs e)
        {
            count++;
            countLabel.Text = count.ToString();
            int[] ints = new int[1000000];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            _buffers.Add(ints);
        }

        private void HogForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (unsubscribeCheckBox.Checked)
            {
                _mainForm.PigOut -= OnPigOut;
            }
        }
    }
}
