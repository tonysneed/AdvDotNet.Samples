using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Buggy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void doItButton_Click(object sender, EventArgs e)
        {
            try
            {
                int i = Item;
            }
            catch (DivideByZeroException divideEx)
            {
                throw new NastyException("You are exceptional!", divideEx);
            }
        }

        private int Item
        {
            get
            {
                int i = 1;
                int j = 0;
                return i / j;
            }
        }
    }
}
