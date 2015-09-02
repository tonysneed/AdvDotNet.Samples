using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloObservable
{
    class EvensObserver : IObserver<int>
    {
        private TimeSpan _delay;

        public EvensObserver(int delaySeconds)
        {
            _delay = TimeSpan.FromSeconds(delaySeconds);
        }

        public void OnCompleted()
        {
            Console.WriteLine("Done");
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("Oops: {0}", error.Message);
        }

        public void OnNext(int value)
        {
            // Add delay if item is multiple of 4
            if (value % 4 == 0) Program.Delay(_delay);

            // Print value
            Console.WriteLine(value);
        }
    }

}
