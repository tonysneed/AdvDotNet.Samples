using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;

namespace LeakMe
{
    class Hog
    {
        // Take up some memory
        private Form _form = new Form();

        public Hog()
        {
            // Subscribe to leaker event
            Leaker.Current.SomeEvent += (s, ea) => { };
        }
    }
}
