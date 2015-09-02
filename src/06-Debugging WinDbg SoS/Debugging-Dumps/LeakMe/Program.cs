using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

// NOTE: WinDbg and SOS will not detect memory leaks for this application,
// because there are no hard references for it to chase down. To see the leaks,
// Leaker is using a timer to display number of items in the SomeEvent delegate's
// invocation list, letting us know the number of subscribers still alive.
// The best indication the app is leaking will be Task and Resource Managers,
// as well as performance counters. To diagnose the leak, however, will take
// a commercial memory profiler, such as ANTS from Red Gate.

namespace LeakMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press Enter to start leaking");
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
            StartLeaking();
        }

        static void StartLeaking()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(50);
                new Hog();
            }
        }
    }
}
