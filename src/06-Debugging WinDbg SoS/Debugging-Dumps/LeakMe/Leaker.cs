using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace LeakMe
{
    class Leaker
    {
        Timer _timer;
        public event EventHandler SomeEvent;

        private Leaker()
        {
            _timer = new Timer(1000);
            _timer.Elapsed += Elapsed;
            _timer.Start();
        }

        private static Leaker instance;
        public static Leaker Current
        {
            get
            {
                if (instance == null)
                    instance = new Leaker();
                return instance;
            }
        }

        void Elapsed(object sender, ElapsedEventArgs e)
        {
            if (SomeEvent != null)
            {
                Console.WriteLine("Hogs in memory: {0}",
                    SomeEvent.GetInvocationList().Count());
            }
        }
    }
}
